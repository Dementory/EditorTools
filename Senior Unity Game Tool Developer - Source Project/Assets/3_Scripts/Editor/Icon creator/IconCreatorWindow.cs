using UnityEditor;
using UnityEngine;

namespace EditorTool.Editor.IconCreator
{
    public class IconCreatorWindow : EditorWindow
    {
        private const string WINDOW_NAME = "Icon creator";
        private const int PADDING = 10;

        IconData _iconData = new IconData(null, Vector3.zero, new Color(1, 1, 1, 1), new Vector2(100, 60), new Color(1, 1, 1, 1), 1);
        private Texture2D _icon;

        private IIconCreator _iconCreator = new IconCreator();

        [MenuItem("Tools/" + WINDOW_NAME)]
        public static void OpenWindow() => GetWindow<IconCreatorWindow>(WINDOW_NAME);

        private void OnGUI()
        {
            GUILayout.BeginArea(EditorWindowUtils.GetArea(position, PADDING));

            GUILayout.Label("Model", EditorWindowUtils.BoldStyle);
            EditorWindowUtils.CreateObjectField(ref _iconData.ModelPrefab, "Model Reference");
            _iconData.ModelPositionOffset = EditorGUILayout.Vector3Field("Position offset", _iconData.ModelPositionOffset);

            GUILayout.Space(10);

            GUILayout.Label("Background", EditorWindowUtils.BoldStyle);
            _iconData.BackgroundColor = EditorGUILayout.ColorField("Background color", _iconData.BackgroundColor);

            GUILayout.Space(10);

            GUILayout.Label("Light", EditorWindowUtils.BoldStyle);
            _iconData.LightRotation = EditorGUILayout.Vector2Field("Light rotation", _iconData.LightRotation);
            _iconData.LightColor = EditorGUILayout.ColorField("Light color", _iconData.LightColor);
            _iconData.LightIntensity = EditorGUILayout.FloatField("Light intensity", _iconData.LightIntensity);

            GUILayout.Space(10);

            if (GUILayout.Button("Create"))
                _iconCreator.SaveIcon(_iconData);

            PreviewIcon();

            GUILayout.EndArea();
        }

        private void PreviewIcon()
        {
            _icon = _iconCreator.CreateIcon(_iconData);
            GUILayout.Box(_icon);
        }

    }
}
