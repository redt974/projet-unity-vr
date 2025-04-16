using UnityEngine;

public class InitialPosition : MonoBehaviour
{
    private Vector3 initialPosition;
    private Quaternion initialRotation;

    void Start()
    {
        // Sauvegarder la position et la rotation initiale du colis.
        initialPosition = transform.position;
        initialRotation = transform.rotation;
    }

    public void ResetPosition()
    {
        // Réinitialiser la position et la rotation à leur état initial.
        transform.position = initialPosition;
        transform.rotation = initialRotation;

        // Réinitialiser la vélocité du Rigidbody, s'il existe.
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            // (Optionnel) Désactiver la gravité après reset.
            rb.useGravity = false;
        }

        Debug.Log(gameObject.name + " a été remis à sa position initiale.");
    }
}
