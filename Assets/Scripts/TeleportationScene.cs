using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportationScene : MonoBehaviour
{
    [SerializeField] private string sceneName; // Nom de la scène à charger

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Balle"))
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
