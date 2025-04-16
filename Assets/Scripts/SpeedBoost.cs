using UnityEngine;

public class SpeedBoost : MonoBehaviour
{
    [SerializeField] private float boostMultiplier = 2f; // Facteur par lequel la vitesse du colis sera multipliée

    // Méthode appelée lorsqu'un objet entre dans le trigger du sol bleu
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision détectée avec : " + other.name);

        // Vérifier que l'objet entrant est bien le colis
        if (other.CompareTag("Colis"))
        {
            Debug.Log("Tag 'Colis' identifié pour l'objet : " + other.name);

            // Récupérer le composant Rigidbody de l'objet
            Rigidbody rb = other.GetComponent<Rigidbody>();
            if (rb != null)
            {
                Debug.Log("Rigidbody trouvé sur " + other.name);
                Debug.Log("Vélocité avant boost : " + rb.linearVelocity);

                // Appliquer le boost de vitesse
                rb.linearVelocity = rb.linearVelocity * boostMultiplier;
                Debug.Log("Boost appliqué! Nouvelle vélocité : " + rb.linearVelocity);
            }
            else
            {
                Debug.LogWarning("Aucun Rigidbody trouvé sur " + other.name);
            }
        }
        else
        {
            Debug.Log("L'objet " + other.name + " n'a pas le tag 'Colis'. Aucune action effectuée.");
        }
    }
}
