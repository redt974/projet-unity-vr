using UnityEngine;

public class BoutonResetTutoriel : MonoBehaviour
{
 // Tag utilisé pour déclencher le reset.
    public string tagReset = "bouton";

    // Tag des objets "colis" qui doivent être réinitialisés.
    public string tagColis = "Object";
    [SerializeField] public MurManager magnetScript ;

    private void OnTriggerEnter(Collider other)
    {
        // Si l'objet entrant possède le tag "reset"
        if (other.CompareTag(tagReset))
        {
            magnetScript.vitesse = 0;
            ResetAllColis();
            
        }
    }

    private void ResetAllColis()
    {
        // Trouver tous les objets avec le tag "colis".
        GameObject[] colisObjects = GameObject.FindGameObjectsWithTag(tagColis);
        foreach (GameObject colis in colisObjects)
        {
            // Essayer de récupérer le script ResettableColis sur l'objet.
            InitialPosition resettable = colis.GetComponent<InitialPosition>();
            if (resettable != null)
            {
                resettable.ResetPosition();
            }
        }
        Debug.Log("Tous les colis ont été remis à leur position initiale.");
    }
}
