using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackDetector : MonoBehaviour
{
    private IStackable parentStackableCard;
    private bool CanDetect = false;
    //private StackingCards parentCard;

    // Start is called before the first frame update
    void Start()
    {
        this.parentStackableCard = this.transform.parent.GetComponent<IStackable>();
        //this.parentCard = this.transform.parent.GetComponent<StackingCards>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        IStackable handler = collision.gameObject.GetComponent<IStackable>();
        StackingCards stackHandler = collision.gameObject.GetComponent<StackingCards>();
        if (handler != null && this.CanDetect)
        {
            if (parentStackableCard.CanStack(collision.gameObject))
            {
                this.parentStackableCard.OnStack(collision.gameObject);
                stackHandler.cardValue.HasChild = true;
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == "InDeckChecker") this.CanDetect = true;

        IStackable handler = collision.gameObject.GetComponent<IStackable>();
        StackingCards stackHandler = collision.gameObject.GetComponent<StackingCards>();
        if (handler != null)
        {
            stackHandler.cardValue.HasChild = false;
        }
    }
}
