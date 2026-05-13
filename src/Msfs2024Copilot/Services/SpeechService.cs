using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Speech.AudioFormat;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using NAudio.CoreAudioApi;
using NAudio.Wave;

namespace Msfs2024Copilot.Services
{
    public sealed class SpeechService : IDisposable
    {
        private readonly SpeechRecognitionEngine _recognizer;
        private readonly SpeechSynthesizer _synthesizer;
        private WasapiCapture _capture;
        private BufferedWaveProvider _bufferedWaveProvider;
        private WaveProviderToWaveStream _audioStream;
        private string _selectedDeviceId;
        private bool _isListening;

        public event EventHandler<string> CommandRecognized;
        public event EventHandler<string> StatusChanged;
        public event EventHandler<int> AudioLevelChanged;

        public SpeechService()
        {
            _recognizer = new SpeechRecognitionEngine(new CultureInfo("en-US"));
            _synthesizer = new SpeechSynthesizer();

            _recognizer.LoadGrammar(BuildGrammar());
            _recognizer.SpeechRecognized += OnSpeechRecognized;
            _recognizer.AudioLevelUpdated += (_, e) => AudioLevelChanged?.Invoke(this, e.AudioLevel);
            _recognizer.RecognizeCompleted += (_, __) => StatusChanged?.Invoke(this, "Listening stopped.");
            _recognizer.SpeechRecognitionRejected += (_, __) => StatusChanged?.Invoke(this, "Unrecognized command.");

            _synthesizer.SetOutputToDefaultAudioDevice();
        }

        public void Start()
        {
            ConfigureInput();
            _recognizer.RecognizeAsync(RecognizeMode.Multiple);
            _isListening = true;
            StatusChanged?.Invoke(this, "Listening started.");
            Speak("Ready.");
        }

        public void Stop()
        {
            if (_isListening)
            {
                _recognizer.RecognizeAsyncCancel();
                _isListening = false;
            }

            StopCapture();
            Speak("Listening stopped.");
        }

        public bool IsListening => _isListening;

        public sealed class InputDevice
        {
            public InputDevice(string id, string name)
            {
                Id = id;
                Name = name;
            }

            public string Id { get; }
            public string Name { get; }

            public override string ToString()
            {
                return Name;
            }
        }

        public List<InputDevice> GetInputDevices()
        {
            using (var enumerator = new MMDeviceEnumerator())
            {
                var devices = enumerator.EnumerateAudioEndPoints(DataFlow.Capture, DeviceState.Active)
                    .Select(device => new InputDevice(device.ID, device.FriendlyName))
                    .ToList();

                devices.Insert(0, new InputDevice(string.Empty, "Default microphone (Windows)"));
                return devices;
            }
        }

        public void SetInputDevice(string deviceId)
        {
            _selectedDeviceId = deviceId ?? string.Empty;

            if (_isListening)
            {
                _recognizer.RecognizeAsyncCancel();
                _isListening = false;
                StopCapture();
                Start();
            }
        }

        public void Speak(string text)
        {
            _synthesizer.SpeakAsyncCancelAll();
            _synthesizer.SpeakAsync(text);
        }

        private void ConfigureInput()
        {
            StopCapture();

            if (string.IsNullOrWhiteSpace(_selectedDeviceId))
            {
                _recognizer.SetInputToDefaultAudioDevice();
                return;
            }

            using (var enumerator = new MMDeviceEnumerator())
            {
                var device = enumerator.GetDevice(_selectedDeviceId);
                var format = new WaveFormat(16000, 16, 1);
                _capture = new WasapiCapture(device) { ShareMode = AudioClientShareMode.Shared };
                _capture.WaveFormat = format;

                _bufferedWaveProvider = new BufferedWaveProvider(format)
                {
                    DiscardOnBufferOverflow = true
                };

                _audioStream = new WaveProviderToWaveStream(_bufferedWaveProvider);
                _recognizer.SetInputToAudioStream(
                    _audioStream,
                    new SpeechAudioFormatInfo(16000, AudioBitsPerSample.Sixteen, AudioChannel.Mono));

                _capture.DataAvailable += OnCaptureDataAvailable;
                _capture.StartRecording();
            }
        }

        private void OnCaptureDataAvailable(object sender, WaveInEventArgs e)
        {
            _bufferedWaveProvider?.AddSamples(e.Buffer, 0, e.BytesRecorded);
        }

        private void StopCapture()
        {
            if (_capture != null)
            {
                _capture.DataAvailable -= OnCaptureDataAvailable;
                try
                {
                    _capture.StopRecording();
                }
                catch (InvalidOperationException)
                {
                    // Capture may already be stopped.
                }
                _capture.Dispose();
                _capture = null;
            }

            _audioStream?.Dispose();
            _audioStream = null;
            _bufferedWaveProvider = null;
        }

        private void OnSpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            if (e.Result.Confidence < 0.6)
            {
                StatusChanged?.Invoke(this, "Low confidence command ignored.");
                return;
            }

            CommandRecognized?.Invoke(this, e.Result.Text);
        }

        private static Grammar BuildGrammar()
        {
            var commands = new Choices(new[]
            {
                "gear up",
                "gear down",
                "flaps up",
                "flaps one",
                "flaps two",
                "flaps three",
                "flaps full",
                "lights on",
                "lights off",
                "set heading",
                "set altitude",
                "autopilot on",
                "autopilot off",
                "checklist before start",
                "checklist before takeoff",
                "checklist before landing"
            });

            var builder = new GrammarBuilder(commands);
            return new Grammar(builder) { Name = "CopilotCommands" };
        }

        public void Dispose()
        {
            StopCapture();
            _recognizer?.Dispose();
            _synthesizer?.Dispose();
        }
    }
}
