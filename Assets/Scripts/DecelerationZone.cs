using UnityEngine;

public class DecelerationZone : MonoBehaviour
{
    [SerializeField] public float decelerationRate = 2f;
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Colis"))
        {
            Rigidbody rb = other.GetComponent<Rigidbody>();
            if (rb != null)
            {
                Vector3 decelerationVector = -rb.linearVelocity.normalized * decelerationRate * Time.deltaTime;

                if (rb.linearVelocity.magnitude < decelerationRate * Time.deltaTime)
                {
                    rb.linearVelocity = Vector3.zero;
                }
                else
                {
                    rb.linearVelocity += decelerationVector;
                }
            }
        }
    }
}
