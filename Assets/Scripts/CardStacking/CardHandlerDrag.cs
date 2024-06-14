using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardHandlerDrag : MonoBehaviour, IDraggable
{
    // Start is called before the first frame update

    private Vector3 targetPosition = Vector3.zero;

    public void OnDrag(DragEventArgs args)
    {
        
        if (args.HitObject == this.gameObject)
        {
            
            Vector2 position = args.Trackedfinger.position;
            Ray ray = Camera.main.ScreenPointToRay(position);
            Vector2 worldPosition = ray.GetPoint(10);

            this.targetPosition = worldPosition;
            this.transform.position = worldPosition;

            //Offset
            Vector3 offset = new Vector3(0, -1, -4.0f);
            this.targetPosition += offset;
            this.gameObject.transform.position += offset;
        }
    }

    public void OnRelease(DragEventArgs arg) 
    {
        //zOffset
        Debug.Log("Released!");
        Vector3 zOffset = new Vector3(0, 0, +4.0f);
        this.targetPosition += zOffset;
        //this.gameObject.transform.position += zOffset;
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
