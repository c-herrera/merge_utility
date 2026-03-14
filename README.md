## merge_utility

![Static Badge](https://img.shields.io/badge/csharp-blue?style=for-the-badge&logo=sharp&labelColor=000000)

<img src="https://github.com/c-herrera/merge_utility/blob/master/mainscreen.png" height="50%" width="50%" />

Project refresh of the merge utility tool (CREAte Merge)  used in Intel validation and testing labs for the VPG project
that was validated at GDC (Guadalajara Design Center)

Main tool was created to simplify the process of "stitching" the main uefi bios firmware and the graphics output protocol

Usage :

1. Select a platform (SKL, CNL, etc)
2. Select a video protocol (GOP, VBIOS)
3. Select a BIOS version
4. Select displays (physical display) to use
5. Hit merge
6. Flash and use


Compared to old tool

* Uses config file to save platform data instead of guessing
* Reworked code for common platforms (gen 6 onwwards)
* More light in resources
* Aim for smooth updates


**Update : 2025**


This project is archived, since the VPG project is no longer in GDC so 
I'm going to left this here, maybe I'll return to it from time to time
