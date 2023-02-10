using UnityEditor;
using UnityEditor.Animations;
using UnityEngine;

namespace EditorTool.Editor.PrefabCreator
{
    public class CharacterPrefabCreatorWindow : EditorWindow
    {
        private GameObject _model;
        private Material _material;
        private AnimatorController _animatorController;

        private ICharacterPrefabCreator _characterPrefabCreator = new CharacterPrefabCreator();

        private const string WINDOW_NAME = "Character prefab creator";
        private const int PADDING = 10;

        [MenuItem("Tools/" + WINDOW_NAME)]
        public static void OpenWindow() => GetWindow<CharacterPrefabCreatorWindow>(WINDOW_NAME);

        private void OnGUI()
        {
            GUILayout.BeginArea(EditorWindowUtils.GetArea(position, PADDING));

            EditorWindowUtils.CreateObjectField(ref _model, "Model");
            EditorWindowUtils.CreateObjectField(ref _material, "Material");
            EditorWindowUtils.CreateObjectField(ref _animatorController, "Animator controller");

            EditorGUILayout.Space();

            if (GUILayout.Button("Create"))
                _characterPrefabCreator.CreatePrefab(_model, _animatorController, _material);

            GUILayout.EndArea();
        }

    }
}
