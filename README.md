# msfs2024copilot
Offline voice copilot for Microsoft Flight Simulator 2024 using SimConnect + Windows SAPI.

## Features (MVP)
- Local speech recognition and TTS (no cloud)
- Basic command grammar (gear, flaps, lights, autopilot)
- SimConnect event dispatch
- Windows EXE installer (Inno Setup)

## Prerequisites
- Windows 10/11
- MSFS SDK installed (for SimConnect.dll)
- Visual Studio 2022 (Desktop development with .NET)
- Inno Setup 6 (for installer)

## Setup
1. Copy `SimConnect.dll` into `lib/`.
2. Open `src/Msfs2024Copilot.sln` in Visual Studio.
3. Build `Release`.

## Build installer
1. Build the Release binary in Visual Studio.
2. Open `installer/msfs2024copilot.iss` in Inno Setup.
3. Compile to generate the EXE in `installer/output/`.

## Notes
- This project is a fresh, original implementation and does not copy FS2 Crew content.
- Extend grammar and checklist logic in `SpeechService` and `SimConnectService`.
