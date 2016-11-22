# ProjectZomboidSaveEditor
Editor save game options for Project Zomboid 34.28

Default savefile path: 
C:\Users\%username%\Zomboid\Saves\Sandbox\%savename%\map_sand.bin

You can open this file in Sublime Text with UTF-8 encoding or AkelPad and check the file structure.
You can change options by this way and it will work.

Backup your save first, it WILL damage it.
Use the logic. 
Set "start year" like "2050" for save in 2020 - it is a BAD idea.
Here is no protection for bad options, only the admissible range of values is set.

Parameters related to the existing objects will not be changed immediately.
This means that if you change the farm speed it will be applied only to the following plants.

I do not know why we need a prefix to the parameters, 
because it is not a problem to parse the numeric value without them.
Nevertheless, they are.
These changes are not amenable to logical understanding or any systematization 
and this sometimes causes difficulties.

If you hear beeps while loading the save here is an errors.
One beep - light damage, which will be corrected by the engine, changes will be applied.
Three beeps - prefix damage or incorrect parameter format which will be corrected by default value.
Constant beeps - parameters can not be read, the file will be overwritten completely by default.

Advanced parameters can call three beeps, but changes will be applied.
This is due to a change of a prefix that will be corrected by the engine without losses.

Additionally, if you load the correct save at least once, then you will leave in the menu of a game 
and then will make changes - in case of errors the previous values will be restored.
If you just load the incorrect file, the value will be replaced by default.

In any case, always check the file structure and have the backup.
