using HomaGames.Internal.Utilities;
using System;
using UnityEngine;

[Serializable]
public class StoreItem
{
    public int Id;
    public string Name;
    public int Price;
    public Sprite Icon;
    public GameObject Prefab;
}

public class Store : Singleton<Store>
{
    public StoreData StoreData;
    public Action<StoreItem> OnItemSelected;

    private void Start()
    {
        if (!StoreData)
            throw new NullReferenceException("Store data isnt't assigned");
    }

    public void SelectItem(StoreItem item)
    {
        OnItemSelected?.Invoke(item);
    }
}
