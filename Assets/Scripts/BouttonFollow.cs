using UnityEngine;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Interactable))]
public class BoutonFollow : MonoBehaviour
{
    [Header("Réglages du follow")]
    [Tooltip("L'objet visuel que l'on fera coulisser")]
    public Transform visualTarget;
    [Tooltip("Axe local de déplacement")]
    public Vector3 localAxis = Vector3.up;
    [Tooltip("Vitesse de retour")]
    public float resetSpeed = 5f;
    [Tooltip("Angle max entre la direction du poke et l'axe local")]
    public float followAngle = 90f;
    [Tooltip("Tag utilisé par le collider de l'interactor (pointeur)")]
    public string interactorTag = "Interactor";

    // état interne
    private Vector3 initialLocalPos;
    private bool isFollowing = false;
    private bool freeze = false;
    private Vector3 offset;
    private Transform pokeTransform;
    private Interactable interactable;

    void Start()
    {
        // s'assurer que le collider est trigger
        var col = GetComponent<Collider>();
        col.isTrigger = true;

        initialLocalPos = visualTarget.localPosition;
        interactable = GetComponent<Interactable>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (freeze) return;

        if (other.CompareTag(interactorTag))
        {
            // début du follow
            pokeTransform = other.transform;
            offset = visualTarget.position - pokeTransform.position;

            float angle = Vector3.Angle(offset, visualTarget.TransformDirection(localAxis));
            if (angle <= followAngle)
            {
                isFollowing = true;
                interactable.Highlight(true); // passe en couleur de "pressed"
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(interactorTag))
        {
            // fin du follow
            isFollowing = false;
            freeze = false;
            interactable.Highlight(false); // on désactive la couleur
        }
    }

    /// <summary>
    /// Peut être appelé depuis votre interactor (ex : dans OnGrab) 
    /// pour bloquer le bouton en position appuyée.
    /// </summary>
    public void FreezeButton()
    {
        freeze = true;
    }

    void Update()
    {
        if (freeze)
            return;

        if (isFollowing && pokeTransform != null)
        {
            // calcul de la position cible le long de l'axe local
            Vector3 worldTarget = pokeTransform.position + offset;
            Vector3 localTarget = visualTarget.InverseTransformPoint(worldTarget);
            Vector3 proj = Vector3.Project(localTarget, localAxis.normalized);
            visualTarget.localPosition = proj;
        }
        else
        {
            // retour progressif
            visualTarget.localPosition = Vector3.Lerp(
                visualTarget.localPosition,
                initialLocalPos,
                Time.deltaTime * resetSpeed
            );
        }
    }
}
