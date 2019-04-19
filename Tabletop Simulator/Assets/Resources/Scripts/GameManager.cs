using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField]
    public OVRCameraRig player;

    [SerializeField]
    public Transform ball;

    [SerializeField]
    public Transform table;

    // Blur delegater
    public delegate void Delegate();
    public Delegate IncreaseBlur;

    private Vector3 initialPosition;
    private int CupsDestroyed;

    private Stagger Stagger;

    // Start is called before the first frame update
    void Start()
    {
        initialPosition = ball.position;
        CupsDestroyed = 0;
        Stagger = new Stagger();
    }

    // Update is called once per frame
    void Update()
    {
        Stagger.Update(CupsDestroyed);
        if (ShouldResetBall())
        {
            ResetBallPosition();
        }
    }

    public void OnBallEntersCup(GameObject cup)
    {
        Destroy(cup);
        ResetBallPosition();
        HydrateView();
        CupsDestroyed++;
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

    void HydrateView()
    {
        IncreaseBlur();
    }
}
