using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ModelOptimizationPostProcessor : AssetPostprocessor
{
    void OnPostprocessModel(GameObject model)
    {
        ModelImporter importer = assetImporter as ModelImporter;
        importer.importCameras = false;
        importer.importLights = false;
        importer.meshCompression = ModelImporterMeshCompression.Low;

        Object asset = AssetDatabase.LoadAssetAtPath(importer.assetPath, typeof(Object));
        if (asset)
            EditorUtility.SetDirty(asset);
    }
}
