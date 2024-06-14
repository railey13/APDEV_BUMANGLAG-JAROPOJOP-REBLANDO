using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardPoolable : APoolable
{
    [SerializeField] private CardList cardList;

    [SerializeField] private string CardName;

    private Material cardType;
    private Vector3 originPos;

    private float order;

    private int suitType = 0;
    private int valueType = 0;

    private bool colorType = false;

    public float Order 
    {
        get { return order; }
    }
    private void Awake() 
    {
        this.originPos = this.transform.position;
    }
    public void SetCard() 
    {
        this.order = this.cardList.Order() * 0.01f;
        this.cardType = this.cardList.CardSelector();

        MeshRenderer card = GetComponent<MeshRenderer>();
        StackingCards cardStack = GetComponent<StackingCards>();
        CardHandler cardHandler = GetComponent<CardHandler>();

        if (card != null) 
        {
            card.material = this.cardType;
            this.CardName = card.material.name;

            string[] words = this.CardName.Split(' ');

            this.CardName = words[0];
            Debug.Log(words[0]);

            string cardName = this.CardName;

            char nametest = cardName[0];
            switch (nametest) 
            {
                case 'H':
                    this.suitType = 1;
                    this.colorType = true;
                    break;
                case 'D':
                    this.suitType = 2;
                    this.colorType = true;
                    break;
                case 'C':
                    this.suitType = 3;
                    this.colorType = false;
                    break;
                case 'S':
                    this.suitType = 4;
                    this.colorType = false;
                    break;
            }
            string valTest = cardName.Substring(1);
            this.valueType = Convert.ToInt32(valTest);

            cardHandler.NameGetter(this.valueType, this.suitType);
            cardStack.SetColor_Value(this.colorType, this.valueType);
        }
    }

    public override void Initialize() 
    {

    }
    public override void OnActivate() 
    {
        this.SetCard();
        this.transform.localPosition = new Vector3(this.originPos.x, this.originPos.y, this.originPos.z - this.order);
    }
    public override void Release() 
    {

    }
}





