using UnityEngine;

public class BoutonStart : MonoBehaviour
{
    // Référence vers le Rigidbody du colis (objet dont la gravité sera activée)
    public Rigidbody colisRigidbody;

    // Tag du déclencheur (par exemple "bouton")
    public string tagCible = "bouton";

    // Référence vers le joueur à déplacer
    public GameObject joueur;

    // Destination vers laquelle le joueur sera déplacé
    public Transform destinationSalle;

    // Méthode appelée lorsqu'un autre collider entre dans le trigger de cet objet
    private void OnTriggerEnter(Collider other)
    {
        // Vérifier que l'objet entrant possède le tag ciblé
        if (other.CompareTag(tagCible))
        {
            // Activation immédiate de la physique sur le colis en activant la gravité
            if (colisRigidbody != null)
            {
                colisRigidbody.useGravity = true;
                Debug.Log("Gravité activée sur le colis.");
            }
            else
            {
                Debug.LogWarning("Aucun Rigidbody référencé pour le colis !");
            }

            // Déplacement immédiat du joueur vers la destination spécifiée
            if (joueur != null && destinationSalle != null)
            {
                joueur.transform.position = destinationSalle.position;
                Debug.Log("Le joueur a été déplacé vers la destination.");
            }
            else
            {
                Debug.LogWarning("Référence(s) manquante(s) pour le joueur ou la destination !");
            }
        }
    }
}
