using UnityEngine;
using TMPro;

public class AffichageMurNiv1 : MonoBehaviour
{
    [SerializeField] public MurPoussoirManager vitessemur;


    [SerializeField] public TMP_Text attractionText;


    void Update()
    {
        if (vitessemur != null && attractionText != null)
        {

            attractionText.text = "Vitesse du mur poussoir : " + vitessemur.vitessemur.ToString("F2");
        }
    }
}
