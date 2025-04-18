using UnityEngine;

public class Magnet : MonoBehaviour
{
    [SerializeField] public GameObject magnet;
    [SerializeField] public float attraction = 10f;
    [SerializeField] private float maxDistance = 10f;
    [SerializeField] private float actualDistance;


    void Start()
    {
    }


    void Update()
    {

        actualDistance = Vector3.Distance(magnet.transform.position, transform.position);


        if (actualDistance <= maxDistance)
        {

            Vector3 direction = (magnet.transform.position - transform.position).normalized;
            GetComponent<Rigidbody>().AddForce(direction * attraction * Time.deltaTime);
        }
    }
}
