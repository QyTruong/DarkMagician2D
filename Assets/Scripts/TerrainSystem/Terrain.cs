using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Terrain : MonoBehaviour
{
    private ITerrainBehavior behavior;

    public void Initialize(ITerrainBehavior behavior)
    {
        this.behavior = behavior;
        behavior.Setup(this);
    }

    private void Update()
    {
        behavior?.Execute(this);
    }
}
