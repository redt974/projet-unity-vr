using UnityEngine;
using UnityEngine.AI; // Nécessaire pour utiliser NavMeshAgent

public class AIMovement : MonoBehaviour
{
    [SerializeField] public GameObject colis;   // Objet vers lequel on se déplace
    [SerializeField] private NavMeshAgent agent;

    void Start()
    {
        // On récupère le NavMeshAgent attaché à cet objet
        agent = GetComponent<NavMeshAgent>();

        // On trouve l'objet avec le tag "user"
        colis = GameObject.FindWithTag("user");
    }

    void Update()
    {
        // Vérification pour éviter une erreur si 'colis' n'est pas trouvé
        if (colis != null)
        {
            // On définit la destination du NavMeshAgent en se basant sur la position du colis
            agent.SetDestination(colis.transform.position);
        }
    }
}
