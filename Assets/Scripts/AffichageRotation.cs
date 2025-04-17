using UnityEngine;
using TMPro;

public class AffichageRotation : MonoBehaviour
{
    [SerializeField] private BouleChaine BouleChaine;
    [SerializeField] private TMP_Text angleText;

    private void Update()
    {
        if (BouleChaine != null && angleText != null)
        {
            angleText.text = "Angle d'inclinaison : " + BouleChaine.GetAngle().ToString("F0") + "°";
        }
    }
}
