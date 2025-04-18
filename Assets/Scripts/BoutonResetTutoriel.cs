using UnityEngine;

public class BoutonResetTutoriel : MonoBehaviour
{
    public string tagBouton = "bouton";

    public string tagColis = "Boule";


    public string tagObjet = "Objet";

    [SerializeField] public MurManager magnetScript;


    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag(tagBouton))
        {
            ResetAllTaggedObjects();
            magnetScript.vitesse = 0;
        }
    }

    private void ResetAllTaggedObjects()
    {

        ResetByTag(tagColis);


        ResetByTag(tagObjet);

        ResetByTag(tagBouton);

        Debug.Log("Tous les colis et objets ont été remis à leur position initiale.");
    }

    private void ResetByTag(string tag)
    {

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
