using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Stagger
{
    private static Vector3 DEFAULT_POS_BOUNDS = new Vector3(0.5f, 0.2f, 0.5f);
    private static Vector3 DEFAULT_ROT_BOUNDS = new Vector3(20, 20, 20);

    private Vector3 PositionBounds;
    private Vector3 RotationBounds;

    private struct RandomPoint
    {
        public Vector3 RandomPosition;
        public Vector3 RandomRotation;
        public float Weight;

        public RandomPoint(Vector3 RandomPosition, Vector3 RandomRotation, float Weight)
        {
            this.RandomPosition = RandomPosition;
            this.RandomRotation = RandomRotation;
            this.Weight = Weight;
        }
    }

    private readonly RandomPoint[] Randoms;

    public Stagger(): this(DEFAULT_POS_BOUNDS, DEFAULT_ROT_BOUNDS) { }

    public Stagger(Vector3 PositionBounds, Vector3 RotationBounds, int NumRandomPoints = 3)
    {
        this.PositionBounds = PositionBounds;
        this.RotationBounds = RotationBounds;

        Randoms = new RandomPoint[NumRandomPoints];
        float totalWeight = 1f;
        for (int index = 0; index < NumRandomPoints; index++)
        {
            float weight = Random.Range(0, totalWeight);
            totalWeight -= weight;
            Randoms[index] = new RandomPoint(GenerateRandomPosition(), GenerateRandomRotation(), weight);
        }
    }

    public void Update(int Weight)
    {
        Debug.Log(Weight);
    }



    private Vector3 GenerateRandomPosition()
    {
        return GenerateRandomVector(PositionBounds);
    }

    private Vector3 GenerateRandomRotation()
    {
        return GenerateRandomVector(RotationBounds);
    }

    private Vector3 GenerateRandomVector(Vector3 bounds)
    {
        float x = Random.Range(-bounds.x, bounds.x);
        float y = Random.Range(-bounds.y, bounds.y);
        float z = Random.Range(-bounds.z, bounds.z);
        return new Vector3(x, y, z);
    }
}
