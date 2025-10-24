using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainSpawner : MonoBehaviour
{
    [SerializeField] private GameObject prefab;

    private void Update()
    {
        
    }

    private IEnumerator spawnAfter()
    {
        yield return new WaitForSeconds(1.5f);
        TerrainPoolManager.Instance.GetFromPool(prefab, transform.position);
    }
}
