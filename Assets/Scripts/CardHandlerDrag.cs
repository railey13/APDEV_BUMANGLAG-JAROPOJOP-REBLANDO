using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CardHandlerDrag : MonoBehaviour, IDraggable
{
    [SerializeField] private int SuitValue = 0;
    [SerializeField] private bool isRed = false;

    private Vector3 targetPosition = Vector3.zero;
    private Vector3 originalPosition = Vector3.zero;

    private bool isDragging = false;

    // Start is called before the first frame update
    void Start()
    {
        this.targetPosition = transform.position;
        this.originalPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float speed = 3.0f * Time.deltaTime;
        this.gameObject.transform.position = Vector3.MoveTowards(this.transform.position, this.targetPosition, speed);
    }

    public void OnDrag(DragEventArgs args)
    {
        if (args.HitObject == this.gameObject)
        {
            this.isDragging = true;
            Vector2 position = args.Trackedfinger.position;
            Ray ray = Camera.main.ScreenPointToRay(position);
            Vector2 worldPosition = ray.GetPoint(10);

            this.targetPosition = worldPosition;
            this.transform.position = worldPosition;

            //zOffset
            //Vector3 zOffset = new Vector3(0, 0, -4.0f);
            //this.targetPosition += zOffset;
            //this.gameObject.transform.position += zOffset;
        }
    }

    public void OnRelease(DragEventArgs args)
    {
        this.isDragging = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("NAme: " + collision.gameObject.name);
    }
}
