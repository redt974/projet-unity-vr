using UnityEngine;

public class MurCanon : MonoBehaviour
{
    public float hauteur = 3f;
    public float vitesse = 2f;

    [SerializeField] private ZoneCanon zone;

    private Vector3 startPos;
    private bool doitMonter = false;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        if (!doitMonter)
        {
            doitMonter = ZoneValidée();
        }

        if (doitMonter)
        {
            Vector3 pos = transform.position;
            pos.y += vitesse * Time.deltaTime;
            if (pos.y >= startPos.y + hauteur)
            {
                pos.y = startPos.y + hauteur;
                doitMonter = false;
            }
            transform.position = pos;
        }
    }

    private bool ZoneValidée()
    {
        if (!zone.EstValidee)
        {
            return false;
        }

        return true;
    }
}