using UnityEngine;

public class BouttonTutoriel : MonoBehaviour
{
    // Référence vers le Rigidbody du colis (objet dont la gravité sera activée)
    public Rigidbody colisRigidbody; 

    // [SerializeField] public MurManager magnetScript ;

    // Tag du déclencheur (par exemple "bouton")
    public string tagCible = "bouton";


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
            // magnetScript.vitesse += augmentation;
        }
    }
}

