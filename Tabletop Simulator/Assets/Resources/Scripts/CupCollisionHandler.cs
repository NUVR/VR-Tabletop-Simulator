using UnityEngine;

[RequireComponent(typeof(CapsuleCollider))]
public class CupCollisionHandler : MonoBehaviour
{
    [SerializeField]
    public GameObject GameController;

    private GameManager manager;

    void Start()
    {
        manager = GameController.GetComponent<GameManager>();
    }

    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Ball")
        {
            Debug.Log("Colliding with ball");
        }
    }

    private void OnDestroy()
    {
        
    }
 
}
