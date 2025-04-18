using UnityEngine;

public class BoutonSol : MonoBehaviour
{

    public SpeedBoost SpeedBoostScript;
    public DecelerationZone DecelerationZoneScript;


    public float augmentation = 5f;
    public float augmentationdeceleration = 1f;


    public string tagCible = "bouton";


    private void OnTriggerEnter(Collider other)
    {

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
