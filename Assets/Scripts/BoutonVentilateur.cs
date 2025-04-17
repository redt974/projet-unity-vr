using UnityEngine;

public class VentilateurBouton : MonoBehaviour
{
    [SerializeField] private Ventilateur ventilateur;
    [SerializeField] private float variation = 5f; 
    [SerializeField] private string tagCible = "bouton";
    [SerializeField] private bool isNegatif = true;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(tagCible) && ventilateur != null)
        {
            float nouvelleForce = ventilateur.forceDuVent + variation;

            if (isNegatif)
                nouvelleForce = Mathf.Max(0f, nouvelleForce);

            ventilateur.forceDuVent = nouvelleForce;

            string action = variation >= 0 ? "augmentée" : "diminuée";
            Debug.Log($"Force du vent {action} à : {ventilateur.forceDuVent}");
        }
    }
}
