using UnityEngine;

public class BouleChaine : MonoBehaviour
{
    [SerializeField] private Transform pivot;

    private bool isGrabbed = false;

    public void SetGrabbed(bool state)
    {
        isGrabbed = state;
    }

    private void OnDrawGizmos()
    {
        if (pivot == null) return;

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(pivot.position, 0.1f);

        Gizmos.color = Color.green;
        Gizmos.DrawLine(pivot.position, transform.position);
    }
}
