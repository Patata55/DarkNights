using UnityEngine;
using UnityEngine.UI;

public class FPSDisplay : MonoBehaviour
{
    public Text fpsText;
    private float deltaTime = 0.0f;

    void Update()
    {
        // Calculate the FPS
        deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
        float fps = 1.0f / deltaTime;

        // Update the FPS text
        if (fpsText != null)
        {
            fpsText.text = "FPS: " + Mathf.Round(fps);
        }
    }
}
