using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragReciever : MonoBehaviour
{ 
   
    // Start is called before the first frame update
    
    public void OnDrag(object sender,DragEventArgs arg)
    {
        Debug.Log("Pick Me Up!");
    }
    void Start()
    {
        GestureManager.Instance.OnDrag += this.OnDrag;
    }

    // Update is called once per frame
    void OnDisable()
    {
        GestureManager.Instance.OnDrag -= this.OnDrag;
    }
}
