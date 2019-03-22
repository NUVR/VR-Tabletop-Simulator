using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public event Action<OnCupCollisionArgs> OnCupCollision;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //private void OnCupCollision(OnCupCollisionArgs args)
    //{
    //    Debug.Log("COLLISION");
    //}
}

public struct OnCupCollisionArgs
{
    public OnCupCollisionArgs(Collision collision)
    {
        collisionDetails = collision;
    }

    public Collision collisionDetails { get; }
}
