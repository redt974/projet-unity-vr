using UnityEngine;

public class ZoneCanon : MonoBehaviour
{
    [SerializeField] private Canon canon;
    [SerializeField] private Renderer zoneRenderer;
    [SerializeField] private Color defaultColor = Color.white;
    [SerializeField] private Color activeColor = Color.green;

    public bool EstValidee { get; private set; } = false;

    private void Start()
    {
        if (zoneRenderer != null)
        {
            zoneRenderer.material.color = defaultColor;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Missile") && !EstValidee)
        {
            EstValidee = true;
            UpdateColor(true);
        }
    }

    private void UpdateColor(bool active)
    {
        if (zoneRenderer != null)
        {
            zoneRenderer.material.color = active ? activeColor : defaultColor;
        }
    }
}
