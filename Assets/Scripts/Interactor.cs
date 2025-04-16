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
        // Line renderer
        if (lineRenderer != null)
        {
            lineRenderer.SetPosition(0, manette.transform.position - Vector3.up * 0.5f);
            lineRenderer.SetPosition(1, manette.transform.position);
        }

        if (isGrabbing && currentSelection != null)
        {
            currentSelection.UpdateGrab(new Interactable.InteractionContext { inputPosition = manette.transform.position, time = Time.time });
        }
        else
        {
            Ray ray = new Ray(manette.transform.position, manette.transform.forward);
            if (Physics.Raycast(ray, out RaycastHit hit, 100f, layerMask))
            {
                GameObject gO = hit.collider.gameObject;
                if (gO.TryGetComponent(out Interactable interactable))
                {
                    if (interactable != lastHovered)
                    {
                        lastHovered?.Hover(false); // Unhover previous
                        interactable.Hover(true);
                        lastHovered = interactable;
                    }
                }
            }
            else
            {
                lastHovered?.Hover(false);
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

            currentSelection.StartGrab();
            currentSelection.Highlight(true);

            lastHovered.Hover(false);
            lastHovered = null;

            isGrabbing = true;
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
                currentRigidbody.linearVelocity = speed * speedMultiplier;
                currentRigidbody = null;
            }

            currentSelection.EndGrab();
            currentSelection = null;
            isGrabbing = false;
        }
    }
}
