using UnityEngine;

public class CanonBouton : MonoBehaviour
{
   // Référence vers le script Magnet attaché à l'objet cible
   public Canon canonScript;

   public string tagCible = "bouton";

   // OnTriggerEnter est appelée quand un autre collider entre dans le trigger attaché à cet objet
   private void OnTriggerEnter(Collider other)
   {
      // Vérifier que l'objet entrant possède le tag voulu
      if (other.CompareTag(tagCible))
      {
         if (canonScript != null)
         {
            canonScript.Shoot();
            Debug.Log("Canon tiré !");
         }
         else
         {
            Debug.LogWarning("Référence au script Canon manquante !");
         }
      }
   }
}
