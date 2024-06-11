using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapEventArgs : EventArgs 
{
    private Vector2 position;

    public Vector2 Position
    {
        get { return this.position; }
        set { this.position = value; }
    }

    private GameObject hitObject;

    public GameObject HitObject
    {
        get { return this.hitObject; }
    }

    public TapEventArgs(Vector2 position, GameObject hitObject = null)
    {
        this.position = position;
        this.hitObject = hitObject;
    }   
}
