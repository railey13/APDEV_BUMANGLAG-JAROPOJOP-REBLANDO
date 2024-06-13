using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DockHandler : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]private List<int> dockedCards = new List<int> { };

    public List<int> DockedCards
    {
        get { return dockedCards; }
    }

    public  void Adding(int card)
    {
        dockedCards.Add(card);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
