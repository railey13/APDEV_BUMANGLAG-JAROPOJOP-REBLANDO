using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardHandler : MonoBehaviour, IDraggable
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
        float speed = 1.0f * Time.deltaTime;
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
            this.transform.position += new Vector3(0, 0, -0.2f);
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
