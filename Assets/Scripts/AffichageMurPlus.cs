using UnityEngine;
using TMPro;

public class AffichageMur : MonoBehaviour
{
    [SerializeField] public MurManager vitesse;


    [SerializeField] public TMP_Text attractionText;


    void Update()
    {
        if (vitesse != null && attractionText != null)
        {

            attractionText.text = "Vitesse du mur : " + vitesse.vitesse.ToString("F2");
        }
    }
}
