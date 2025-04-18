using UnityEngine;

public class InitialPosition : MonoBehaviour
{
    private Vector3 initialPosition;
    private Quaternion initialRotation;

    void Start()
    {

        initialPosition = transform.position;
        initialRotation = transform.rotation;
    }

    public void ResetPosition()
    {

        transform.position = initialPosition;
        transform.rotation = initialRotation;

        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;

            rb.useGravity = false;
        }

        Debug.Log(gameObject.name + " a été remis à sa position initiale.");
    }
}
