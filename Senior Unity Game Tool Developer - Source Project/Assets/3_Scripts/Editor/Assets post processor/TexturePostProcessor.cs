using UnityEngine;
using UnityEditor;

public class TexturePostProcessor : AssetPostprocessor
{
    void OnPostprocessTexture(Texture2D texture)
    {
        TextureImporter importer = assetImporter as TextureImporter;
        importer.textureType = TextureImporterType.Sprite;
        importer.spriteImportMode = SpriteImportMode.Single;

        TextureImporterPlatformSettings textureSettings = importer.GetDefaultPlatformTextureSettings();
        textureSettings.format = TextureImporterFormat.RGB24;
        importer.SetPlatformTextureSettings(textureSettings);

        Object asset = AssetDatabase.LoadAssetAtPath(importer.assetPath, typeof(Object));
        if (asset)
        {
            EditorUtility.SetDirty(asset);

            EditorUtility.CompressTexture(texture, TextureFormat.RGB24, TextureCompressionQuality.Fast);
        }
    }
}
