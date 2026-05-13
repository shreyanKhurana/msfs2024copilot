using System;
using System.Collections.Generic;
using System.Globalization;
using System.Speech.Recognition;
using System.Speech.Synthesis;

namespace Msfs2024Copilot.Services
{
    public sealed class SpeechService : IDisposable
    {
        private readonly SpeechRecognitionEngine _recognizer;
        private readonly SpeechSynthesizer _synthesizer;

        public event EventHandler<string> CommandRecognized;
        public event EventHandler<string> StatusChanged;

        public SpeechService()
        {
            _recognizer = new SpeechRecognitionEngine(new CultureInfo("en-US"));
            _synthesizer = new SpeechSynthesizer();

            _recognizer.SetInputToDefaultAudioDevice();
            _recognizer.LoadGrammar(BuildGrammar());
            _recognizer.SpeechRecognized += OnSpeechRecognized;
            _recognizer.RecognizeCompleted += (_, __) => StatusChanged?.Invoke(this, "Listening stopped.");
            _recognizer.SpeechRecognitionRejected += (_, __) => StatusChanged?.Invoke(this, "Unrecognized command.");

            _synthesizer.SetOutputToDefaultAudioDevice();
        }

        public void Start()
        {
            _recognizer.RecognizeAsync(RecognizeMode.Multiple);
            StatusChanged?.Invoke(this, "Listening started.");
            Speak("Ready.");
        }

        public void Stop()
        {
            _recognizer.RecognizeAsyncCancel();
            Speak("Listening stopped.");
        }

        public void Speak(string text)
        {
            _synthesizer.SpeakAsyncCancelAll();
            _synthesizer.SpeakAsync(text);
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
            _recognizer?.Dispose();
            _synthesizer?.Dispose();
        }
    }
}
