using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeReciever : MonoBehaviour
{
    
    public void OnSwipe(object sender , SwipeEventArgs args)
    {
        //Debug.Log("Detected Swipe");
    }

    void Start()
    {
        GestureManager.Instance.OnSwipe += this.OnSwipe;
    }

    // Update is called once per frame
    void OnDisable()
    {
       GestureManager.Instance.OnSwipe -= this.OnSwipe;
    }
}

