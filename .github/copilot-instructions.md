# Copilot Instructions

## General Guidelines
- First general instruction
- Second general instruction
- Prefer highly automated session management with only three user actions: New/Reset, Load, and Save. Include an optional toggle to enable/disable session metadata features.

## Audio Configuration
- When LTC is enabled, sync beeps/countdown must only play before timecode starts (never during).
- Prefer stereo output with LTC on Left and beeps on Right.
- Run the full pre-roll sequence (countdown plus sync beep) on every start, not only when timecode is zero.
- Ensure the final sync beep onset aligns exactly with timecode unpause/start for precision and reduced distraction.