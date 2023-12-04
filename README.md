![ThreatMeter](https://github.com/MrJambix/Ethyrial_Addon/assets/131601090/fb168b83-1c9e-4a4d-836d-b4dad5d4a381)
![TM](https://github.com/MrJambix/Ethyrial_Addon/assets/131601090/adee599c-a89c-4376-8f42-53580cf18291)


# Ethyrial_Addon
# **Install Instructions: **
1. Find your Steam\steamapps\common\Ethyrial Echoes of Yore\Ethyrial_Data\Managed
2. Make a Folder on your Deskopt and Call it DLL_BackUp
3. Grab the Game.DLL from the Managed folder and place it in your newly created DLL_BackUp
4. Download the .DLL file from the respository and insert it ->Steam\steamapps\common\Ethyrial Echoes of Yore\Ethyrial_Data\Managed<-
5. Launch the Game!

# **Deleting Instructions: **
1. Find your Steam\steamapps\common\Ethyrial Echoes of Yore\Ethyrial_Data\Managed
2. Delete the Game.DLL
3. Place your backup Game.DLL
4. If you did not save your back up then simply head to Steam > Right Click Ethyrial> Properties > Verify Game Integrity. The Game will give you it's original Game.DLL


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
