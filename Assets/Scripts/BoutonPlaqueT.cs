using UnityEngine;

public class BoutonPlaqueT : MonoBehaviour
{

    // Start is called once before the first execution of Update after the MonoBehaviour is created{
    // Référence vers le script Magnet attaché à l'objet cible
    public TourneManager magnetScript;

    // Valeur d'augmentation à ajouter à la force d'targetRotation actuelle
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
                // Ajouter la valeur d'augmentation à l'targetRotation actuelle
                magnetScript.targetRotation += augmentation;
                Debug.Log("Angle de la plaque " + augmentation + ". Nouvelle valeur: " + magnetScript.targetRotation);
            }
            else
            {
                Debug.LogWarning("La référence vers le script MurManager n'est pas renseignée !");
            }
        }
    }
}
