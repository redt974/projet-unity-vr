using UnityEngine;

public class BoutonStart : MonoBehaviour
{

    public Rigidbody colisRigidbody;


    public string tagCible = "bouton";


    public GameObject joueur;


    public Transform destinationSalle;


    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag(tagCible))
        {

            if (colisRigidbody != null)
            {
                colisRigidbody.useGravity = true;
                Debug.Log("Gravité activée sur le colis.");
            }
            else
            {
                Debug.LogWarning("Aucun Rigidbody référencé pour le colis !");
            }


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
