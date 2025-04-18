using UnityEngine;

public class BoutonReset : MonoBehaviour
{

    [SerializeField] public GameObject colisRigidbody;
    private Vector3 positionInitiale;
    private Quaternion rotationInitiale;


    public string tagReset = "bouton";


    void Start()
    {
        positionInitiale = colisRigidbody.transform.position;
        rotationInitiale = colisRigidbody.transform.rotation;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(tagReset))
        {
            ResetPosition();
        }
    }


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
