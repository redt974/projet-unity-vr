using UnityEngine;
using UnityEngine.AI;

public class AIComponent : MonoBehaviour
{
    [SerializeField] private GameObject colis;         // Le colis à récupérer (assignable ou recherché par tag)
    [SerializeField] private NavMeshAgent agent;         // Le composant NavMeshAgent du robot
    [SerializeField] private Transform destination;      // Le point de livraison (destination du lancer)
    [SerializeField] private float pickupDistance = 2f;    // Distance minimale pour ramasser le colis
    [SerializeField] private float throwForce = 10f;       // Force appliquée au colis lors du lancer

    private bool hasPickedUp = false;
    private bool hasThrown = false;

    void Start()
    {
        // Récupération du composant NavMeshAgent attaché au robot
        agent = GetComponent<NavMeshAgent>();

        // Si le colis n'a pas été assigné dans l'inspecteur, on le cherche par tag (exemple "user")
        if (colis == null)
        {
            colis = GameObject.FindWithTag("Pcolis");
        }
    }

    void Update()
    {
        // Phase 1 : Se rendre vers le colis pour le ramasser
        if (!hasPickedUp && colis != null)
        {
            agent.SetDestination(colis.transform.position);

            if (Vector3.Distance(transform.position, colis.transform.position) <= pickupDistance)
            {
                PickUp();
            }
        }
        // Phase 2 : Dès que le colis est ramassé, le lancer vers le point de livraison
        else if (hasPickedUp && !hasThrown)
        {
            // Ici, on lance directement le colis sans se déplacer vers la destination.
            // Si vous souhaitez intégrer une attente (animation, délai, etc.), vous pouvez ajouter une condition ou une temporisation.
            ThrowPackage();
        }
    }

    // Méthode pour ramasser le colis
    void PickUp()
    {
        hasPickedUp = true;
        // Rattache le colis au robot pour qu'il soit transporté avec lui
        colis.transform.SetParent(transform);

        // Récupère et modifie le Rigidbody pour éviter que la physique n'interfère pendant le déplacement
        Rigidbody rb = colis.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.isKinematic = true;
        }

        // Positionne le colis de façon relative (par exemple, au-dessus du robot)
        colis.transform.localPosition = new Vector3(0, 1, 0);

        Debug.Log("Colis ramassé !");
    }

    // Méthode pour projeter le colis vers le point de livraison
    void ThrowPackage()
    {
        hasThrown = true;

        // Détache le colis du robot afin que la physique puisse reprendre le dessus
        colis.transform.SetParent(null);

        Rigidbody rb = colis.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.isKinematic = false;
            // On calcule la direction à partir de la position actuelle du colis vers la destination
            Vector3 throwDirection = (destination.position - colis.transform.position).normalized;

            // Pour simuler un arc, vous pouvez ajouter une composante verticale si besoin
            // Exemple: force verticale additionnelle (si la destination est à la même hauteur, cela crée une belle trajectoire)
            throwDirection.y = Mathf.Abs(throwDirection.y) + 0.5f;

            // Application d'une force instantanée (Impulse) pour lancer le colis
            rb.AddForce(throwDirection * throwForce, ForceMode.Impulse);
        }

        Debug.Log("Colis lancé !");
        // Optionnel : réinitialiser la référence au colis pour éviter d'exécuter plusieurs fois le lancer
        colis = null;
    }
}
