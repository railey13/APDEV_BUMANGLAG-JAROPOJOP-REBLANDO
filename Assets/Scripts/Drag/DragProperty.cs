using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class DragProperty 
{
    [Tooltip("Minimum allowable time to be considered a drag")]
    [SerializeField] private float time = 0.8f;



    public float Time
    {
        get { return this.time; }
        set { this.time = value; }
    }

  
}

