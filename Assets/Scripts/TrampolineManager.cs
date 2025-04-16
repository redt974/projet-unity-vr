using UnityEngine;

public class TrampolineManager : MonoBehaviour
{
    public float force; 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   

    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Boule"))
        {
            Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();
            rb.linearVelocity = Vector3.Reflect(other.relativeVelocity, transform.up)* force;
        }

    }
    
}
