using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardPoolable : APoolable{
    [SerializeField] private CardList cardList;

    private Material cardType;
    private Vector3 originPos;

    private float order;
    private void Awake() {
        this.originPos = this.transform.position;
    }
    public void SetCard() {
        this.order = this.cardList.Order() * 0.01f;
        this.cardType = this.cardList.CardSelector();

        MeshRenderer card = GetComponent<MeshRenderer>();

        if (card != null) {
            card.material = this.cardType;
        }
    }

    public override void Initialize() {

    }
    public override void OnActivate() {
        this.SetCard();
        this.transform.localPosition = new Vector3(this.originPos.x, this.originPos.y, this.originPos.z - this.order);
    }
    public override void Release() {

    }
}
