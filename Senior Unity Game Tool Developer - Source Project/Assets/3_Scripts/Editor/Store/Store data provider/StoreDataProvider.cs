using UnityEngine;

public class StoreDataProvider : IStoreDataProvider
{
    private const string DATABASES_PATH = "Databases/Store/StoreData";

    public StoreData GetStoreData() => (StoreData)Resources.Load(DATABASES_PATH);
}
