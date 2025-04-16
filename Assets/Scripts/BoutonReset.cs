using UnityEngine;

public class BoutonReset : MonoBehaviour
{
    // Stockage de la position et de la rotation initiales du colis.
    [SerializeField] public GameObject colisRigidbody;
    private Vector3 positionInitiale;
    private Quaternion rotationInitiale;

    // Tag de l'objet déclencheur qui va réinitialiser le colis.
    public string tagReset = "bouton";

    // Dans Start, on sauvegarde la position et la rotation de départ.
    void Start()
    {
        positionInitiale = colisRigidbody.transform.position;
        rotationInitiale = colisRigidbody.transform.rotation;
    }

    // Lorsqu'un autre collider entre dans le trigger de cet objet,
    // on vérifie s'il possède le tag défini pour le reset.
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(tagReset))
        {
            ResetPosition();
        }
    }

    // Méthode de réinitialisation : position, rotation et vélocités.
    public void ResetPosition()
    {
        colisRigidbody.transform.position = positionInitiale;
        colisRigidbody.transform.rotation = rotationInitiale;

        Rigidbody rb = colisRigidbody.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            rb.useGravity = false;
        }

        Debug.Log("Le colis a été remis à sa position initiale.");
    }
}
