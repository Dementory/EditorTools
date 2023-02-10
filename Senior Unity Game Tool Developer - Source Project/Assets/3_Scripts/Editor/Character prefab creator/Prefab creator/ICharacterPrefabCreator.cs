using UnityEditor.Animations;
using UnityEngine;

namespace EditorTool.Editor.PrefabCreator
{
    public interface ICharacterPrefabCreator
    {
        void CreatePrefab(GameObject modelPrefab, AnimatorController animatorController, Material material);
    }
}
