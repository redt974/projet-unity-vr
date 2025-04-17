using UnityEngine;
using TMPro;

public class AffichageForceMur : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] public MurPoussoirManager force;


    [SerializeField] public TMP_Text attractionText;


    void Update()
    {
        if (force != null && attractionText != null)
        {

            attractionText.text = "Force du mur poussoir : " + force.force.ToString("F2");
        }
    }
}
