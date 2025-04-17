using UnityEngine;

public class BoutonMurNiv1 : MonoBehaviour
{
    // Référence vers le script Magnet attaché à l'objet cible
    public MurPoussoirManager magnetScript;

    // Valeur d'augmentation à ajouter à la force d'vitessemur actuelle
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
                // Ajouter la valeur d'augmentation à l'vitessemur actuelle
                magnetScript.vitessemur += augmentation;
                Debug.Log("Vitesse du mur augmentée de " + augmentation + ". Nouvelle valeur: " + magnetScript.vitessemur);
            }
            else
            {
                Debug.LogWarning("La référence vers le script MurManager n'est pas renseignée !");
            }
        }
    }
}
