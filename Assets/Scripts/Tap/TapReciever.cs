using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tap : MonoBehaviour
{
    [SerializeField] private GameObject copy;
    public void OnTap(object sender ,TapEventArgs args)
    {
        if(args.HitObject == null)
        {
            Debug.Log("Spawning Object");

            Ray ray = Camera.main.ScreenPointToRay(args.Position);

            Instantiate(copy, ray.GetPoint(10), Quaternion.identity);
        }
        
    }
    // Start is called before the first frame update
    void Start()
    {
        GestureManager.Instance.OnTap += this.OnTap;
    }

    // Update is called once per frame
    void OnDisable()
    {
        GestureManager.Instance.OnTap -= this.OnTap;
    }
}
