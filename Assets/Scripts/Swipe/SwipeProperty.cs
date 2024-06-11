using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class SwipeProperty
{
    [Tooltip("Maximum allowable time to be considered a swipe")]
    [SerializeField] private float time = 2.0f;



    public float Time
    {
        get { return this.time; }
        set { this.time = value; }
    }

    [Tooltip("Minimum allowable distance to be considered a swipe")]
    [SerializeField] private float minDistance = 0.7f;

    public float MinDistance
    {
        get { return this.minDistance; }
        set { this.minDistance = value; }
    }
}

