using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Unity.VisualScripting;

public class SwipeEventArgs : EventArgs
{
    private ESwipeDirection direction;

    public ESwipeDirection Direction
    {
        get { return direction; } 
    }

    public SwipeEventArgs(ESwipeDirection direction)
    {
        this.direction = direction;
    }
}
