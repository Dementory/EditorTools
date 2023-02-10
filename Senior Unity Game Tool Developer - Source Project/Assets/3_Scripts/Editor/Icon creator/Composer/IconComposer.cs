using UnityEngine;

public class IconComposer : IIconComposer
{
    private const string ICON_LAYER_NAME = "Icon";
    private int _layer => LayerMask.NameToLayer(ICON_LAYER_NAME);

    private GameObject _model;
    private Camera _camera;
    private GameObject _lightObject;

    private IconData _iconData;

    public void Compose(IconData iconData, out Camera camera)
    {
        _iconData = iconData;

        SetUpModel();

        _camera = CreateCamera();
        camera = _camera;

        ColorBackground();
        SpawnLight();
    }

    private Camera CreateCamera()
    {
        Vector3 modelSize = MeshUtils.GetSkinnedMeshRendererSize(_model);

        GameObject cameraObject = new GameObject("Icon camera");

        float distance = Mathf.Max(modelSize.x, modelSize.y) * 2;
        float height = modelSize.z / 2;
        cameraObject.transform.position = new Vector3(0, height, distance) + _iconData.ModelPositionOffset;
        cameraObject.transform.rotation = Quaternion.LookRotation(GetLookDirection());

        Camera camera = cameraObject.AddComponent<Camera>();
        camera.cullingMask = 1 << _layer;

        return camera;

        Vector3 GetLookDirection() => _model.transform.position + new Vector3(0, modelSize.z / 2, 0) - cameraObject.transform.position;
    }

    private void SetUpModel()
    {
        _model = GameObject.Instantiate(_iconData.ModelPrefab, Vector3.zero, Quaternion.identity);

        _model.layer = _layer;
        _model.transform.DoToAllChildren(child => child.gameObject.layer = _layer);
    }

    private void ColorBackground()
    {
        _camera.clearFlags = CameraClearFlags.SolidColor;
        _camera.backgroundColor = _iconData.BackgroundColor;
    }

    private void SpawnLight()
    {
        _lightObject = new GameObject("Icon light");
        _lightObject.transform.rotation = Quaternion.Euler(_iconData.LightRotation);

        Light light = _lightObject.AddComponent<Light>();
        light.type = LightType.Directional;
        light.color = _iconData.LightColor;
        light.intensity = _iconData.LightIntensity;
        light.cullingMask = 1 << _layer;
    }

    public void Clear()
    {
        GameObject.DestroyImmediate(_camera.gameObject);
        GameObject.DestroyImmediate(_model);
        GameObject.DestroyImmediate(_lightObject);
    }
}
