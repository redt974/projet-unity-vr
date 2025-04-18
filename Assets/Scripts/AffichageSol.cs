using UnityEngine;
using TMPro;

public class AffichageSol : MonoBehaviour
{
    [SerializeField] public SpeedBoost SpeedBoostScript;
    [SerializeField] public DecelerationZone DecelerationZoneScript;

    [SerializeField] public TMP_Text attractionText;

    void Update()
    {
        if (attractionText != null)
        {
            string text = "";

            if (SpeedBoostScript != null)
            {
                text += "Vitesse du sol : " + SpeedBoostScript.boostMultiplier.ToString("F2") + "\n";
            }
            else
            {
                text += "SpeedBoost non assigné.\n";
            }

            if (DecelerationZoneScript != null)
            {
                text += "Décélération : " + DecelerationZoneScript.decelerationRate.ToString("F2");
            }
            else
            {
                text += "DecelerationZone non assigné.";
            }

            attractionText.text = text;
        }
    }
}
