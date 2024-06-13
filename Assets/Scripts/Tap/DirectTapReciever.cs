using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectTapReciever : MonoBehaviour, ITappable
{
    [SerializeField] private GameObjectPool CardPool;

    void Start() {
        this.CardPool.Initialize();
    }
    private void RequestPoolable() {
 
        if (this.CardPool.HasObjectAvailable(1)) {
            this.CardPool.RequestPoolable();
        }
    }
    public void OnTap(TapEventArgs args) {
        this.RequestPoolable();
    }
}
