using System;
using System.Runtime.InteropServices;
using Microsoft.FlightSimulator.SimConnect;

namespace Msfs2024Copilot.Services
{
    public sealed class SimConnectService : IDisposable
    {
        private const int WM_USER_SIMCONNECT = 0x0402;
        private readonly IntPtr _windowHandle;
        private SimConnect _simConnect;

        public event EventHandler<string> StatusChanged;

        public SimConnectService(IntPtr windowHandle)
        {
            _windowHandle = windowHandle;
        }

        public void Connect()
        {
            try
            {
                _simConnect = new SimConnect("Msfs2024Copilot", _windowHandle, WM_USER_SIMCONNECT, null, 0);
                StatusChanged?.Invoke(this, "Connected to MSFS.");
            }
            catch (COMException)
            {
                StatusChanged?.Invoke(this, "SimConnect connection failed. Is MSFS running?");
            }
        }

        public void ExecuteCommand(string command)
        {
            if (_simConnect == null)
            {
                StatusChanged?.Invoke(this, "Not connected to MSFS.");
                return;
            }

            switch (command)
            {
                case "gear up":
                    SendEvent("GEAR_UP");
                    break;
                case "gear down":
                    SendEvent("GEAR_DOWN");
                    break;
                case "flaps up":
                    SendEvent("FLAPS_UP");
                    break;
                case "flaps one":
                case "flaps two":
                case "flaps three":
                case "flaps full":
                    SendEvent("FLAPS_INCR");
                    break;
                case "lights on":
                    SendEvent("TOGGLE_BEACON_LIGHTS");
                    SendEvent("TOGGLE_NAV_LIGHTS");
                    SendEvent("TOGGLE_LANDING_LIGHTS");
                    break;
                case "lights off":
                    SendEvent("TOGGLE_LANDING_LIGHTS");
                    SendEvent("TOGGLE_NAV_LIGHTS");
                    SendEvent("TOGGLE_BEACON_LIGHTS");
                    break;
                case "autopilot on":
                    SendEvent("AP_MASTER");
                    break;
                case "autopilot off":
                    SendEvent("AP_MASTER");
                    break;
                case "checklist before start":
                    StatusChanged?.Invoke(this, "Checklist: Before Start - (stub)");
                    break;
                case "checklist before takeoff":
                    StatusChanged?.Invoke(this, "Checklist: Before Takeoff - (stub)");
                    break;
                case "checklist before landing":
                    StatusChanged?.Invoke(this, "Checklist: Before Landing - (stub)");
                    break;
                default:
                    StatusChanged?.Invoke(this, $"Unknown command: {command}");
                    break;
            }
        }

        private void SendEvent(string eventName)
        {
            try
            {
                _simConnect.MapClientEventToSimEvent((Enum)SimConnectEvent.Generic, eventName);
                _simConnect.TransmitClientEvent(SimConnect.SIMCONNECT_OBJECT_ID_USER, SimConnectEvent.Generic, 0, SimConnectGroup.Priority, SIMCONNECT_EVENT_FLAG.GROUPID_IS_PRIORITY);
                StatusChanged?.Invoke(this, $"Sent: {eventName}");
            }
            catch (COMException)
            {
                StatusChanged?.Invoke(this, "SimConnect send failed.");
            }
        }

        public void Dispose()
        {
            _simConnect?.Dispose();
        }

        private enum SimConnectEvent
        {
            Generic = 0x0001
        }

        private enum SimConnectGroup
        {
            Priority = 0x0001
        }
    }
}
