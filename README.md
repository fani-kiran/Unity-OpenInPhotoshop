A lightweight Unity Editor tool that adds a custom context menu option to instantly open selected image and texture assets directly in Adobe Photoshop. It supports both macOS and Windows.


1. How to Install

Download the OpenInPhotoshop.cs script.
Open your Unity project.
Drag and drop the downloaded OpenInPhotoshop.cs file into your Editor folder.
Wait a moment for Unity to recompile the scripts.


2. How to Change the Photoshop Path

The script relies on default paths to find the Photoshop application. If you are using a different version (like 2026 or Beta) or installed it on a non-standard drive, you will need to update the path variables in the downloaded script.
Double-click OpenInPhotoshop.cs in Unity to open it in your code editor and make the following adjustments based on your OS:
For macOS Users

Locate the macPhotoshopPath variable inside the OpenFile() method:

string macPhotoshopPath = "/Applications/Adobe Photoshop 2026/Adobe Photoshop 2026.app";

Update the year or folder name to match the exact .app file located in your Applications folder. Save the script when finished.
For Windows Users

Locate the windowsPhotoshopPath variable near the top of the class:

private const string windowsPhotoshopPath = @"C:\Program Files\Adobe\Adobe Photoshop 2026\Photoshop.exe";

Update the drive letter or folder structure to point to the exact location of your Photoshop.exe file. Save the script when finished.


3. How to Use in the Unity Editor

Open the Project window in the Unity Editor.
Locate a supported image or texture asset (supported formats include: .png, .jpg, .psd, .tga, .tif, .bmp, .exr).
Right-click on the asset to open the context menu.

Select Open with Photoshop (usually located near the top of the menu).
Photoshop will automatically launch (if it isn't already running) and open your selected image file.

Troubleshooting: The "Open with Photoshop" option features a validation check. If you right-click on a script, 3D model, or prefab, the menu item will not appear. It is only visible when a valid image format is selected.
