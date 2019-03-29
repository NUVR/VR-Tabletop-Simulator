using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PingPongBounce : MonoBehaviour {
    public Rigidbody ball;
    // Use this for initialization
    void Start () {
        ball = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        var direction = Vector3.Reflect(ball.position.normalized, collision.contacts[0].normal);
        ball.velocity = direction * 5;
        //foreach (ContactPoint contact in collision.contacts)
        //{
        //   print(contact.point);
        //}
        //Vector3 ballPosition = collision.contacts[0].point;
        //Vector3 paddlePosition = collision.contacts[1].point;
        //Vector3 shootDir = ballPosition - paddlePosition; // Calculate direction of the shot
        //ball.AddForce(Camera.main.transform.forward * 5, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update () {
        
    }
}
