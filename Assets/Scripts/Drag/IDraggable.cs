using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDraggable
{
    public void OnDrag(DragEventArgs arg);
    virtual void OnRelease(DragEventArgs arg) { }
}
