using UnityEngine;
using UnityEditor;
using System.IO;
using System.Diagnostics;

public class OpenInPhotoshop : Editor
{
    // Update this path to match your installed version of Photoshop on Windows
    private const string windowsPhotoshopPath = @"C:\Program Files\Adobe\Adobe Photoshop 2026\Photoshop.exe";

    [MenuItem("Assets/Open with Photoshop", false, 1)]
    private static void OpenFile()
    {
        string assetPath = AssetDatabase.GetAssetPath(Selection.activeObject);
        string fullPath = Path.GetFullPath(assetPath);

#if UNITY_EDITOR_OSX
        // Update this path if you are using a different version (e.g., 2023)
        string macPhotoshopPath = "/Applications/Adobe Photoshop 2026/Adobe Photoshop 2026.app";
        
        if (Directory.Exists(macPhotoshopPath))
        {
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = "open",
                // Targeting the exact .app path ensures the file argument isn't dropped
                Arguments = $"-a \"{macPhotoshopPath}\" \"{fullPath}\"",
                UseShellExecute = false
            };
            Process.Start(startInfo);
        }
        else
        {
            UnityEngine.Debug.LogError($"Photoshop not found at: {macPhotoshopPath}. Please check your Applications folder and update the path in the script.");
        }
#elif UNITY_EDITOR_WIN
        // On Windows, we launch the executable directly
        if (File.Exists(windowsPhotoshopPath))
        {
            Process.Start(windowsPhotoshopPath, $"\"{fullPath}\"");
        }
        else
        {
            UnityEngine.Debug.LogError($"Photoshop not found at: {windowsPhotoshopPath}. Please update the windowsPhotoshopPath variable.");
        }
#endif
    }

    // This validation function ensures the menu item only appears/is clickable for images
    [MenuItem("Assets/Open with Photoshop", true)]
    private static bool ValidateOpenFile()
    {
        if (Selection.activeObject == null) return false;

        string path = AssetDatabase.GetAssetPath(Selection.activeObject);
        string ext = Path.GetExtension(path).ToLower();

        // Check against common image and texture formats
        return ext == ".png" || 
               ext == ".jpg" || 
               ext == ".jpeg" || 
               ext == ".psd" || 
               ext == ".tga" || 
               ext == ".tif" || 
               ext == ".tiff" || 
               ext == ".bmp" || 
               ext == ".exr";
    }
}