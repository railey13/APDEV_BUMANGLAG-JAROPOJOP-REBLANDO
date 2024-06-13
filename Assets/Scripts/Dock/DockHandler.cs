using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DockHandler : MonoBehaviour
{
    // Start is called before the first frame update
    private List<int> dockedCards = new List<int> { };

    public List<int> DockedCards
    {
        get { return dockedCards; }
    }

    void Start()
    {
        dockedCards.Add(2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
