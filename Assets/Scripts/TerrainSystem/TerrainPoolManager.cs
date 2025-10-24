using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainPoolManager : MonoBehaviour
{
    private static TerrainPoolManager instance;
    public static TerrainPoolManager Instance { get => instance; }

    private Dictionary<GameObject, TerrainPool> dictPools = new Dictionary<GameObject, TerrainPool>();

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    public GameObject GetFromPool(GameObject obj, Vector3 position)
    {
        if (!dictPools.ContainsKey(obj))
        {
            dictPools.Add(obj, new TerrainPool(obj));
        }

        return dictPools[obj].SpawnTerrain(position);
    }
}
