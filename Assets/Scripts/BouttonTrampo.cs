using UnityEngine;

public class BoutonTrampo: MonoBehaviour
{
    // Référence vers le script Magnet attaché à l'objet cible
    public TrampolineManager magnetScript;

    // Valeur d'augmentation à ajouter à la force d'force actuelle
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
                // Ajouter la valeur d'augmentation à l'force actuelle
                magnetScript.force += augmentation;
                Debug.Log("force augmentée de " + augmentation + ". Nouvelle valeur: " + magnetScript.force);
            }
            else
            {
                Debug.LogWarning("La référence vers le script MurManager n'est pas renseignée !");
            }
        }
    }
}
