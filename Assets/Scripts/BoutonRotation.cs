using UnityEngine;

public class BoutonRotation : MonoBehaviour
{
    [SerializeField] private BouleChaine BouleChaine;
    [SerializeField] private float variationAngle = 15f;
    [SerializeField] private string tagCible = "bouton";

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(tagCible) && BouleChaine != null)
        {
            BouleChaine.ModifierAngle(variationAngle);
        }
    }
}
