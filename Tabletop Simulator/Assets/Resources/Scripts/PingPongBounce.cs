using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(AudioSource))]
public class PingPongBounce : MonoBehaviour {

    [SerializeField]
    public float dampenScale = 0.6f;

    [SerializeField]
    public float radius = 0.0F;

    [SerializeField]
    public float power = 2.0F;

    [SerializeField]
    public float upwardsModifier = 0.0F;

    private Rigidbody ball;
    private Vector3 velocityBeforePhysicsUpdate;

    // Use this for initialization
    void Start () {
        ball = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        velocityBeforePhysicsUpdate = ball.velocity;
    }

    // OCE has a delayed call. Need to fix this for better physics handlers
    // https://docs.unity3d.com/uploads/Main/monobehaviour_flowchart.svg
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
                if (velocityBeforePhysicsUpdate.y < 0)
                {
                    // We want the ball to normalize at a slower rate the close it gets to the table
                    float powerMagnitude = Mathf.Log10(Mathf.Abs(velocityBeforePhysicsUpdate.y) + 2);
                    Debug.Log(velocityBeforePhysicsUpdate.y + " " + powerMagnitude);
                    GetComponent<AudioSource>().Play();
                    ball.AddExplosionForce(power * powerMagnitude, ball.transform.position, radius, upwardsModifier);
                }
                break;
        }
    }

    // Update is called once per frame
    void Update () {
        
    }
}
