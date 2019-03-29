using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableFixing : MonoBehaviour {

    [SerializeField]
    public GameObject ball;

    private Vector3 initialPosition;

    // Use this for initialization
    void Start () {
        initialPosition = ball.transform.position;
    }
    
    // Update is called once per frame
    void Update () {

    }

    void ResetBallPosition()
    {
        ball.transform.position = initialPosition;
        ball.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
    }
}
