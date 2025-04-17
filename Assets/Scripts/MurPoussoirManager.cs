using UnityEngine;

public class MurPoussoirManager : MonoBehaviour
{
   
    private float distanceMur = 4f;         // Distance de déplacement
    public float vitessemur = 2f;            // Vitesse de va-et-vient
    
    public float force = 5f;                // Force appliquée à la boule

    private Vector3 startPosition;
    private Vector3 targetPosition;
    private bool goingForward = true;

    void Start()
{
    startPosition = transform.position;
    Vector3 direction = Vector3.right; // mouvement horizontal sur l'axe X
    targetPosition = startPosition + direction * distanceMur;
}


    void Update()
    {
        Vector3 destination = goingForward ? targetPosition : startPosition;
        transform.position = Vector3.MoveTowards(transform.position, destination, vitessemur * Time.deltaTime);

        if (Vector3.Distance(transform.position, destination) < 0.01f)
        {
            goingForward = !goingForward;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Boule"))
        {
            Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                // On réfléchit la vitesse de la boule en fonction de la normale de la surface du mur
                Vector3 reflection = Vector3.Reflect(other.relativeVelocity, transform.up);
                rb.linearVelocity = reflection.normalized * force;
            }
        }
    }
}
