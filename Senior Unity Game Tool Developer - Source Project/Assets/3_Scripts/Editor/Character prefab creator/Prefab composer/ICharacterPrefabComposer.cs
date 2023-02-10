using UnityEditor.Animations;
using UnityEngine;

namespace EditorTool.Editor.PrefabCreator
{
    public interface ICharacterPrefabComposer
    {
        void Compose(GameObject model, Vector3 modelSize, AnimatorController animatorController, Material material);
    }
}
