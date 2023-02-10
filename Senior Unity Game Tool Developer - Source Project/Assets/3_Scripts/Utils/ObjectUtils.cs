using System;
using UnityEngine;

public static class ObjectUtil
{
    public static T AddComponentIfDoesntExist<T>(this GameObject gameObject) where T : Component
    {
        if (!gameObject.TryGetComponent(out T component))
            component = gameObject.AddComponent<T>();

        return component;
    }

    public static void DoToAllChildren(this Transform transform, Action<Transform> DoToChild)
    {
        foreach(Transform child in transform)
        {
            DoToChild(child);
            DoToAllChildren(child, DoToChild);
        }
    }
}
