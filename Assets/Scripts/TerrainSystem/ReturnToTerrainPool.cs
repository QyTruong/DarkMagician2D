using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ReturnToTerrainPool : MonoBehaviour
{
    public TerrainPool pool;

    private void OnDisable()
    {
        pool.AddToTerrainPool(gameObject);
    }
}
