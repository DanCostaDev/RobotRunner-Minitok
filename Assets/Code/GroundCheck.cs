using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public bool isGrounded;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float radius;
    [SerializeField] private float offset;

    void FixedUpdate()
    {
        isGrounded = Physics.CheckSphere(transform.position, radius, groundLayer);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(transform.position + (offset * Vector3.up), radius);
    }
}
