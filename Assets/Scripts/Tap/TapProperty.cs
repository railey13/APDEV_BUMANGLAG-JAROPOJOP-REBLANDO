using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class TapProperty
{
    [Tooltip("Maximum allowable time to be considered a tap")]
    [SerializeField] private float time = 0.7f;

    

    public float Time
    {
        get { return this.time; }
        set { this.time = value; }
    }

    [Tooltip("Maximum allowable distance to be considered a tap")]
    [SerializeField] private float maxDistance = 0.1f;

    public float MaxDistance
    {
        get { return this.maxDistance; }
        set { this.maxDistance = value; }
    }
}
