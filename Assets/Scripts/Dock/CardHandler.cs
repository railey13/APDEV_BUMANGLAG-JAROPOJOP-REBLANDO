using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CardHandler : MonoBehaviour, ISwipeable
{
    // Start is called before the first frame update

    private Vector3 targetPosition = Vector3.zero;
    private GameObject heartDock;
    private GameObject diamondDock;
    private GameObject clubDock;
    private GameObject spadeDock;
    private Renderer card;

    public int suitValue = 1;
    public int suitType = 1;
    private int end = 0;
    bool IsRevealed = false;
    bool isRed = false;

   

    

    private void ToDock(SwipeEventArgs args)
    {
        
        switch (this.suitType)
        {
            
            case 1: // heart
                if (CheckDock(this.suitType))
                {
                    this.targetPosition = this.heartDock.transform.position - new Vector3(0.0f,0.0f, end * 0.01f);
                }

                break;
            case 2: // diamond
                if (CheckDock(this.suitType))
                {
                    this.targetPosition = this.diamondDock.transform.position - new Vector3(0.0f, 0.0f, end * 0.01f);
                }
               
                break;
            case 3:// club
                if (CheckDock(this.suitType))
                {
                    this.targetPosition = this.clubDock.transform.position - new Vector3(0.0f, 0.0f, end * 0.01f);
                }
                
                break;
            case 4: // spade
                if (CheckDock(this.suitType))
                {
                    this.targetPosition = this.spadeDock.transform.position - new Vector3(0.0f, 0.0f, end * 0.01f);
                }
               
                break;

        }

    }

    private bool CheckDock(int dock)
    {
        DockHandler docked;
        switch (dock) 
        {
            case 1:
                docked = this.heartDock.GetComponent<DockHandler>();
                break;
            case 2:
                docked = this.diamondDock.GetComponent<DockHandler>();
                break;
            case 3:
                docked = this.clubDock.GetComponent<DockHandler>();
                break;
            case 4:
                docked = this.spadeDock.GetComponent<DockHandler>();
                break;
            default:
                docked = null;
                break;

        }
        end = docked.DockedCards.Count;
        
        if (end == 0 && suitValue == 1)
        {
            Debug.Log("its an ace");
            StackingCards stack = this.GetComponent<StackingCards>();
            stack.IsConnected = false;
            this.transform.position += new Vector3(0.0f, 0.0f, 0.5f);
            docked.Adding(this.suitValue);
            return true;
        }
        else if(end != 0)
        {
            if (this.suitValue == docked.DockedCards[end - 1] + 1)
            {
                Debug.Log("its the next number");
                StackingCards stack = this.GetComponent<StackingCards>();
                stack.IsConnected = false;
                this.transform.position += new Vector3(0.0f, 0.0f, 0.5f);
                docked.Adding(this.suitValue);
                return true;
            }
        }
        Debug.Log(suitValue);
        Debug.Log(end);
        Debug.Log("nope");
        return false;
    }

  
    

    public void OnSwipe(SwipeEventArgs args)
    {
        
      

        if (args.Direction == ESwipeDirection.RIGHT)
        {
            this.ToDock(args);
        }


    }
    // Start is called before the first frame update

    private void OnEnable()
    {
        //set the [targetPosition] ot the cube's current position.
        //this.targetPosition = this.transform.position;
        //use update to slowly move it.
    }

    public void NameGetter(int value, int type)
    {
        this.suitValue = value;
        this.suitType = type;
    }


    void Start()
    {
        this.heartDock = GameObject.Find("HeartDock");
        this.diamondDock = GameObject.Find("DiamondDock");
        this.clubDock = GameObject.Find("ClubDock");
        this.spadeDock = GameObject.Find("SpadeDock");
     
        
    }

    // Update is called once per frame
    void Update() 
    {
        float speed = 10.0f * Time.deltaTime;
        if (this.targetPosition != Vector3.zero) 
        {
            this.gameObject.transform.position = Vector3.MoveTowards(this.transform.position, this.targetPosition, speed);
        }
        if(this.targetPosition == this.transform.position)
        {
            this.targetPosition = Vector3.zero;
        }
    }
       
}
