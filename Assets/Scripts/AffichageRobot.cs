using UnityEngine;
using TMPro;

public class AffichageRobot : MonoBehaviour
{
    [SerializeField] public AIComponent RobotScript;


    [SerializeField] public TMP_Text attractionText;


    void Update()
    {
        if (RobotScript.throwForce != null && attractionText != null)
        {

            attractionText.text = "Puissance d'attraction : " + RobotScript.throwForce.ToString("F2");
        }
    }
}
