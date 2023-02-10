using UnityEditor;
using UnityEditor.Animations;
using UnityEngine;

namespace EditorTool.Editor.PrefabCreator
{
    public class CharacterPrefabCreator : ICharacterPrefabCreator
    {
        private ICharacterPrefabComposer _prefabComposer = new CharacterPrefabComposer();

        public void CreatePrefab(GameObject modelPrefab, AnimatorController animatorController, Material material)
        {
            GameObject model = GameObject.Instantiate(modelPrefab);
            Vector3 size = MeshUtils.GetSkinnedMeshRendererSize(model);

            string saveFolder = EditorUtility.OpenFolderPanel("Choose save folder", "", "");
            string filePath = $"{saveFolder}/{model.gameObject.name}.prefab";

            _prefabComposer.Compose(model, size, animatorController, material);

            PrefabUtility.SaveAsPrefabAsset(model, filePath, out _);

            GameObject.DestroyImmediate(model);
        }
    }
}
