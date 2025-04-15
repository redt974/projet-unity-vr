using UnityEngine;
using UnityEngine.InputSystem;

public class Interactor : MonoBehaviour
{
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private GameObject manette;
    [SerializeField] private InputActionReference grabAction;
    [SerializeField] private InputActionReference positionAction;
    [SerializeField] private InputActionReference joystickMoveAction;
    [SerializeField] private float speedMultiplier = 1f;
    [SerializeField] private float moveSensitivity = 50f;
    [SerializeField] private LineRenderer lineRenderer;

    private Interactable lastHovered;
    private Interactable currentSelection;
    private Rigidbody currentRigidbody;
    private Vector3 previousPosition;
    private Vector3 speed;

    private bool isGrabbing;
    private bool isRotatingBoule;
    private Transform bouleTransform;
    private float currentDistance = 1f;

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
        lineRenderer.SetPosition(0, manette.transform.position - Vector3.up * 0.5f);
        lineRenderer.SetPosition(1, manette.transform.position);

        if (isGrabbing && currentSelection != null)
        {
            Vector2 joystickInput = joystickMoveAction.action.ReadValue<Vector2>();

            if (isRotatingBoule && bouleTransform != null)
            {
                float rotationAmount = joystickInput.x * moveSensitivity * Time.deltaTime;
                bouleTransform.Rotate(0f, rotationAmount, 0f, Space.World);
            }
            else
            {
                currentDistance += joystickInput.y * moveSensitivity * Time.deltaTime;
                currentDistance = Mathf.Clamp(currentDistance, 0.2f, 5f);

                Vector3 targetPosition = manette.transform.position + manette.transform.forward * currentDistance;
                speed = (targetPosition - previousPosition) / Time.deltaTime;
                previousPosition = targetPosition;

                if (currentRigidbody != null)
                    currentRigidbody.MovePosition(targetPosition);
            }
        }
        else
        {
            Ray ray = new Ray(manette.transform.position, manette.transform.forward);
            if (Physics.Raycast(ray, out RaycastHit hit, 100f, layerMask))
            {
                GameObject gO = hit.collider.gameObject;
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
        if (lastHovered == null) return;

        currentSelection = lastHovered;
        lastHovered = null;
        isGrabbing = true;
        previousPosition = manette.transform.position;

        if (currentSelection.CompareTag("Boule-Chaine"))
        {
            BouleChaine boule = currentSelection.GetComponent<BouleChaine>();
            if (boule != null)
            {
                boule.SetGrabbed(true);
                bouleTransform = boule.transform;
                isRotatingBoule = true;
            }
        }
        else
        {
            isRotatingBoule = false;
            bouleTransform = null;
        }

        if (currentSelection.TryGetComponent(out currentRigidbody))
        {
            currentRigidbody.isKinematic = true;
        }
    }

    private void OnRelease(InputAction.CallbackContext context)
    {
        if (currentSelection == null) return;

        currentSelection.Highlight(false);

        if (currentSelection.CompareTag("Boule-Chaine"))
        {
            BouleChaine boule = currentSelection.GetComponent<BouleChaine>();
            if (boule != null)
            {
                boule.SetGrabbed(false);
            }
        }

        if (currentRigidbody != null)
        {
            currentRigidbody.isKinematic = false;
            currentRigidbody.linearVelocity = speed * speedMultiplier;
            currentRigidbody = null;
        }

        currentSelection = null;
        isGrabbing = false;
        isRotatingBoule = false;
        bouleTransform = null;
    }

    private void OnDrawGizmos()
    {
        if (isRotatingBoule && bouleTransform != null)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(bouleTransform.position, 0.3f);

            Gizmos.color = Color.green;
            Gizmos.DrawLine(bouleTransform.position, bouleTransform.position + Vector3.up * 0.5f);
            Gizmos.DrawRay(bouleTransform.position, Vector3.right * 0.3f);
            Gizmos.DrawRay(bouleTransform.position, Vector3.forward * 0.3f);
        }
    }
}
