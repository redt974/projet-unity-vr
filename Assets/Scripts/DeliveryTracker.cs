using UnityEngine;
using TMPro;


public class DeliveryTracker : MonoBehaviour
{

    public Collider deliveryPointTrigger;


    public TMP_Text timeText;
    public TMP_Text distanceText;
    public TMP_Text scoreText;

    private float startTime;
    private float totalTime;
    private float distanceTraveled;
    private Vector3 lastPosition;
    private bool hasDelivered = false;

    void Start()
    {

        startTime = Time.time;
        lastPosition = transform.position;
        distanceTraveled = 0f;


        timeText.text = "";
        distanceText.text = "";
        scoreText.text = "";
    }

    void Update()
    {
        if (hasDelivered) return;


        Vector3 currentPos = transform.position;
        distanceTraveled += Vector3.Distance(currentPos, lastPosition);
        lastPosition = currentPos;
    }

    void OnTriggerEnter(Collider other)
    {

        if (!hasDelivered && other == deliveryPointTrigger)
        {
            hasDelivered = true;
            FinishDelivery();
        }
    }

    private void FinishDelivery()
    {

        totalTime = Time.time - startTime;


        timeText.text = $"Temps total : {totalTime:F2} s";
        distanceText.text = $"Distance parcourue : {distanceTraveled:F2} m";
        scoreText.text = "Score : 100 %";


        Debug.Log("Livraison terminée !");
        Debug.Log(timeText.text);
        Debug.Log(distanceText.text);
        Debug.Log(scoreText.text);
    }
}
