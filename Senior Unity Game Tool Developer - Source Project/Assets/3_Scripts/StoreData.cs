using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[CreateAssetMenu(fileName = "StoreData", menuName = "Databases/Store")]
public class StoreData : ScriptableObject
{
    public List<StoreItem> StoreItems;

    public void RemoveItem(StoreItem storeItem) => StoreItems.Remove(storeItem);

    public void AddItem(StoreItem storeItem = null)
    {
        storeItem = storeItem ?? new StoreItem();

        storeItem.Id = GetUniqueId(StoreItems.Count - 1);

        StoreItems.Add(storeItem);
    }

    private int GetUniqueId(int id)
    {
        List<StoreItem> itemsWithSameId = StoreItems.Where(item => item.Id == id).ToList();

        if (itemsWithSameId.Count > 0)
            id = GetUniqueId(id + 1);

        return id;
    }
}
