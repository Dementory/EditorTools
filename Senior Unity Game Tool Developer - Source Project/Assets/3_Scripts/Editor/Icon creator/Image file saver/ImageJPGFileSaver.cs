using UnityEditor;
using UnityEngine;

public class ImageJPGFileSaver : ImageFileSaver
{
    protected override string FileExtention => "jpg";

    public override void SaveImage(Texture2D image, string filePath)
    {
        base.SaveImage(image, filePath);

        var bytes = image.EncodeToJPG();

        System.IO.File.WriteAllBytes(filePath, bytes);

        AssetDatabase.Refresh();
    }
}
