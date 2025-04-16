using UnityEngine;

public class DecelerationZone : MonoBehaviour
{
    [SerializeField] private float decelerationRate = 2f; // Intensité de la décélération par seconde

    // Cette méthode est appelée à chaque frame tant que le colis reste dans le trigger
    private void OnTriggerStay(Collider other)
    {
        // Vérifie que l'objet qui entre est bien le colis
        if (other.CompareTag("Colis"))
        {
            Rigidbody rb = other.GetComponent<Rigidbody>();
            if (rb != null)
            {
                // Calcul d'un vecteur de décélération opposé à la direction du mouvement actuel
                Vector3 decelerationVector = -rb.linearVelocity.normalized * decelerationRate * Time.deltaTime;

                // Pour éviter de "renverser" la direction, on arrête complètement le colis si sa vitesse est très faible
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
