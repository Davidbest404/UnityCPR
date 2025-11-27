using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] Transform firePoint;
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] int planeDistance;
    [SerializeField] float projectileSpeed = 30f;
    [SerializeField] float gizmoLength = 100f;
    [SerializeField] Color gizmoColor = Color.red;
    [SerializeField] Color highlightColor = Color.yellow;
    private Renderer lastHighlightedRenderer;
    private Color originalColor;

    void Update()
    {
        AimTurret();
        HighlightTarget();
        if (Input.GetMouseButtonDown(0)) Shoot();
        if (firePoint != null)
        {
            Debug.DrawRay(firePoint.position, firePoint.forward * gizmoLength, gizmoColor);
        }
    }

    void AimTurret()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Plane wallPlane = new Plane(Vector3.back, planeDistance);
        if (wallPlane.Raycast(ray, out float distance))
        {
            Vector3 targetPoint = ray.GetPoint(distance);
            Vector3 direction = targetPoint - transform.position;
            if (direction != Vector3.zero) transform.rotation = Quaternion.LookRotation(direction);
        }
    }
    void HighlightTarget()
    {
        if (firePoint == null) return;

        Ray ray = new Ray(firePoint.position, firePoint.forward);

        if (Physics.Raycast(ray, out RaycastHit hit, gizmoLength))
        {
            Renderer hitRenderer = hit.collider.GetComponent<Renderer>();
            if (hitRenderer != null)
            {
                if (lastHighlightedRenderer != hitRenderer)
                {
                    RestoreLastColor();

                    originalColor = hitRenderer.material.color;
                    hitRenderer.material.color = highlightColor;
                    lastHighlightedRenderer = hitRenderer;
                }
            }
        }
        else
        {
            RestoreLastColor();
        }
    }

    void RestoreLastColor()
    {
        if (lastHighlightedRenderer != null)
        {
            lastHighlightedRenderer.material.color = originalColor;
            lastHighlightedRenderer = null;
        }
    }
    void Shoot()
    {
        GameObject proj = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        Rigidbody rb = proj.GetComponent<Rigidbody>();
        rb.linearVelocity = firePoint.forward * projectileSpeed;
    }
    void OnDrawGizmosSelected()
    {
        Debug.DrawRay(firePoint.position, firePoint.forward * gizmoLength, gizmoColor);
    }
}
