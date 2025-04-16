using UnityEngine;

public class Bouton : MonoBehaviour
{
    // Référence vers le script Magnet attaché à l'objet cible
    public Magnet magnetScript;

    // Valeur d'augmentation à ajouter à la force d'attraction actuelle
    public float augmentation = 5f;

    // Optionnel : permet de limiter l'activation à un objet ayant un tag précis (exemple "Player")
    public string tagCible = "bouton";

    // OnTriggerEnter est appelée quand un autre collider entre dans le trigger attaché à cet objet
    private void OnTriggerEnter(Collider other)
    {
        // Vérifier que l'objet entrant possède le tag voulu
        if (other.CompareTag(tagCible))
        {
            if (magnetScript != null)
            {
                // Ajouter la valeur d'augmentation à l'attraction actuelle
                magnetScript.attraction += augmentation;
                Debug.Log("Attraction augmentée de " + augmentation + ". Nouvelle valeur: " + magnetScript.attraction);
            }
            else
            {
                Debug.LogWarning("La référence vers le script Magnet n'est pas renseignée !");
            }
        }
    }
}
