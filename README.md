![ThreatMeter](https://github.com/MrJambix/Ethyrial_Addon/assets/131601090/fb168b83-1c9e-4a4d-836d-b4dad5d4a381)
![TM](https://github.com/MrJambix/Ethyrial_Addon/assets/131601090/adee599c-a89c-4376-8f42-53580cf18291)
![EXPBAR](https://github.com/MrJambix/Ethyrial_Addon/assets/131601090/046e760d-f21d-48a0-ad9d-a3da453983fd)
![OtherStats](https://github.com/MrJambix/Ethyrial_Addon/assets/131601090/4b4fb22e-9346-4293-9111-9b000ec06e5e)


# Ethyrial_Addon

## Installation Instructions

### Locate your "Ethyrial Echoes of Yore" game directory
- Find the directory path: `Steam\steamapps\common\Ethyrial Echoes of Yore\Ethyrial_Data\Managed`

### Create a Backup Folder
- On your desktop, create a new folder and name it "DLL_BackUp."

### Back Up the Game.DLL File
- From the "Managed" folder in your game directory, locate the "Game.DLL" file.
- Copy the "Game.DLL" file and place it in the "DLL_BackUp" folder you created earlier.

### Download the Updated DLL
- Download the updated .DLL file from the repository.

### Replace the Game.DLL
- Insert the downloaded .DLL file into the directory: `Steam\steamapps\common\Ethyrial Echoes of Yore\Ethyrial_Data\Managed`

### Launch the Game
- Launch the game with the updated .DLL file.

## Uninstallation Instructions

### Locate your game directory
- Find the directory path as mentioned above.

### Delete the Game.DLL
- Remove the "Game.DLL" file from the "Managed" folder.

### Restore the Backup (if available)
- If you backed up the original "Game.DLL," place it back into the "Managed" folder.

### No Backup? Verify Game Integrity
- If no backup is available, use Steam to restore the original "Game.DLL."
  - Right-click on "Ethyrial" in Steam library.
  - Select "Properties."
  - Navigate to "Local Files."
  - Click "Verify Integrity of Game Files."

## Changelog

### Version 2.1.2
#### Added
- `ExperienceDisplay` script in Unity.
- UI Text references for experience tracking.

#### Updated
- `Start` method now finds the local player entity.

#### Changed
- `Update` method updates UI Text for experience.
- Calculates experience percentage to two decimal places.

### Version 2.1.1
#### Added
- EXP percentage display in GUI.

#### Changed
- Modified EXP bar size and positioning.
- Improved EXP bar `yPos` calculation.

#### Fixed
- Issue with EXP bar not displaying.
- Compile error (CS0136) related to `flag` variable.

### [Previous Versions]
- Describe initial release and other changes.

## Contributors
1. MrJambix
2. Bardcore (Original Creator of DPS/Exp Tracker)
3. Knowledge/Ryan

## Disclaimer
This addon is not officially endorsed by Ethyrial Echoes of Yore. Use at your own risk. Modifications to game files can be against the terms of service of many games. The authors of this addon are not responsible for any consequences that arise from its use.
