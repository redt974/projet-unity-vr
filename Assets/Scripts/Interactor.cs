using UnityEngine;
using UnityEngine.InputSystem;

public class Interactor : MonoBehaviour
{
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private GameObject manette;
    [SerializeField] private InputActionReference grabAction;
    [SerializeField] private InputActionReference positionAction;
    [SerializeField] private float speedMultiplier = 1f;
    [SerializeField] private LineRenderer lineRenderer;

    private Interactable lastHovered;
    private Interactable currentSelection;
    private Vector3 speed;
    private bool isGrabbing;
    private Rigidbody currentRigidbody;
    private Vector3 previousPosition;
    [SerializeField] private InputActionReference joystickMoveAction;
    [SerializeField] private float moveSensitivity = 0.5f;
    private float currentDistance = 1f; // distance initiale

    private void OnEnable()
    {
        grabAction.action.performed += OnGrab;
        grabAction.action.canceled += OnRelease;

        grabAction.action.Enable();
        positionAction.action.Enable();
        joystickMoveAction.action.Enable();
    }

    private void OnDisable()
    {
        grabAction.action.performed -= OnGrab;
        grabAction.action.canceled -= OnRelease;

        grabAction.action.Disable();
        positionAction.action.Disable();
        joystickMoveAction.action.Disable();
    }
    private void Update()
    {
        lineRenderer.SetPosition(0, manette.transform.position - Vector3.up * .5f);
        lineRenderer.SetPosition(1, manette.transform.position);

        if (isGrabbing && currentSelection != null)
        {
            // Lire le mouvement du joystick vertical (axe Y)
            Vector2 joystickInput = joystickMoveAction.action.ReadValue<Vector2>();
            currentDistance += joystickInput.y * moveSensitivity * Time.deltaTime;
            currentDistance = Mathf.Clamp(currentDistance, 0.2f, 5f); // Limite la distance

            Vector3 targetPosition = manette.transform.position + manette.transform.forward * currentDistance;

            speed = (targetPosition - previousPosition) / Time.deltaTime;
            previousPosition = targetPosition;

            currentSelection.transform.position = targetPosition;
        }
        else
        {
            Ray ray = new Ray(manette.transform.position, manette.transform.forward);
            if (Physics.Raycast(ray, out RaycastHit hit, 100f, layerMask))
            {
                var gO = hit.collider.gameObject;
                if (gO.TryGetComponent<Interactable>(out Interactable interactable))
                {
                    if (interactable != currentSelection)
                    {
                        interactable.Hover(true);
                        lastHovered = interactable;
                    }
                }
            }
            else if (lastHovered != null)
            {
                lastHovered.Hover(false);
                lastHovered = null;
            }
        }
    }

    private void OnGrab(InputAction.CallbackContext context)
    {
        Debug.Log("Gâchette pressée.");

        if (lastHovered != null)
        {
            currentSelection = lastHovered;
            if (currentSelection.TryGetComponent(out currentRigidbody))
            {
                currentRigidbody.isKinematic = true;
            }
            lastHovered = null;
            isGrabbing = true;

            // Récupération de la position de la manette au moment du clic
            previousPosition = manette.transform.position;
        }
    }

    private void OnRelease(InputAction.CallbackContext context)
    {
        Debug.Log("Gâchette relâchée.");

        if (currentSelection != null)
        {
            currentSelection.Highlight(false);
            if (currentRigidbody != null)
            {
                currentRigidbody.isKinematic = false;
                currentRigidbody.linearVelocity = speed * speedMultiplier; // Applique la vitesse calculée
                currentRigidbody = null; // Remet à null pour éviter des références invalides
            }
            currentSelection = null;
            isGrabbing = false;
        }
    }
}