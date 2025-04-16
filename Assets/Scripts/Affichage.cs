using UnityEngine;
using TMPro;

public class Affichage : MonoBehaviour
{
    [SerializeField] public Magnet magnet;


    [SerializeField] public TMP_Text attractionText;


    void Update()
    {
        if (magnet != null && attractionText != null)
        {

            attractionText.text = "Puissance d'attraction : " + magnet.attraction.ToString("F2");
        }
    }
}
