[![N|Solid](http://uoavocation.net/portal/site_image/logo_05.png)](http://www.uoavocation.net)
[![N|Solid](http://uoavocation.net/portal/site_image/text_0002.png)](http://www.uoavocation.net)
***
## uoAvos-Development - `Official Release` <div align="Right">Last Updated: 03/11/2022</div>

[≡] **All Server Saves Have Been Re-Routed To The 'Export' Directory**
► So far this only affects our *server saves, log saves, the game store saves, and the book publishing saves*. In the future we plan on routing all of our saves to the 'Export/Saves/Current' directory.

[≡] **The 'Data' Folder Has Been Completely Removed From The Repo**
► We did this to limit the servers dependency to the *.cfg,  .txt, xml, .bin* files that our scripts were reading off of. In an effort to keep file contents together we have hardcoded all of the contents of the 'Data' directory into the distribution.

[≡] **This Distribution Was Patched For Visual Studio Compatibility**
► Fixed an issue where our development team was getting the following error while moving, and relocating, files from one location to another within the uoAvos.sln
- `An internal error occured. Please contact Microsoft Support.`
