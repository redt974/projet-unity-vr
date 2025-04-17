using UnityEngine;

public class TourneManager : MonoBehaviour
{
    public float targetRotation = 45f; // Angle à atteindre en degrés
    public float rotationSpeed = 10f;  // Vitesse de rotation en degrés/seconde

    private float currentRotation = 0f;


    void Update()
    {


        float rotationThisFrame = rotationSpeed * Time.deltaTime;

        // Si on dépasse le target, on ajuste pour s'arrêter pile au bon moment

        rotationThisFrame = targetRotation - currentRotation;


        transform.Rotate(Vector3.up, rotationThisFrame); // Rotation sur l'axe Y (vertical)
        currentRotation += rotationThisFrame;

    }
}
