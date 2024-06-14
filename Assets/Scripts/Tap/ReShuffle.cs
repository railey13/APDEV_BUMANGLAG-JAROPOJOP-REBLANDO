using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReShuffle : MonoBehaviour, ITappable 
{
    [SerializeField] private CardList CardList;

    [SerializeField] private GameObjectPool CardPool;

    private void ReleasePoolable() 
    {
        this.CardPool.ReleasePoolableBatch(this.CardList.inCardListNum);
    }

    public void OnTap(TapEventArgs args) 
    {
        this.ReleasePoolable();
        this.CardList.ReShuffle();
    }
}
