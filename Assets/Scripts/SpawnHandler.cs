using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnHandler : MonoBehaviour, ITappable, ISwipeable, IDraggable
{
    [SerializeField]private int cardType = 0;

   
    
    [SerializeField] private int type = 0;
    private Vector3 targetPosition = Vector3.zero;
    
  
    public void OnDrag(DragEventArgs args)
    {
        
        if(args.HitObject == this.gameObject)
        {
            
            Vector2 position = args.Trackedfinger.position;
            Ray ray = Camera.main.ScreenPointToRay(position);
            Vector2 worldPosition = ray.GetPoint(10);

            this.targetPosition = worldPosition;
            this.transform.position = worldPosition;
        }
    }
    private void MovePerpendicular(SwipeEventArgs args)
    {
        switch (args.Direction)
        {
            case ESwipeDirection.UP:
                this.targetPosition += Vector3.up * 5;
                break;
            case ESwipeDirection.DOWN:
                this.targetPosition += Vector3.down * 5;
                break;
            case ESwipeDirection.LEFT:
                this.targetPosition += Vector3.left * 5;
                break;
            case ESwipeDirection.RIGHT:
                this.targetPosition += Vector3.right * 5;
                break;
           
        }
       
    }

    private void MoveDiagonal(SwipeEventArgs args)
    {
        switch (args.Direction)
        {
            
            case ESwipeDirection.TOPLEFT:
                this.targetPosition += new Vector3(-5.0f, 5.0f, 0.0f);
                break;
            case ESwipeDirection.TOPRIGHT:
                this.targetPosition += new Vector3(5.0f, 5.0f, 0.0f);
                break;
            case ESwipeDirection.BOTTOMLEFT:
                this.targetPosition += new Vector3(-5.0f, -5.0f, 0.0f);
                break;
            case ESwipeDirection.BOTTOMRIGHT:
                this.targetPosition += new Vector3(5.0f, -5.0f, 0.0f);
                break;
        }
    }
    public void OnTap(TapEventArgs args)
    {
        Destroy(this.gameObject);
    }
     
    public void OnSwipe(SwipeEventArgs args)
    {
        
       
        if (args.Direction == ESwipeDirection.RIGHT)
        {
            type = 0;
        }
        else
        {
            type = 1;
        }


        switch (type)
         {
            case 0:
                this.MovePerpendicular(args);
                break;
            case 1:
                this.MoveDiagonal(args);
                break;
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
        
    }

    // Update is called once per frame
    void Update()
    {
        float speed = 1.0f * Time.deltaTime;
        this.gameObject.transform.position = Vector3.MoveTowards(this.transform.position, this.targetPosition, speed);
    }
        
}
