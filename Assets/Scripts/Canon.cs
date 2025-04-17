using UnityEngine;

public class Canon : MonoBehaviour
{
    [SerializeField] private Rigidbody projectile;

    [SerializeField] private Transform pivot;
    [SerializeField] private Transform target;
    [SerializeField] private Transform departCanon;

    [SerializeField] private float timeToTarget;

    private void Update()
    {
        pivot.forward = Vector3.Lerp(pivot.forward, GetInitialVelocity(departCanon.position, target.position, timeToTarget).normalized, 0.1f);
    }

    public void Shoot()
    {
        Rigidbody proj = Instantiate(projectile);
        proj.transform.position = departCanon.position;
        proj.linearVelocity = GetInitialVelocity(departCanon.position, target.position, timeToTarget);
        proj.transform.forward = proj.linearVelocity.normalized;
        Destroy(proj, 10f);
    }

    public static Vector3 GetInitialVelocity(Vector3 origin, Vector3 target, float time)
    {
        if (time <= 0) return Vector3.zero;
        float vy = 0.5f * -Physics.gravity.y * time + (target.y - origin.y) / time;

        var flatOrigin = origin; flatOrigin.y = 0;
        var flatTarget = target; flatTarget.y = 0;
        Vector3 dir = flatTarget - flatOrigin;
        var vxz = dir / time;

        float vx = Vector3.Project(vxz, new Vector3(1, 0, 0)).x;
        float vz = Vector3.Project(vxz, new Vector3(0, 0, 1)).z;

        return new Vector3(vx, vy, vz);
    }
}
