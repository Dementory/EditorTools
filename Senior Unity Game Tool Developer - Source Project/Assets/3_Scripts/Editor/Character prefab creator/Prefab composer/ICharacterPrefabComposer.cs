using UnityEditor.Animations;
using UnityEngine;

public interface ICharacterPrefabComposer
{
    void Compose(GameObject model, Vector3 modelSize, AnimatorController animatorController, Material material);
}
