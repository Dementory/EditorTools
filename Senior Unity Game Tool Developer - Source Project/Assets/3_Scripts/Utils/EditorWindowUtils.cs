using UnityEditor;
using UnityEngine;

public class EditorWindowUtils
{
    public static GUIStyle BoldStyle
    {
        get
        {
            GUIStyle boldStyle = new GUIStyle();
            boldStyle.normal.textColor = Color.white;
            boldStyle.fontStyle = FontStyle.Bold;

            return boldStyle;
        }
    }

    public static void CreateObjectField<T>(ref T value, string label) where T : Object
    {
        GUILayout.BeginHorizontal();

        GUILayout.Label(label);
        value = EditorGUILayout.ObjectField(value, typeof(T), true) as T;

        GUILayout.EndHorizontal();
    }

    public static Rect GetArea(Rect position, int paddingValue)
    {
        RectOffset padding = new RectOffset(paddingValue, paddingValue, paddingValue, paddingValue);
        Rect area = new Rect(padding.right, padding.top, position.width - (padding.right + padding.left), position.height - (padding.top + padding.bottom));

        return area;
    }
}
