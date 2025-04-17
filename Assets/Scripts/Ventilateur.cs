using UnityEngine;

public class Ventilateur : MonoBehaviour
{
    public float forceDuVent = 20f;
    public float portée = 5f;
    public AnimationCurve attenuation = AnimationCurve.EaseInOut(0, 1, 1, 0);

    private void OnTriggerStay(Collider other)
    {
        Rigidbody rigi = other.attachedRigidbody;
        if (rigi == null) return;

        Vector3 directionVent = transform.forward;
        Vector3 toObject = other.transform.position - transform.position;
        float distance = Vector3.Project(toObject, directionVent).magnitude;

        if (distance < portée)
        {
            float force = forceDuVent * attenuation.Evaluate(distance / portée);
            rigi.AddForce(directionVent * force, ForceMode.Force);
        }
    }
}
