using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DockHandler : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]private List<int> dockedCards = new List<int> { };

    public List<int> DockedCards
    {
        get { return this.dockedCards; }
    }

    public  void Adding(int card)
    {
        this.dockedCards.Add(card);
    }

    public void Removal(int card)
    {
        this.dockedCards.Remove(card);

    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
