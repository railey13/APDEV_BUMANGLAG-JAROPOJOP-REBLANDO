using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Threading;
using Unity.VisualScripting;
public class GestureManager : MonoBehaviour
{
    private Vector2 startPoint = Vector2.zero;
    private Vector2 endPoint = Vector2.zero;

    [SerializeField] private TapProperty tapProperty;   
    public EventHandler<TapEventArgs> OnTap;

    [SerializeField] private SwipeProperty swipeProperty;
    public EventHandler<SwipeEventArgs> OnSwipe;
    [SerializeField] private DragProperty dragProperty;
    public EventHandler<DragEventArgs> OnDrag;
    public static GestureManager Instance { get; private set; }

    private float gestureTime;
    private Touch trackedFinger;



    private void CheckDrag()
    {
        if(this.gestureTime >= this.dragProperty.Time)
        {
            
            FireDragEvent();
        }
    }

    private void FireDragEvent()
    {
        
        Vector2 position = this.trackedFinger.position;
        GameObject hitObject = OnHitObject(position);
        DragEventArgs args = new DragEventArgs(this.trackedFinger, hitObject);
        Debug.Log(hitObject);
        
        if(this.OnDrag != null)
        {
            
            this.OnDrag(this,args);
        }
        
        if(hitObject!= null)
        {
            
            IDraggable handler = hitObject.GetComponent<IDraggable>();
            if (handler != null)
            {
                
                handler.OnDrag(args);
            }
            
        }
       
    }
    private void CheckSwipe()
    {
        if (this.gestureTime <= this.swipeProperty.Time && Vector2.Distance(this.startPoint, this.endPoint) >= this.swipeProperty.MinDistance * Screen.dpi)
        {
            this.FireSwipeEvent();
        }
    }

    private void FireSwipeEvent()
    {
        Vector2 rawDirection = this.endPoint - this.startPoint;
        ESwipeDirection direction = this.getSwipeDirection(rawDirection);
        
        SwipeEventArgs args = new SwipeEventArgs(direction);
        GameObject hitObject = OnHitObject(this.startPoint);
        if (this.OnSwipe != null)
        {
            this.OnSwipe(this, args);
        }

        if (hitObject != null)
        {
            ISwipeable handler = hitObject.GetComponent<ISwipeable>();
            if (handler != null)
            {
                handler.OnSwipe(args);
            }
        }
    }
    private void CheckTap()
    {
        
        if (this.gestureTime <= this.tapProperty.Time && Vector2.Distance(this.startPoint, this.endPoint) <= this.tapProperty.MaxDistance * Screen.dpi ) 
        {
            FireTapEvent();
        }

    }

   

    private void FireTapEvent()
    {
        GameObject hitObject = OnHitObject(this.startPoint);

        TapEventArgs args = new TapEventArgs(this.startPoint, hitObject);

        if (hitObject != null)
        {
            ITappable handler = hitObject.GetComponent<ITappable>();
            if(handler != null)
            {
                handler.OnTap(args);
            }
        }
     
        
        if (this.OnTap != null)
        {
            this.OnTap(this, args);
        }
    }

    private GameObject OnHitObject(Vector2 pos)
    {
        GameObject hitObject = null;
        Ray ray = Camera.main.ScreenPointToRay(pos);
        RaycastHit hit;


        

        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            hitObject = hit.collider.gameObject;
        }
        return hitObject;
    }

    private ESwipeDirection getSwipeDirection(Vector2 rawDirection)
    {
        float swipeDiagonalDeadzone = 0.5f;// 1- this = allowance range if smaller; 1 + this = allowance range if bigger
        if (Math.Abs(rawDirection.x) > Math.Abs(rawDirection.y) * (1-swipeDiagonalDeadzone) &&
            Math.Abs(rawDirection.x) < Math.Abs(rawDirection.y) * (1 + swipeDiagonalDeadzone))
        {
            if(rawDirection.x <= 0 && rawDirection.y <= 0)
            {
                return ESwipeDirection.BOTTOMLEFT;
            }

            if (rawDirection.x >= 0 && rawDirection.y <=0)
            {
                return ESwipeDirection.BOTTOMRIGHT;
            }

            if (rawDirection.x <= 0 && rawDirection.y >= 0)
            {
                return ESwipeDirection.TOPLEFT;
            }

            if (rawDirection.x >= 0 && rawDirection.y >= 0)
            {
                return ESwipeDirection.TOPRIGHT;
            }
        }
        else if (Math.Abs(rawDirection.x) > Math.Abs(rawDirection.y))
        {
            if(rawDirection.x >= 0)
            {
                return ESwipeDirection.RIGHT;
            }
            else if(rawDirection.x < 0) 
            {
                return ESwipeDirection.LEFT;
            }
        }
        else
        {
            if (rawDirection.y >= 0)
            {
                return ESwipeDirection.UP;
            }
            else if (rawDirection.y < 0)
            {
                return ESwipeDirection.DOWN;
            }
        }
        
       

        return ESwipeDirection.NONE;//this should never output

    }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
    }
    
    
    private void Update()
    {
        if(Input.touchCount > 0)
        {
            this.trackedFinger = Input.GetTouch(0);
            switch (this.trackedFinger.phase)
            {
                case TouchPhase.Began:
                    this.startPoint = this.trackedFinger.position;
                    this.gestureTime = 0;
                    
                    break;

                case TouchPhase.Ended:
                    this.endPoint = this.trackedFinger.position;
                    this.CheckTap();
                    this.CheckSwipe();
                    

                    break;

                default:
                    this.CheckDrag();
                    this.gestureTime += Time.deltaTime;
                    break;
            }
        }
    }
}
