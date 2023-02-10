using UnityEditor;
using UnityEngine;

public class StoreWindow : EditorWindow
{
    private const string WINDOW_NAME = "Shop";
    private const int PADDING = 10;

    private StoreData _storeData;
    private IStoreDataProvider _storeDataProvider = new StoreDataProvider();

    private Vector2 _scrollPosition;
    private Color _backgroundColor = new Color(0.37f, 0.37f, 0.37f);
    private GUIStyle _scrollBackgroundStyle
    {
        get
        {
            GUIStyle scrollStyle = new GUIStyle();
            scrollStyle.normal.background = ImageUtils.ColorToTexture(_backgroundColor);

            return scrollStyle;
        }
    }

    [MenuItem("Tools/" + WINDOW_NAME)]
    public static void OpenWindow() => GetWindow<StoreWindow>(WINDOW_NAME);

    private void OnGUI()
    {
        GUILayout.BeginArea(EditorWindowUtils.GetArea(position, PADDING));

        _storeData = _storeDataProvider.GetStoreData();

        if (!_storeData) return;

        if (GUILayout.Button("Add item", GUILayout.Width(140), GUILayout.Height(25)))
            _storeData.AddItem();

        GUILayout.Space(15);

        _scrollPosition = GUILayout.BeginScrollView(_scrollPosition, _scrollBackgroundStyle);

        foreach (StoreItem storeItem in _storeData.StoreItems.ToArray())
        {
            DrawStoreItem(storeItem);
            GUILayout.Space(15);
        }

        GUILayout.EndScrollView();

        GUILayout.EndArea();
    }

    private void DrawStoreItem (StoreItem storeItem)
    {
        storeItem.Name = EditorGUILayout.TextField("Name", storeItem.Name);
        storeItem.Price = EditorGUILayout.IntField("Price", storeItem.Price);
        EditorWindowUtils.CreateObjectField(ref storeItem.Icon, "Icon");
        EditorWindowUtils.CreateObjectField(ref storeItem.Prefab, "Prefab");

        GUILayout.Space(5);

        if (GUILayout.Button("Remove", GUILayout.Width(100), GUILayout.Height(25)))
            _storeData.StoreItems.Remove(storeItem);
    }

}
