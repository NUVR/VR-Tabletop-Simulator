using UnityEngine;

[RequireComponent(typeof(CapsuleCollider))]
public class CupCollisionHandler : MonoBehaviour
{
    private CupManager manager;

    void Start()
    {
        manager = GetGrandparentCupManager();
    }

    private CupManager GetGrandparentCupManager()
    {
        try
        {
            CupManager manager = transform.parent.parent.gameObject.GetComponent<CupManager>();
            return manager;
        } catch (MissingComponentException)
        {
            Debug.LogError("Grandparent does not contain CupManager component");
            // Destroy this object
            Destroy(gameObject);
        }
        return null;
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

    private void OnTriggerEnter(Collider collider)
    {
        manager.OnCupTrigger(collider, transform.parent.gameObject);
    }

}
