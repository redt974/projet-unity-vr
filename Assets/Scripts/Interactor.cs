using UnityEngine;
using UnityEngine.InputSystem;

public class Interactor : MonoBehaviour
{
    [Header("Inputs")]
    [SerializeField] private InputActionReference grabAction;
    [SerializeField] private InputActionReference positionAction;

    [Header("Manette / Souris")]
    [SerializeField] private GameObject manette;
    [SerializeField] private bool debugWithMouse = true;
    [SerializeField] private Camera debugCamera;

    [Header("Interaction")]
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private float speedMultiplier = 1f;

    private Interactable lastHovered;
    private Interactable currentSelection;
    private Rigidbody currentRigidbody;
    private bool isGrabbing;
    private Vector3 previousPosition;
    private Vector3 speed;

    // Tags spéciaux qui ont une logique physique (MovePosition)
    [SerializeField] private string[] physicsTags = new[] { "BouleChaine", "Canon" };
    private bool usePhysicsGrab = false;

    private void OnEnable()
    {
        grabAction.action.performed += OnGrab;
        grabAction.action.canceled += OnRelease;

        grabAction.action.Enable();
        positionAction.action.Enable();
    }

    private void OnDisable()
    {
        grabAction.action.performed -= OnGrab;
        grabAction.action.canceled -= OnRelease;

        grabAction.action.Disable();
        positionAction.action.Disable();
    }

    private void Update()
    {
        if (debugWithMouse && !isGrabbing)
        {
            if (Mouse.current.leftButton.wasPressedThisFrame)
            {
                Ray ray = debugCamera.ScreenPointToRay(Mouse.current.position.ReadValue());
                if (Physics.Raycast(ray, out RaycastHit hit, 100f, layerMask))
                {
                    if (hit.collider.TryGetComponent<Interactable>(out Interactable interactable))
                    {
                        lastHovered = interactable;
                        OnGrab(new InputAction.CallbackContext());
                    }
                }
            }
            else if (Mouse.current.leftButton.wasReleasedThisFrame)
            {
                OnRelease(new InputAction.CallbackContext());
            }
        }

        if (isGrabbing && currentSelection != null)
        {
            Vector3 targetPosition = manette.transform.position + manette.transform.forward * Vector3.Distance(manette.transform.position, currentSelection.transform.position);
            speed = (targetPosition - previousPosition) / Time.deltaTime;
            previousPosition = targetPosition;

            if (usePhysicsGrab && currentRigidbody != null)
            {
                currentRigidbody.MovePosition(targetPosition);
            }
            else
            {
                currentSelection.transform.position = targetPosition;
            }
        }
    }

    private void OnGrab(InputAction.CallbackContext context)
    {
        if (lastHovered != null)
        {
            currentSelection = lastHovered;

            // Détection du comportement physique via le tag
            usePhysicsGrab = false;
            foreach (var tag in physicsTags)
            {
                if (currentSelection.CompareTag(tag))
                {
                    usePhysicsGrab = true;
                    break;
                }
            }

            if (currentSelection.TryGetComponent(out currentRigidbody))
            {
                if (!usePhysicsGrab)
                    currentRigidbody.isKinematic = true;
            }

            isGrabbing = true;
            previousPosition = manette.transform.position;
            lastHovered = null;
        }
    }

    private void OnRelease(InputAction.CallbackContext context)
    {
        if (currentSelection != null)
        {
            currentSelection.Highlight(false);
            if (currentRigidbody != null)
            {
                if (!usePhysicsGrab)
                    currentRigidbody.isKinematic = false;

                currentRigidbody.linearVelocity = speed * speedMultiplier;
            }

            currentSelection = null;
            currentRigidbody = null;
            isGrabbing = false;
            usePhysicsGrab = false;
        }
    }
}
