using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableFixing : MonoBehaviour {

    [SerializeField]
    protected Collider[] collisionDetectors = null;

    private Collider collisionRegion;

    // Use this for initialization
    void Start () {
        this.collisionRegion = GameObject.GetComponent<Collider>();
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log("Test");
	}
}
