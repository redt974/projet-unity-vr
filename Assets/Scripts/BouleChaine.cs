using UnityEngine;

public class BouleChaine : MonoBehaviour
{
    [SerializeField] private Transform pointAttache; // Dernier maillon de la chaîne
    [SerializeField] private float maxDistance = 1.5f;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        float distance = Vector3.Distance(transform.position, pointAttache.position);
        if (distance > maxDistance)
        {
            Vector3 direction = (transform.position - pointAttache.position).normalized;
            transform.position = pointAttache.position + direction * maxDistance;

            // Optionnel : annuler la vitesse dans la direction d’extension
            rb.linearVelocity = Vector3.ProjectOnPlane(rb.linearVelocity, direction);
        }
    }
}
