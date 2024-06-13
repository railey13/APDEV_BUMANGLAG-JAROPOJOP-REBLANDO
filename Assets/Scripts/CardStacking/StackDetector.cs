using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackDetector : MonoBehaviour
{
    private IStackable parentCard;

    // Start is called before the first frame update
    void Start()
    {
        this.parentCard = this.transform.parent.GetComponent<IStackable>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        IStackable handler = collision.gameObject.GetComponent<IStackable>();
        if (handler != null)
        {
            if (parentCard.CanStack(collision.gameObject))
            {
                this.parentCard.OnStack(collision.gameObject); 
            }
        }
    }
}
