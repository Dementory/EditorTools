using UnityEngine;

public class ScreenshotCapture : IScreenshotCapture
{
    public Texture2D CaptureScreen(Camera camera, int width, int height, int depth)
    {
        RenderTexture renderTexture = new RenderTexture(width, height, depth);
        Rect rect = new Rect(0, 0, width, height);
        Texture2D texture = new Texture2D(width, height, TextureFormat.RGBA32, false);

        camera.targetTexture = renderTexture;
        camera.Render();

        RenderTexture currentRenderTexture = RenderTexture.active;
        RenderTexture.active = renderTexture;
        texture.ReadPixels(rect, 0, 0);
        texture.Apply();

        camera.targetTexture = null;
        RenderTexture.active = currentRenderTexture;
        GameObject.DestroyImmediate(renderTexture);

        return texture;
    }
}
