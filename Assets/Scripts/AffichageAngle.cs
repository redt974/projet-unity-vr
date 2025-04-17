using UnityEngine;
using TMPro;

public class AffichageAngle : MonoBehaviour
{
    [SerializeField] public TourneManager targetRotation;


    [SerializeField] public TMP_Text attractionText;


    void Update()
    {
        if (targetRotation != null && attractionText != null)
        {

            attractionText.text = "Rotation du mur : " + targetRotation.targetRotation.ToString("F2");
        }
    }
}
