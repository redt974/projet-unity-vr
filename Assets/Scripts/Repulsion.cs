using UnityEngine;

public class Repulsion : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] public GameObject magnet;
    [SerializeField] public float repulsionForce = 10f;
    [SerializeField] private float maxDistance = 10f;
    [SerializeField] private float actualDistance;

    void Update()
    {
        // Calcul de la distance entre l'objet "magnet" et l'objet courant
        actualDistance = Vector3.Distance(magnet.transform.position, transform.position);

        // Si la distance est inférieure ou égale à la distance maximale, appliquer une force de repulsion
        if (actualDistance <= maxDistance)
        {
            // Calcul de la direction allant du "magnet" vers cet objet (inversion de la direction d'attraction)
            Vector3 direction = (transform.position - magnet.transform.position).normalized;
            GetComponent<Rigidbody>().AddForce(direction * repulsionForce * Time.deltaTime);
        }
    }

}
