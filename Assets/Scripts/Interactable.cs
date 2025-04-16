using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    [SerializeField] private Renderer renderer;
    [SerializeField] private Color defaultColor = Color.white;

    protected bool isGrabbed = false;
    public Color hoverColor = Color.yellow;
    public Color highlightColor = Color.cyan;
    public UnityEvent OnHighlight = new UnityEvent();

    public void Hover(bool toggle)
    {
        if (renderer != null)
            renderer.material.color = toggle ? hoverColor : defaultColor;
    }

    public void Highlight(bool toggle)
    {
        if (renderer != null)
            renderer.material.color = toggle ? highlightColor : defaultColor;

        if (toggle)
        {
            OnHighlight?.Invoke();
        }
    }

    // Contexte pour transmettre la position
    public class InteractionContext
    {
        public Vector3 inputPosition;
        public float time;
    }

    // Méthodes virtuelles overrideables par les classes enfants
    public virtual void StartGrab() { isGrabbed = true; }
    public virtual void EndGrab() { isGrabbed = false; }
    public virtual void UpdateGrab(InteractionContext interaction) { }
}
