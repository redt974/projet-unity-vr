using UnityEngine;

public class Magnet : MonoBehaviour
{
    [SerializeField] public GameObject magnet;   // Objet vers lequel on est attiré
    [SerializeField] public float attraction = 10f;
    [SerializeField] private float maxDistance = 10f;
    [SerializeField] private float actualDistance;

    // Start est appelé une fois au début
    void Start()
    {
    }

    // Update est appelé à chaque frame
    void Update()
    {
        // Calcul de la distance entre l'objet 'magnet' et l'objet courant (celui auquel ce script est attaché)
        actualDistance = Vector3.Distance(magnet.transform.position, transform.position);

        // Si la distance est inférieure ou égale à la distance maximale, appliquer une force d'attraction
        if (actualDistance <= maxDistance)
        {
            // La force est appliquée dans la direction allant de l'objet courant vers le 'magnet'
            Vector3 direction = (magnet.transform.position - transform.position).normalized;
            GetComponent<Rigidbody>().AddForce(direction * attraction * Time.deltaTime);
        }
    }
}
