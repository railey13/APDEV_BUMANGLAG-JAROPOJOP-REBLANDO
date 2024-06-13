using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardPoolable : APoolable{
    [SerializeField] private CardList cardList;

    [SerializeField] private string CardName;

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
            this.CardName = card.material.name;

            string[] words = this.CardName.Split(' ');

            this.CardName = words[0];
            Debug.Log(words[0]);
        }
    }

    public override void Initialize() {

    }
    public override void OnActivate() {
        this.SetCard();
        this.transform.localPosition = new Vector3(this.originPos.x, this.originPos.y, this.originPos.z - this.order);

        CardHandler cardHandler = GetComponent<CardHandler>();

        if (cardHandler != null){
            cardHandler.NameGetter(this.CardName);
        }

        
    }
    public override void Release() {

    }
}
