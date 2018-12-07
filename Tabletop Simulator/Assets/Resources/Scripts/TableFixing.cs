using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableFixing : MonoBehaviour {

    [SerializeField]
    public GameObject table;

    [SerializeField]
    protected GameObject[] cupsCollidedWith = null;

    private GameObject cup = null;
    private Vector3 initialPosition;

    // Use this for initialization
    void Start () {
        initialPosition = gameObject.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        CheckCup();
        if (shouldReset())
        {
            resetPosition();
        }
	}

    void OnCollisionEnter(Collision collision)
    {

        if (collision.collider.tag == "Cup" || collision.collider.name == "Cup")
        {
            Debug.Log(collision.gameObject.name + " hit!");
            DealWithCollision(collision.gameObject);
        }
    }

    void CheckCup()
    {
        if (this.cup != null) {

            Rigidbody ballRb = gameObject.GetComponent<Rigidbody>();
            float a = ballRb.position.y - GetComponent<Renderer>().bounds.size.y;
            float b = cup.transform.position.y;
            Debug.Log("CUP: " + b + " BALL: " + a);
            if (a < b)
            {
                Destroy(this.cup);
                resetPosition();
                this.cup = null;
            }
        }
       
    }

    void DealWithCollision(GameObject cup)
    {
        // Set ball velocity
        Rigidbody rb = gameObject.GetComponent<Rigidbody>();
        float dup = 0.5f;
        rb.velocity = new Vector3(rb.velocity.x * dup, rb.velocity.y * dup, rb.velocity.z * dup);
        // Prepare to delete cup
        this.cup = cup;
    }

    void resetPosition()
    {
        gameObject.transform.position = initialPosition;
        gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
    }

    bool shouldReset()
    {
        return gameObject.transform.position.y < table.gameObject.transform.position.y;
    }
}
