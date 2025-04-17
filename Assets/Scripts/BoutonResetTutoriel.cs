using UnityEngine;

public class BoutonResetTutoriel : MonoBehaviour
{
    // Tag utilisé pour déclencher le reset.
    public string tagBouton = "bouton";

    // Tag des objets "colis" qui doivent être réinitialisés.
    public string tagColis = "Boule";

    // Tag des autres objets à réinitialiser.
    public string tagObjet = "Objet";

    [SerializeField] public MurManager magnetScript ;


    private void OnTriggerEnter(Collider other)
    {
        // Si l'objet entrant possède le tag "reset"
        if (other.CompareTag(tagBouton))
        {
            ResetAllTaggedObjects();
            magnetScript.vitesse = 0; // Réinitialiser la vitesse à 0
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
