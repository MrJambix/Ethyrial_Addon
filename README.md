![ThreatMeter](https://github.com/MrJambix/Ethyrial_Addon/assets/131601090/fb168b83-1c9e-4a4d-836d-b4dad5d4a381)
![TM](https://github.com/MrJambix/Ethyrial_Addon/assets/131601090/adee599c-a89c-4376-8f42-53580cf18291)
![EXPBAR](https://github.com/MrJambix/Ethyrial_Addon/assets/131601090/046e760d-f21d-48a0-ad9d-a3da453983fd)
![OtherStats](https://github.com/MrJambix/Ethyrial_Addon/assets/131601090/4b4fb22e-9346-4293-9111-9b000ec06e5e)


# Ethyrial_Addon
**Installation Instructions:**

1. **Locate your "Ethyrial Echoes of Yore" game directory:**
   - Find the directory path: `Steam\steamapps\common\Ethyrial Echoes of Yore\Ethyrial_Data\Managed`

2. **Create a Backup Folder:**
   - On your desktop, create a new folder and name it "DLL_BackUp."

3. **Back Up the Game.DLL File:**
   - From the "Managed" folder in your game directory, locate the "Game.DLL" file.
   - Copy the "Game.DLL" file and place it in the "DLL_BackUp" folder you created earlier.

4. **Download the Updated DLL:**
   - Download the updated .DLL file from the repository.

5. **Replace the Game.DLL:**
   - Insert the downloaded .DLL file into the following directory:
     `Steam\steamapps\common\Ethyrial Echoes of Yore\Ethyrial_Data\Managed`

6. **Launch the Game:**
   - You can now launch the game with the updated .DLL file.

**Uninstallation Instructions:**

1. **Locate your "Ethyrial Echoes of Yore" game directory:**
   - Find the directory path: `Steam\steamapps\common\Ethyrial Echoes of Yore\Ethyrial_Data\Managed`

2. **Delete the Game.DLL:**
   - Remove the "Game.DLL" file from the "Managed" folder.

3. **Restore the Backup (if available):**
   - If you have previously backed up the "Game.DLL" file, place it back into the "Managed" folder.

4. **No Backup? Verify Game Integrity:**
   - In case you didn't save a backup of the original "Game.DLL," you can restore it by following these steps:
     - Go to your Steam library.
     - Right-click on "Ethyrial."
     - Select "Properties."
     - Navigate to the "Local Files" tab.
     - Click "Verify Integrity of Game Files." Steam will restore the original "Game.DLL."


# **Version 2.1.2
# Changelog

#### Added
- Created the `ExperienceDisplay` script in Unity.
- Implemented references to UI Text elements for raw experience and experience percentage.
- Added a reference to the `RPGLibrary` namespace to ensure access to necessary functionality.

#### Updated
- In the `Start` method, the script now finds the local player entity within the scene.

#### Changed
- In the `Update` method, the script now updates the UI Text for raw experience with the player's current experience value.
- The script also calculates and updates the experience percentage, formatting it to two decimal places.

This script is designed to display the player's experience information in a Unity GUI, making it easier for players to track their progress in the game


# **Version 2.1.1**
# Changelog

### Added
- EXP percentage display feature to the GUI.

### Changed
- Modified the EXP bar to match the size of the "Other Stats" box.
- Adjusted the EXP bar positioning to align with the bottom of the "Other Stats" box.
- Improved the calculation of the EXP bar's `yPos` to prevent overlapping with other GUI elements.

### Fixed
- Issue where the EXP bar was not displaying due to incorrect positioning.
- Bug related to redeclaration of the `flag` variable in the EXP bar calculation, causing a compile error (CS0136).

## [Previous Version] - [Date]

- Initial release or changes from the previous version.

# **Version 2.1**
## Changelog

### Added
1. **OnExperienceChanged Method:**
   - Added a new method called `OnExperienceChanged` to handle changes in player experience.

2. **Introduced Experience Calculation:**
   - Introduced a variable `experienceForCurrentLevel` to calculate the experience required for the current player level.

### Error Handling
3. **GetExperienceForLevel Error:**
   - Encountered an error indicating that `PlayerEntityInformation` does not contain a definition for `GetExperienceForLevel`.

4. **Helper Missing Error:**
   - Encountered an error indicating that the name `Helper` does not exist in the current context.

### PlayerEntityInformation Property
5. **CurrentExperiencePercentage Property:**
   - Added a `CurrentExperiencePercentage` property to the `PlayerEntityInformation` class to calculate the current experience percentage.

### Existing Method
6. **UpdateExperienceBarUI Method:**
   - Mentioned the existence of the `UpdateExperienceBarUI` method, which handles the UI for the experience bar.

### UI Enhancement
7. **Overlap Issue Resolution:**
   - Addressed an issue where the experience bar was overlapping with other elements in the `DrawGUI` method.

### Code Cleanup
8. **Deletion of UpdateExperienceBarUI:**
   - Discussed the possibility of deleting the `UpdateExperienceBarUI` method since its functionality was incorporated into the `DrawGUI` method.

# **Version 2**
- Implemented Threat Level Calculation
  - Added a new feature to calculate the threat level of entities.
  - The calculation is now based on the percentage of an entity's threat level compared to the total threat level of all entities.
  - Example: If an entity has a threat level of 50, and the total threat level of all entities is 200, the calculation would be \((50 / 200) * 100 = 25%\).
  - This means the entity is responsible for 25% of the total threat.
-------------------------------------------------
### Version 1.0 to 1.5 Changes:
- Introduced GUI improvements.
- Implemented Resource Tracker base.
- Developed Threat Meter.
- Fixed Development Console error issue.
- Added the foundation for Dragging UI.
- Compatibility updates for different builds.
- Initial release with DPS/HPS Meter, Total Damage, and Total Heals functionality.
-------------------------------------------------
# **Version 1.5** 
- Minor Changes to GUI
- Added the base for Resource Tracker
- Worked on Threat Meter

# **Version 1.4.**
- Added ThreatMeter

# **Version 1.3**
- Fixed Issue where Development Console kept pushing errors upon craft.
- Added a base for Dragging UI

# **Version 1.2**
- Updated for Developmental Build

# **Version 1.1** 
- Updated for Current Build

# **Version 1.0**
- Addon Uploaded with the following functions:
  1. DPS/HPS Meter with Total Damage and Total Heals
-------------------------------------------------




# Contributors:
1. MrJambix
2. Bardcore (Original Creator of the DPS/Exp Tracker);Instead of replacing his UI I decided to keep it incase he returns.
3. Knowledge/Ryan
