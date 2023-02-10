using UnityEngine;

public interface IScreenshotCapture
{
    Texture2D CaptureScreen(Camera camera, int width, int height, int depth);
}
