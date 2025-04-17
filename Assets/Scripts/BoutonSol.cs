using UnityEngine;

public class BoutonSol : MonoBehaviour
{
    // Références vers les scripts attachés à l'objet cible
    public SpeedBoost SpeedBoostScript;
    public DecelerationZone DecelerationZoneScript;

    // Valeur d'augmentation à ajouter à la force d'attraction actuelle
    public float augmentation = 5f;
    public float augmentationdeceleration = 1f;

    // Optionnel : permet de limiter l'activation à un objet ayant un tag précis (exemple "Player")
    public string tagCible = "bouton";

    // OnTriggerEnter est appelée quand un autre collider entre dans le trigger attaché à cet objet
    private void OnTriggerEnter(Collider other)
    {
        // Vérifier que l'objet entrant possède le tag voulu
        if (other.CompareTag(tagCible))
        {
            if (SpeedBoostScript != null)
            {
                SpeedBoostScript.boostMultiplier += augmentation;
                Debug.Log("Boost augmenté de " + augmentation + ". Nouvelle valeur: " + SpeedBoostScript.boostMultiplier);
            }
            else
            {
                Debug.LogWarning("Référence au script SpeedBoost manquante !");
            }

            if (DecelerationZoneScript != null)
            {
                DecelerationZoneScript.decelerationRate += augmentationdeceleration;
                Debug.Log("Zone de décélération agrandie.");
            }
            else
            {
                Debug.LogWarning("Référence au script DecelerationZone manquante !");
            }
        }
    }
}
