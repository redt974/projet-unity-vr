using UnityEngine;
using TMPro;

public class AffichageVentilateur : MonoBehaviour
{
    [SerializeField] public Ventilateur ventilateur;
    [SerializeField] public TMP_Text forceText;

    void Update()
    {
        if (ventilateur != null && forceText != null)
        {
            forceText.text = "Force du vent : " + ventilateur.forceDuVent.ToString("F2");
        }
    }
}
