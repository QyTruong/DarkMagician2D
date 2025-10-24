using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainPool
{
    private Stack<GameObject> pool = new Stack<GameObject>();
    private GameObject baseTerrain;
    private GameObject terrain;
    private ReturnToTerrainPool returnToPool;

    public TerrainPool(GameObject baseTerrain)
    {
        this.baseTerrain = baseTerrain;
    }

    public GameObject SpawnTerrain(Vector3 position)
    {
        if (pool.Count > 0)
        {
            terrain = pool.Pop();
            terrain.SetActive(true);
            return terrain;
        }

        terrain = GameObject.Instantiate(baseTerrain, position, Quaternion.identity);
        returnToPool = terrain.AddComponent<ReturnToTerrainPool>();
        returnToPool.pool = this;
        terrain.GetComponent<Terrain>().Initialize(terrain.GetComponent<ITerrainBehavior>());
        return terrain;
    }

    public void AddToTerrainPool(GameObject terrain)
    {
        pool.Push(terrain);
    }
}
