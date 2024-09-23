using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdvancedImage : Image
{
    [SerializeField] private float hitTestMinimumThreshold = .1f;
    //protected override void OnValidate()
    //{
    //    base.OnValidate();
    //    alphaHitTestMinimumThreshold = hitTestMinimumThreshold;
    //}

    protected override void Awake()
    {
        base.Awake();
        alphaHitTestMinimumThreshold = hitTestMinimumThreshold;
    }
}