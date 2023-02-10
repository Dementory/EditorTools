using UnityEngine;

public class MeshUtils
{

    public static Vector3 GetSkinnedMeshRendererSize(GameObject model)
    {
        if (!model) return Vector3.zero;

        SkinnedMeshRenderer meshRenderer = model.GetComponentInChildren<SkinnedMeshRenderer>();
        return GetMeshSize(meshRenderer);
    }

    public static Vector3 GetMeshSize(SkinnedMeshRenderer renderer)
    {
        if (!renderer) return Vector3.zero;

        Mesh mesh = renderer.sharedMesh;

        return mesh.bounds.extents * renderer.transform.localScale.magnitude;
    }

}
