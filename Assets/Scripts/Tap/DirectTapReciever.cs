using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectTapReciever : MonoBehaviour, ITappable
{
   public void OnTap(TapEventArgs args)
    {
        Destroy(this.gameObject);
    }
}
