using UnityEngine;

namespace EditorTool.Editor.IconCreator
{
    public struct IconData
    {
        public GameObject ModelPrefab;
        public Vector3 ModelPositionOffset;
        public Color BackgroundColor;
        public Vector2 LightRotation;
        public Color LightColor;
        public float LightIntensity;

        public IconData(GameObject modelPrefab, Vector3 modelPositionOffset, Color backgroundColor, Vector2 lightRotation, Color lightColor, float lightIntensity)
        {
            ModelPrefab = modelPrefab;
            ModelPositionOffset = modelPositionOffset;
            BackgroundColor = backgroundColor;
            LightRotation = lightRotation;
            LightColor = lightColor;
            LightIntensity = lightIntensity;
        }
    }
}
