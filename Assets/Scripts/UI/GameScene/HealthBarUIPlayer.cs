using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarUIPlayer : HealthBarUI
{
    protected override void Start()
    {
        base.Start();
        _myEntity.OnFlipped += FlipHealthBar;
    }

    private void FlipHealthBar() => _myTransform.Rotate(0, 180, 0);

    protected override void OnDisable()
    {
        base.OnDisable();
        _myEntity.OnFlipped -= FlipHealthBar;
    }
}
