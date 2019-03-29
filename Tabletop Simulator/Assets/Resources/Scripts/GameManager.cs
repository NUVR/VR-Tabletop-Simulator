using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField]
    public Transform ball;

    [SerializeField]
    public Transform table;

    private Vector3 initialPosition;

    // Start is called before the first frame update
    void Start()
    {
        initialPosition = ball.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (ShouldResetBall())
        {
            ResetBallPosition();
        }
    }

    public void OnBallEntersCup(GameObject cup)
    {
        Destroy(cup);
        ResetBallPosition();
    }

    bool ShouldResetBall()
    {
        return ball.position.y < table.position.y;
    }

    void ResetBallPosition()
    {
        ball.position = initialPosition;
        ball.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
    }
}
