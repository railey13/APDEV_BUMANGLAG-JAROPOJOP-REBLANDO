using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Build.Content;
using UnityEngine;

public class StackingCards : MonoBehaviour, IStackable
{
    [SerializeField] public CardValue cardValue;
    [SerializeField] private bool isConnected = false;

    [SerializeField] private GameObject bedCard;

    // Start is called before the first frame update
    void Start()
    {

        //Debug.Log(this.name + " is Red? " + this.cardValue.IsRed);
    }

    // Update is called once per frame
    void Update()
    {
        if (this.isConnected && bedCard != null)
        {
            this.gameObject.transform.position = bedCard.transform.position + Vector3.down * 0.5f + Vector3.back * 0.1f;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        
    }

    public void OnStack(GameObject bed)
    {
        this.isConnected = true;
        this.bedCard = bed;
    }

    public bool CanStack(GameObject bed)
    {
        bool isStackable = false;
        StackingCards collidedCard = bed.GetComponent<StackingCards>();
        if (collidedCard != null)
        {
            CardValue collidedCardValue = collidedCard.cardValue;
            if (collidedCardValue.IsRed != this.cardValue.IsRed &&
                collidedCardValue.Value == this.cardValue.Value + 1)
            {
                //Debug.Log("Can stack!");
                isStackable = true;
            }
            else if (this.cardValue.Value == 13 && collidedCardValue.Value == 14) isStackable = true;
        }

        return isStackable;
    }
}
