using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PingPongBounce : MonoBehaviour {

    [SerializeField]
    public float dampenScale = 0.6f;

    [SerializeField]
    public float radius = 0.0F;

    [SerializeField]
    public float power = 100.0F;

    [SerializeField]
    public float upwardsModifier = 0.0F;

    private Rigidbody ball;

    // Use this for initialization
    void Start () {
        ball = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        string collisionName = collision.gameObject.name.ToLower();
        switch(collisionName)
        {
            case "cup":
                // Only dampen if ball is traveling fast
                if (ball.velocity.magnitude > 1f)
                {
                    ball.velocity = ball.velocity * dampenScale;
                }
                break;
            case "table":
                Debug.Log(ball.velocity.y);
                if (ball.velocity.y < 0)
                {
                    float powerMagnitude = ball.velocity.y * -1;
                    ball.AddExplosionForce(power * powerMagnitude, ball.transform.position, radius, upwardsModifier);
                }
                break;
        }
        
        //var direction = Vector3.Reflect(ball.position.normalized, collision.contacts[0].normal);
        //ball.velocity = direction * 5;
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
