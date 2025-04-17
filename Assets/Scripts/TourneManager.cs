using UnityEngine;

public class TourneManager : MonoBehaviour
{
    public float targetRotation = 90f; // Angle à atteindre en degrés
    public float rotationSpeed = 45f;  // Vitesse de rotation en degrés/seconde

    private float currentRotation = 0f;
    private bool rotating = true;

    void Update()
    {
        if (rotating)
        {
            float rotationThisFrame = rotationSpeed * Time.deltaTime;
            
            // Si on dépasse le target, on ajuste pour s'arrêter pile au bon moment
            if (currentRotation + rotationThisFrame >= targetRotation)
            {
                rotationThisFrame = targetRotation - currentRotation;
                rotating = false; // Arrêter la rotation
            }

            transform.Rotate(Vector3.up, rotationThisFrame); // Rotation sur l'axe Y (vertical)
            currentRotation += rotationThisFrame;
        }
    }
}
