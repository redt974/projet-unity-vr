using UnityEngine;

public class resetWorld : MonoBehaviour
{

    public string tagBouton = "bouton";


    public string tagColis = "Balle";


    public string tagObjet = "Objet";

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag(tagBouton))
        {
            ResetAllTaggedObjects();
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
