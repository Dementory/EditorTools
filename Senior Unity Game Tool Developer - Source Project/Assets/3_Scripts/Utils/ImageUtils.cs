using UnityEngine;

public class ImageUtils
{
    public static Texture2D ColorToTexture(Color color)
    {
        Texture2D texture = new Texture2D(1, 1, TextureFormat.RGBA32, false);
        texture.SetPixel(0, 0, color);
        texture.Apply();

        return texture;
    }
}
