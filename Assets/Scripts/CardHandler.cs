using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardHandler : MonoBehaviour, ISwipeable, IDraggable
{
    // Start is called before the first frame update

    private Vector3 targetPosition = Vector3.zero;
    [SerializeField] private Transform transformDock;
    int suitValue = 0;
    int suitType = 0;
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
        }
    }
    private void MoveRight(SwipeEventArgs args)
    {
        switch (args.Direction)
        {
            
            case ESwipeDirection.RIGHT:
                this.targetPosition = transformDock.position;
                break;

        }

    }

  
    

    public void OnSwipe(SwipeEventArgs args)
    {
        
      

        if (args.Direction == ESwipeDirection.RIGHT)
        {
            this.MoveRight(args);
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
        float speed = 10.0f * Time.deltaTime;
        this.gameObject.transform.position = Vector3.MoveTowards(this.transform.position, this.targetPosition, speed);
    }
}
