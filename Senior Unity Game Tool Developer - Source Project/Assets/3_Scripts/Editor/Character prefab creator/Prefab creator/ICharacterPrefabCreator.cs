using UnityEditor.Animations;
using UnityEngine;

public interface ICharacterPrefabCreator
{
    void CreatePrefab(GameObject modelPrefab, AnimatorController animatorController, Material material);
}
