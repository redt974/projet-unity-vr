using System;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class Interactor : MonoBehaviour
{
    [SerializeField] private Camera camera;
    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private InputActionReference MouseClickAction;
    [SerializeField] private InputActionReference MousePosition;

    [SerializeField] private float ZValue;

    private Interactable lastHovered;

    private Interactable currentSelection;

    private Vector2 mousePosition;

    private Vector3 speed; 

    [SerializeField] private float speedMultiplier = 1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        MouseClickAction.action.performed += Click;
        MousePosition.action.performed += OnMousePosition;
    }

    private void OnMousePosition(CallbackContext callbackContext)
    {
       // Debug.Log(callbackContext.ReadValue<Vector2>());
        mousePosition = callbackContext.ReadValue<Vector2>();
    }

    private void Click(CallbackContext callbackContext)
    {
        Debug.Log("Click");
        //Si on a un objet s�lectionn�
        if (currentSelection != null)
        {
            currentSelection.Highlight(false);
            if(currentSelection.TryGetComponent(out Rigidbody rigi))
            {
                rigi.isKinematic = false;
                rigi.linearVelocity = speed * speedMultiplier;
            }
            currentSelection = null;
            return;
        }
        //Si on a pas d'objet d�tect�, on s'arr�te
        if (lastHovered == null) return;
        
        if(currentSelection == null)
        {  //Selection de l'objet
            lastHovered.Highlight(true);
            currentSelection = lastHovered;
            if(currentSelection.TryGetComponent(out Rigidbody rigi))
            {
                rigi.isKinematic = true;
            }
            lastHovered = null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        lineRenderer.SetPosition(0,camera.transform.position - Vector3.up * .5f);
        lineRenderer.SetPosition(1,camera.transform.position);
        var ray = camera.ScreenPointToRay(mousePosition);
        if(Physics.Raycast(ray,out RaycastHit hit,100,layerMask))
        {
            //On touche un objet
            var gO = hit.collider.gameObject;
            lineRenderer.SetPosition(1, hit.point);
            if (gO.TryGetComponent<Interactable>(out Interactable interactable))
            {
                if(interactable != currentSelection)
                {
                    interactable.Hover(true);
                    lastHovered = interactable;
                }
            }
        }
        else
        {
            if(lastHovered != null) lastHovered.Hover(false);
            lastHovered = null;
        }

        if(currentSelection != null) //On a un objet sélectionné
        {
            var mP = (Vector3)mousePosition;
            mP.z = Vector3.Distance(camera.transform.position,currentSelection.transform.position);
            Vector3 targetPosition = camera.ScreenToWorldPoint(mP);
            Debug.Log(targetPosition);
            targetPosition.z = currentSelection.transform.position.z;
            
            speed = (targetPosition - currentSelection.transform.position) / Time.deltaTime;
            
            currentSelection.transform.position = targetPosition;

        }
    }
}
