using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupManager : MonoBehaviour
{
    [SerializeField]
    public GameManager GameManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCupTrigger(Collider collider, GameObject cup)
    {
        if (collider.name.ToLower() == "ball")
        {
            GameManager.OnBallEntersCup(cup);
        }
    }
}
