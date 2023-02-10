using UnityEditor.Animations;
using UnityEngine;

public class CharacterPrefabComposer : ICharacterPrefabComposer
{
    public void Compose(GameObject model, Vector3 modelSize, AnimatorController animatorController, Material material)
    {
        AddCollider(model, modelSize);
        AddAnimator(model, animatorController);
        AssignMaterial(model, material);
    }

    private void AddCollider(GameObject model, Vector3 size)
    {
        CapsuleCollider collider = model.AddComponentIfDoesntExist<CapsuleCollider>();

        collider.height = size.z;
        collider.radius = Mathf.Min(size.x, size.y);

        collider.center = new Vector3(0, collider.height / 2, 0);
    }

    private void AddAnimator(GameObject model, AnimatorController animatorController)
    {
        Animator animator = model.AddComponentIfDoesntExist<Animator>();

        animator.runtimeAnimatorController = animatorController;
    }

    private void AssignMaterial(GameObject model, Material material)
    {
        SkinnedMeshRenderer meshRenderer = model.GetComponentInChildren<SkinnedMeshRenderer>();

        if (!meshRenderer) return;

        Material[] materials = meshRenderer.sharedMaterials;

        for (int i = 0; i < materials.Length; i++)
            materials[i] = material;

        meshRenderer.sharedMaterials = materials;
    }
}
