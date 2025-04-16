using UnityEngine;

public class Teleportation : MonoBehaviour
{
    public Transform teleportTarget;
    public string tagToTeleport = "Balle";

    private void OnTriggerEnter(Collider other)
    {
        if (teleportTarget == null) return;

        if (string.IsNullOrEmpty(tagToTeleport) || other.CompareTag(tagToTeleport))
        {
            CharacterController controller = other.GetComponent<CharacterController>();

            if (controller != null)
            {
                // Si c'est un joueur avec un CharacterController, on le déplace sans affecter la physique
                controller.enabled = false;
                other.transform.position = teleportTarget.position;
                controller.enabled = true;
            }
            else
            {
                // Sinon on déplace normalement
                other.transform.position = teleportTarget.position;
            }
        }
    }
}
