[![N|Solid](http://uoavocation.net/portal/site_image/logo_05.png)](http://www.uoavocation.net)
[![N|Solid](http://uoavocation.net/portal/site_image/text_0002.png)](http://www.uoavocation.net)
***
## uoAvos-Development - `Official Release` <div align="Right">Last Updated: 04/15/2022</div>

[≡] **Introducing A Redesign How We Manage Server Regions**
► Up to now, server owners could only create and define rectangular Point2D regions on their facets. This update changes all of that because not only can we define rectangular Point2D regions as usual, but now we can create and define Poly2D and Poly3D regions as well! So instead of your regions being a simple rectangle, now you can contour them around mountains, oceans, lakes, rivers, and even cities. This system comes with a region control command which allows server owners and admin to specify region-wide rules which can be toggled on and off. In addition you can create as many parent and sub-regions as you like using this new system; each with their own different set of rules.

[≡] **Added A Staff Toolbar For Those Wishing To Run A Server**
► Commands can get hard to remember and so I found an old tool which most servers use to remedy exactly that! Joekus Toolbar has found its way onto our server distribution. You can add any command to it by assigning it to a button and then simple clicking that button to use said command moving forward. Anyway this should make things a little easier.

[≡] **Added UltimaLive To Our Distribution As A Utility For Admin**
► The entire system has been reformatted to fit a more generic place on our servers. The files are located in *'Scripts/Engines/WorldMap/Editing'*  and *'Scripts/Engine/WorldMap/Modules'*. In the *'Editing'* directory you will find the part of the system that handles facet static manipulation; this includes all commands, which now have been seperated out of the single file they were once in, and the systems engine. In the *'Modules'* directory, you will find the *'LumberHarvesting'* addon. The reason for dividing it up into these two directories was to make it easier to distinguish between the addon modules and the core system.

[≡] **All Server Saves Have Been Re-Routed To The 'Export' Directory**
► So far this only affects our *server saves, log saves, the game store saves, and the book publishing saves*. In the future we plan on routing all of our saves to the 'Export/Saves/Current' directory.

[≡] **The 'Data' Folder Has Been Completely Removed From The Repo**
► We did this to limit the servers dependency to the *.cfg,  .txt, xml, .bin* files that our scripts were reading off of. In an effort to keep file contents together we have hardcoded all of the contents of the 'Data' directory into the our distribution.

[≡] **This Distribution Was Patched For Visual Studio Compatibility**
► Fixed an issue where our development team was getting the following error while moving, and relocating, files from one location to another within the uoAvos.sln
- `An internal error occured. Please contact Microsoft Support.`
