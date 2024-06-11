using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Unity.VisualScripting;

public class DragEventArgs : EventArgs
{
    private Touch trackedFinger;
    private GameObject hitObject;

    public Touch Trackedfinger
    {
        get { return trackedFinger; }
    }

    public GameObject HitObject
    {
        get { return hitObject; }
    }


    public DragEventArgs(Touch trackedFinger,
           GameObject hitObject)
    {
        this.hitObject = hitObject;
        this.trackedFinger = trackedFinger;
    }
}
