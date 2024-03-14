using UnityEngine;

public class FPSDisplay : MonoBehaviour
{
    GUIStyle style = new GUIStyle();
    Rect fpsRect;

    void Start()
    {
        // Set the style for displaying FPS
        style.fontSize = 24;
        style.normal.textColor = Color.white;

        // Set the position for displaying FPS (top left corner)
        fpsRect = new Rect(10, 10, 200, 50);
    }

    void OnGUI()
    {
        // Display the FPS cap in real-time
        GUI.Label(fpsRect, "FPS Cap: " + Application.targetFrameRate.ToString(), style);
    }
}
