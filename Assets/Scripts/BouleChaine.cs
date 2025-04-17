using UnityEngine;

public class BouleChaine : MonoBehaviour
{
    [SerializeField] private float angleActuel = 0f;
    [SerializeField] private float angleMin = -90f;
    [SerializeField] private float angleMax = 90f;

    public void ModifierAngle(float variation)
    {
        angleActuel += variation;
        angleActuel = Mathf.Clamp(angleActuel, angleMin, angleMax);

        transform.localRotation = Quaternion.Euler(angleActuel, 0f, 0f);
        Debug.Log("Nouvel angle X : " + angleActuel);
    }

    public float GetAngle() => angleActuel;
}
