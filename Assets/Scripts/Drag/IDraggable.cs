using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDraggable
{
    public void OnDrag(DragEventArgs arg);
    virtual public void OnRelease(DragEventArgs arg) { }
}
