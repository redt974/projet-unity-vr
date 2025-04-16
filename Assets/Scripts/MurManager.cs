using UnityEngine;

public class MurManager : MonoBehaviour
{
    public float hauteur = 3f; // Distance de montée/descente
    public float vitesse = 2f;   // Vitesse de déplacement

    private Vector3 startPos;
    private bool monte = true;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        Vector3 pos = transform.position;

        // Déplacement linéaire
        if (monte)
        {
            pos.y += vitesse * Time.deltaTime;
            if (pos.y >= startPos.y + hauteur)
            {
                pos.y = startPos.y + hauteur;
                monte = false;
            }
        }
        else
        {
            pos.y -= vitesse * Time.deltaTime;
            if (pos.y <= startPos.y)
            {
                pos.y = startPos.y;
                monte = true;
            }
        }

        transform.position = pos;
    }
}
