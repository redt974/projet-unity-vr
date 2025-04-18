using UnityEngine;

public class SpeedBoost : MonoBehaviour
{
    [SerializeField] public float boostMultiplier = 2f;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision détectée avec : " + other.name);


        if (other.CompareTag("Colis"))
        {
            Debug.Log("Tag 'Colis' identifié pour l'objet : " + other.name);

            Rigidbody rb = other.GetComponent<Rigidbody>();
            if (rb != null)
            {
                Debug.Log("Rigidbody trouvé sur " + other.name);
                Debug.Log("Vélocité avant boost : " + rb.linearVelocity);


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
