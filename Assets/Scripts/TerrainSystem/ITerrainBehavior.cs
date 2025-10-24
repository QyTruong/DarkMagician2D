using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITerrainBehavior
{
    void Setup(Terrain terrain);
    void Execute(Terrain terrain);
}
