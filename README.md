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


# Version 2.1.3 BardButler Class Enhancements and Impact
### Added threatTrackerEntries Field
- **Description**: A list to track threats for each entity.
- **Impact**: Enhanced Threat Tracking: Enables detailed tracking of threats associated with game entities.

### Added currentTarget Field
- **Description**: A field to hold the currently targeted hostile entity.
- **Impact**: Targeted Entity Management: Allows tracking of the player's focused hostile entity.

### Updated Constructor
- **Description**: Initialized the new threatTrackerEntries and currentTarget fields.
- **Impact**: Updated Constructor: Initializes new fields for threat tracking and target management.

### New Method: SetTarget(GameObject target)
- **Description**: Sets the current target and manages the application of the outline effect.
- **Impact**: Dynamic Target Selection and Highlighting: For selecting and visually highlighting the targeted entity.

### Updated DrawThreatMeter Method
- **Description**: Enhanced to highlight the threat level for the current target. Adjusted to display threat information based on the targeted entity.
- **Impact**: Dynamic Threat Meter Display: Updates to display and highlight the threat level of targeted entities.

### Updated UpdateThreatTrackerEntries Method
- **Description**: Revised to update threat levels or add new entries to threatTrackerEntries.
- **Impact**: Flexible Threat Level Management: Real-time adjustment of threat levels.

### ThreatEntry Class (Assumed Existing or Added)
- **Description**: Represents a threat with properties for the entity and its threat level.
- **Impact**: Structured Threat Representation: Encapsulates information about entities and their threat levels.

### Integration with HostileTargetEntityOutline
- **Description**: Utilized for visually highlighting targeted hostile entities.
- **Impact**: Visual Highlighting Integration: For clear visual indication of targeted entities.

### Adjustments in CalculateThreat Method
- **Description**: Enhanced threat level calculation based on game dynamics.
- **Impact**: Improved Threat Calculation Logic: Nuanced threat level calculation.


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

## Contributors
1. MrJambix
2. Bardcore (Original Creator of DPS/Exp Tracker)
3. Knowledge/Ryan

## Disclaimer
This addon is not officially endorsed by Ethyrial Echoes of Yore. Use at your own risk. Modifications to game files can be against the terms of service of many games. The authors of this addon are not responsible for any consequences that arise from its use.
