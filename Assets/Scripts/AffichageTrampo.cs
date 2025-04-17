using UnityEngine;
using TMPro;

public class AffichageTrampo : MonoBehaviour
{
    [SerializeField] public TrampolineManager force;


    [SerializeField] public TMP_Text attractionText;


    void Update()
    {
        if (force != null && attractionText != null)
        {

            attractionText.text = "Force du trampoline : " + force.force.ToString("F2");
        }
    }
}
