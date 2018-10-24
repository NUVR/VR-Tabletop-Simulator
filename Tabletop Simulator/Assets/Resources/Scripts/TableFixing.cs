using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableFixing : MonoBehaviour {

    [SerializeField]
    protected Collider[] collisionDetectors = null;

    private bool isPressing;
    private Collider collisionRegion;

    // Use this for initialization
    void Start () {
        this.collisionRegion = gameObject.GetComponent<Collider>();
	}
	
	// Update is called once per frame
	void Update () {
        DetectTrigger();
    }

    private void DetectTrigger()
    {
        float hand = OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger, OVRInput.Controller.LTouch);
        float index = OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger, OVRInput.Controller.LTouch);
        bool isPressing = hand + index > 1;
        if (this.isPressing != isPressing)
        {
            this.isPressing = isPressing;
            Debug.Log(isPressing ? "Pressing" : "Released");
        }
        if (hand + index > 1)
        {
            
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("COLLISION");
    }
}
