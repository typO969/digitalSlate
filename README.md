# digitalSlate

A Windows desktop digital clapperboard for film and video production, built with `VB.NET` and `WinForms`.

`digitalSlate` provides an on-set slate workflow with timecode display, countdown/sync beeps, optional LTC generation, marker logging, and profile save/load.

<img width="1500" height="1050" alt="20260615_125741" src="https://github.com/user-attachments/assets/8f89cbb8-70c8-470a-b59e-8ce7e959c561" />
(Close up Photo of program in action on a tablet)
<br>
<br>

<img width="1383" height="1017" alt="20260615_125618" src="https://github.com/user-attachments/assets/2b8eb640-6c3a-47bc-82e0-55b285ba4a0b" />
(Another example photo)
<br>
<br>


## Features

- Full-screen slate UI with responsive scaling
- Scene / take / roll / production metadata editing
- Lock mode to prevent accidental edits during takes
- Configurable countdown and sync beep workflow
- Timecode display and reset controls
- LTC output (left channel) with selectable FPS and output device
- LTC calibration tone (right-channel reference tone)
- Resolve-compatible marker CSV logging/export
- Session metadata support (session ID, unit, operator)
- Custom logo support
- Save/load slate profiles

## Requirements

- Windows
- `.NET Framework 4.8`
- Audio output device for LTC/sync audio workflows

## Build and Run

1. Open the solution in Visual Studio.
2. Restore NuGet packages (if prompted).
3. Build the `Debug` or `Release` configuration.
4. Run the app.

## Basic Usage

1. Open **Settings** and configure:
   - LTC enable/device/FPS/mute
   - Countdown + sync beeps
   - Marker logging folder/output options
2. Edit slate metadata from **Edit Slate**.
3. Click the clapper to run preroll and start/stop take timing.
4. Optionally lock the slate with `LOCK SLATE` during active operation.
5. Export markers or save/load slate profiles as needed.

## Audio / LTC Notes

- Intended routing:
  - **Left channel:** LTC
  - **Right channel:** sync/reference tones
- Countdown and sync beeps are designed to run before timecode starts.

## Marker CSV

The app can write Resolve-compatible CSV marker rows with:

- Marker name
- Description
- In/Out timecode
- Duration
- Marker color/type

## Project Structure (high level)

- `frmDigitalSlate.vb` — main slate UI and runtime behavior
- `frmSettings.vb` — application settings
- `frmEdit.vb` — slate metadata editor
- `Functions.vb` — shared app logic/helpers
- `Timecode/` — LTC encoding/output components

## Status

Active project in production-focused iteration.
Looking for bugs, but I consider this project more or less completed.
