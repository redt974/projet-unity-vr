using UnityEngine;
using TMPro;

public class BoutonTimer : MonoBehaviour
{
    // Référence vers le Rigidbody du colis (l'objet sur lequel la gravité sera désactivée/réactivée)
    public Rigidbody colisRigidbody;

    // Durée du timer (en secondes)
    public float dureeTimer = 10f;
    private float timer;

    // Référence au Text UI pour afficher le compte à rebours
    public TMP_Text texteTimer;

    // Tag pour activer le bouton (par exemple "Player")
    public string tagCible = "bouton";

    // Référence vers le joueur à téléporter
    public GameObject joueur;

    // Destination où le joueur sera téléporté après le compte à rebours
    public Transform destinationSalle;

    // Indique si le timer est en cours
    private bool timerEnCours = false;

    // OnTriggerEnter est appelé quand un collider entre dans le trigger de cet objet
    private void OnTriggerEnter(Collider other)
    {
        // Vérifier que l'objet entrant possède le tag ciblé et que le timer n'a pas déjà démarré
        if (other.CompareTag(tagCible) && !timerEnCours)
        {
            timerEnCours = true;
            timer = dureeTimer;

            // Désactivation de la gravité sur le colis
            if (colisRigidbody != null)
            {
                colisRigidbody.useGravity = false;
                Debug.Log("Gravité désactivée pour le colis.");
            }
            else
            {
                Debug.LogWarning("Aucun Rigidbody référencé pour le colis !");
            }
        }
    }

    // Update est appelée à chaque frame
    private void Update()
    {
        if (timerEnCours)
        {
            timer -= Time.deltaTime;

            // Mise à jour de l'affichage du timer
            if (texteTimer != null)
            {
                texteTimer.text = "Temps restant : " + Mathf.Ceil(timer).ToString();
            }

            // Vérification si le temps est écoulé
            if (timer <= 0)
            {
                TerminerTimer();
            }
        }
    }

    // Méthode pour terminer le timer et réactiver la physique et téléporter le joueur
    private void TerminerTimer()
    {
        timerEnCours = false;

        // Réactivation de la gravité sur le colis
        if (colisRigidbody != null)
        {
            colisRigidbody.useGravity = true;
            Debug.Log("Gravité réactivée pour le colis.");
        }

        // Téléportation du joueur dans la salle prévue
        if (joueur != null && destinationSalle != null)
        {
            joueur.transform.position = destinationSalle.position;
            Debug.Log("Le joueur a été téléporté dans la salle.");
        }
        else
        {
            Debug.LogWarning("Références joueur ou destination salle manquantes !");
        }

        // Réinitialiser le texte du timer (optionnel)
        if (texteTimer != null)
        {
            texteTimer.text = "";
        }
    }
}
