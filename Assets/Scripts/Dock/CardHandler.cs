using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardHandler : MonoBehaviour, ISwipeable, IDraggable
{
    // Start is called before the first frame update

    private Vector3 targetPosition = Vector3.zero;
    private GameObject heartDock;
    private GameObject diamondDock;
    private GameObject clubDock;
    private GameObject spadeDock;

    public int suitValue = 0;
    public int suitType = 0;

    bool IsRevealed = false;
    bool isRed = false;

    public void OnDrag(DragEventArgs args)
    {
        
        if (args.HitObject == this.gameObject)
        {
            
            Vector2 position = args.Trackedfinger.position;
            Ray ray = Camera.main.ScreenPointToRay(position);
            Vector2 worldPosition = ray.GetPoint(10);

            this.targetPosition = worldPosition;
            this.transform.position = worldPosition;

            //zOffset
            Vector3 zOffset = new Vector3(0, 0, -4.0f);
            this.targetPosition += zOffset;
            this.gameObject.transform.position += zOffset;
        }
    }

    public void OnRelease(DragEventArgs arg) 
    {
        //zOffset
        Debug.Log("Released!");
        Vector3 zOffset = new Vector3(0, 0, +4.0f);
        this.targetPosition += zOffset;
        this.gameObject.transform.position += zOffset;
    }

    private void ToDock(SwipeEventArgs args)
    {
        
        switch (this.suitType)
        {
            
            case 0: // heart
               
                    this.targetPosition = heartDock.transform.position;
                
                
                break;
            case 1: // diamond
                if (CheckDock(this.suitType))
                {
                    this.targetPosition = diamondDock.transform.position;
                }
               
                break;
            case 2:// club
                if (CheckDock(this.suitType))
                {
                    this.targetPosition = clubDock.transform.position;
                }
                
                break;
            case 3: // spade
                if (CheckDock(this.suitType))
                {
                    this.targetPosition = spadeDock.transform.position;
                }
               
                break;

        }

    }

    private bool CheckDock(int dock)
    {
        DockHandler docked;
        switch (dock) {
            case 0:
                docked = heartDock.GetComponent<DockHandler>();
                break;
            case 1:
                docked = diamondDock.GetComponent<DockHandler>();
                break;
            case 2:
                docked = clubDock.GetComponent<DockHandler>();
                break;
            case 3:
                docked = diamondDock.GetComponent<DockHandler>();
                break;
            default:
                docked = heartDock.GetComponent<DockHandler>();
                break;

        }
        int end = docked.DockedCards.Count ;
        
        if (end == 0 && suitValue == 0)
        {
            Debug.Log("its an ace");
            return true;
        }
        else if(this.suitValue == docked.DockedCards[end-1] + 1)
        {
            Debug.Log("its the next number");
            return true;
        }
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
        this.targetPosition = this.transform.position;
        //use update to slowly move it.
    }
    void Start()
    {
        heartDock = GameObject.Find("HeartDock");
        diamondDock = GameObject.Find("DiamondDock");
        clubDock = GameObject.Find("ClubDock");
        spadeDock = GameObject.Find("SpadeDock");
    }

    // Update is called once per frame
    void Update()
    {
        float speed = 10.0f * Time.deltaTime;
        this.gameObject.transform.position = Vector3.MoveTowards(this.transform.position, this.targetPosition, speed);
    }
}
