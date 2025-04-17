using UnityEngine;

public class resetWorld : MonoBehaviour
{
    // Tag utilisé pour déclencher le reset.
    public string tagBouton = "bouton";

    // Tag des objets "colis" qui doivent être réinitialisés.
    public string tagColis = "Balle";

    // Tag des autres objets à réinitialiser.
    public string tagObjet = "Objet";

    private void OnTriggerEnter(Collider other)
    {
        // Si l'objet entrant possède le tag "reset"
        if (other.CompareTag(tagBouton))
        {
            ResetAllTaggedObjects();
        }
    }

    private void ResetAllTaggedObjects()
    {
        // Réinitialiser tous les colis
        ResetByTag(tagColis);

        // Réinitialiser tous les autres objets
        ResetByTag(tagObjet);

        ResetByTag(tagBouton);

        Debug.Log("Tous les colis et objets ont été remis à leur position initiale.");
    }

    private void ResetByTag(string tag)
    {
        // Trouver tous les objets avec le tag spécifié.
        GameObject[] objects = GameObject.FindGameObjectsWithTag(tag);
        foreach (GameObject obj in objects)
        {

            InitialPosition resettable = obj.GetComponent<InitialPosition>();
            if (resettable != null)
            {
                resettable.ResetPosition();
            }

        }
    }
}
