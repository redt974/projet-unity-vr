using UnityEngine;

public class Teleportation : MonoBehaviour
{
    [SerializeField] private Transform teleportTarget;
    [SerializeField] private string tagToTeleport = "Balle";

    private void OnTriggerEnter(Collider other)
    {
        if (teleportTarget == null) return;

        if (other.CompareTag(tagToTeleport))
        {
            Rigidbody rigi = other.attachedRigidbody;

            if (other.attachedRigidbody != null)
            {
                // Conserver la vitesse dans la direction d'entrée
                Vector3 vitesseEntree = rigi.linearVelocity;
                float vitesseMagnitude = vitesseEntree.magnitude;

                // Nouvelle direction basée sur l'orientation de la cible
                Vector3 directionSortie = teleportTarget.forward;

                // Calculer la vitesse finale en réorientant la direction
                Vector3 vitesseSortie = directionSortie * vitesseMagnitude;

                // Téléporter et ajuster la vitesse
                rigi.position = teleportTarget.position;
                rigi.linearVelocity = vitesseSortie;
            }
        }
    }
}
