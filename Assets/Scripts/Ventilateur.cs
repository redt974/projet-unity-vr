using UnityEngine;

public class Ventilateur : MonoBehaviour
{
    [Header("Réglages du Vent")]
    public float forceDuVent = 20f;
    public float portée = 5f;
    public AnimationCurve attenuation = AnimationCurve.EaseInOut(0, 1, 1, 0);

    private void OnTriggerStay(Collider other)
    {
        Rigidbody rb = other.attachedRigidbody;
        if (rb == null) return;

        // Calcul de la direction du vent
        Vector3 directionVent = transform.forward;

        // Distance entre le ventilateur et l'objet
        Vector3 toObject = other.transform.position - transform.position;
        float distance = Vector3.Project(toObject, directionVent).magnitude;

        // Si l'objet est dans la portée
        if (distance < portée)
        {
            float force = forceDuVent * attenuation.Evaluate(distance / portée);
            rb.AddForce(directionVent * force, ForceMode.Force);
        }
    }
}
