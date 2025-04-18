using UnityEngine;
using UnityEngine.AI;

public class AIComponent : MonoBehaviour
{
    [SerializeField] private GameObject colis;
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Transform destination;
    [SerializeField] private float pickupDistance = 2f;
    [SerializeField] public float throwForce = 10f;

    private bool hasPickedUp = false;
    private bool hasThrown = false;

    void Start()
    {

        agent = GetComponent<NavMeshAgent>();


        if (colis == null)
        {
            colis = GameObject.FindWithTag("Pcolis");
        }
    }

    void Update()
    {

        if (!hasPickedUp && colis != null)
        {
            agent.SetDestination(colis.transform.position);

            if (Vector3.Distance(transform.position, colis.transform.position) <= pickupDistance)
            {
                PickUp();
            }
        }

        else if (hasPickedUp && !hasThrown)
        {

            ThrowPackage();
        }
    }


    void PickUp()
    {
        hasPickedUp = true;

        colis.transform.SetParent(transform);


        Rigidbody rb = colis.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.isKinematic = true;
        }


        colis.transform.localPosition = new Vector3(0, 1, 0);

        Debug.Log("Colis ramassé !");
    }

    void ThrowPackage()
    {
        hasThrown = true;


        colis.transform.SetParent(null);

        Rigidbody rb = colis.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.isKinematic = false;

            Vector3 throwDirection = (destination.position - colis.transform.position).normalized;


            throwDirection.y = Mathf.Abs(throwDirection.y) + 0.5f;


            rb.AddForce(throwDirection * throwForce, ForceMode.Impulse);
        }

        Debug.Log("Colis lancé !");

        colis = null;
    }
}
