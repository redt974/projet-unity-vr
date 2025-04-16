using UnityEngine;
using UnityEngine.InputSystem;

public class Canon : Interactable
{
    public Vector3 inputPosition;
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private float timeToTarget = 2f;
    [SerializeField] private InputActionReference shootAction;
    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private Transform canonPivot;
    [SerializeField] private Transform target; // La cible à atteindre
    [SerializeField] private int trajectoryPoints = 30;
    [SerializeField] private float timeStep = 0.1f;


    private void OnEnable()
    {
        shootAction?.action.Enable();
    }

    private void OnDisable()
    {
        shootAction?.action.Disable();
    }

    public override void StartGrab()
    {
        base.StartGrab();
        lineRenderer.enabled = true;

        Rigidbody rigi = GetComponent<Rigidbody>();
        if (rigi != null)
            rigi.isKinematic = true; // toujours kinematic
    }

    public override void EndGrab()
    {
        base.EndGrab();
        lineRenderer.enabled = false;
    }

    public override void UpdateGrab(InteractionContext interaction)
    {
        base.UpdateGrab(interaction);
        if (interaction != null)
        {
            inputPosition = interaction.inputPosition;
        }
    }

    private void Update()
    {
        if (!isGrabbed) return;

        if (target == null || spawnPoint == null || lineRenderer == null) return;

        // Calcul de la vélocité initiale pour atteindre la cible
        Vector3 initialVelocity = GetInitialVelocity(spawnPoint.position, target.position, timeToTarget);

        // Orientation du canon
        Vector3 direction = initialVelocity.normalized;
        if (direction != Vector3.zero)
        {
            canonPivot.forward = Vector3.Lerp(canonPivot.forward, direction, Time.deltaTime * 5f);
        }

        // Mise à jour de la trajectoire
        UpdateAngle(initialVelocity);

        // Tir manuel
        if (shootAction != null && shootAction.action.WasPressedThisFrame())
        {
            Shoot(initialVelocity);
        }
    }

    private void Shoot(Vector3 initialVelocity)
    {
        GameObject projectile = Instantiate(projectilePrefab, spawnPoint.position, Quaternion.identity);
        if (projectile.TryGetComponent(out Rigidbody rigi))
        {
            rigi.linearVelocity = initialVelocity;
            projectile.transform.forward = rigi.linearVelocity.normalized;
        }

        Destroy(projectile, 10f);
    }

    private void UpdateAngle(Vector3 initialVelocity)
    {
        Vector3[] points = new Vector3[trajectoryPoints];
        Vector3 currentPosition = spawnPoint.position;

        for (int i = 0; i < trajectoryPoints; i++)
        {
            float t = i * timeStep;
            Vector3 point = currentPosition + initialVelocity * t + 0.5f * Physics.gravity * t * t;
            points[i] = point;
        }

        lineRenderer.positionCount = trajectoryPoints;
        lineRenderer.SetPositions(points);
    }

    public static Vector3 GetInitialVelocity(Vector3 origin, Vector3 target, float time)
    {
        if (time <= 0f) return Vector3.zero;

        Vector3 distance = target - origin;
        Vector3 horizontal = new Vector3(distance.x, 0f, distance.z);
        float vy = (distance.y + 0.5f * Mathf.Abs(Physics.gravity.y) * time * time) / time;
        Vector3 velocity = horizontal / time;
        velocity.y = vy;

        return velocity;
    }
}
