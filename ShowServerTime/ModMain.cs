using MelonLoader;
using UnityEngine;
using Il2CppTMPro;
using UnityEngine.UI;
using System;
using Il2Cpp;
using System.Linq;

namespace ShowServerTime;

/// <summary>
/// Main mod class that handles the server time display functionality.
/// This mod adds a text display showing the current server time
/// below the server name display.
/// </summary>
public class ModMain : MelonMod
{
    public const string ModVersion = "1.0.0";
    
    // UI Elements
    private static GameObject textObject;        // The GameObject that holds our text display
    private static TextMeshProUGUI textMeshPro;  // The TextMeshPro component for rendering text
    private static float updateInterval = 1.0f;  // Update interval in seconds
    private static float timeSinceLastUpdate = 0f;

    /// <summary>
    /// Called every frame
    /// </summary>
    public override void OnUpdate()
    {
        if (textMeshPro != null)
        {
            timeSinceLastUpdate += Time.deltaTime;
            if (timeSinceLastUpdate >= updateInterval)
            {
                UpdateTimeDisplay();
                timeSinceLastUpdate = 0f;
            }
        }
    }

    /// <summary>
    /// Updates the time display with the current server time
    /// </summary>
    private void UpdateTimeDisplay()
    {
        try
        {
            // Get the current server time from TimeController
            var hour = TimeController.previousHour;
            var minute = TimeController.previousMinute;
            
            // Format the time display
            if (textMeshPro != null)
                textMeshPro.text = $"Time: {hour:D2}:{minute:D2}";
        }
        catch (Exception)
        {
            // Silently handle any errors
        }
    }

    /// <summary>
    /// Creates the time display UI element below the server name display or compass.
    /// </summary>
    /// <param name="compassPanel">The compass panel transform to attach the text to</param>
    public static void CreateTimeDisplay(Transform compassPanel)
    {
        // Remove the old time display if it exists
        if (textObject != null)
            GameObject.Destroy(textObject);

        // Check if the ShowServerAndShard mod is loaded
        bool hasServerNameMod = MelonMod.RegisteredMelons.Any(m => m.Info.Name == "ShowServerAndShard");
        // Default parent is the compass panel
        Transform parentTransform = compassPanel;
        // Default position: 5 units below the compass (matches server name mod default)
        Vector2 anchoredPosition = new Vector2(0, -5);

        if (hasServerNameMod)
        {
            // Try to find the server name text object as a child of the compass panel
            var serverNameObj = compassPanel.Find("InfoPanelText");
            if (serverNameObj != null)
            {
                // If found, parent the time display to the server name text
                parentTransform = serverNameObj;
                // Place the time display right below the server name (0 units offset)
                anchoredPosition = new Vector2(0, 5);
            }
        }

        // Create a new GameObject for the time display
        textObject = new GameObject("TimeDisplay");
        // Set its parent to either the compass panel or the server name text
        textObject.transform.SetParent(parentTransform, false);

        // Add and configure the TextMeshPro component for rendering the time
        textMeshPro = textObject.AddComponent<TextMeshProUGUI>();
        textMeshPro.text = "Time: 00:00";
        textMeshPro.fontSize = 12;
        textMeshPro.color = Color.yellow;
        textMeshPro.alignment = TextAlignmentOptions.Center;

        // Set up the RectTransform to position the text correctly
        RectTransform rectTransform = textMeshPro.rectTransform;
        rectTransform.anchorMin = new Vector2(0.5f, 0f);  // Anchor to bottom center
        rectTransform.anchorMax = new Vector2(0.5f, 0f);
        rectTransform.pivot = new Vector2(0.5f, 1f);      // Pivot at top center
        rectTransform.anchoredPosition = anchoredPosition; // Vertical offset
        rectTransform.sizeDelta = new Vector2(400, 20);   // Set width and height
    }
} 