using UnityEngine;

public class BoutonRobot : MonoBehaviour
{

    public AIComponent RobotScript;


    public float augmentation = 5f;


    public string tagCible = "bouton";


    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag(tagCible))
        {
            if (RobotScript != null)
            {

                RobotScript.throwForce += augmentation;
                Debug.Log("Force du mur poussoir augmentée de " + augmentation + ". Nouvelle valeur: " + RobotScript.throwForce);
            }
            else
            {
                Debug.LogWarning("La référence vers le script MurManager n'est pas renseignée !");
            }
        }
    }
}
