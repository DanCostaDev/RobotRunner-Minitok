using UnityEngine;

public class Jump : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private float jumpAmount = 20f;
    [SerializeField] private float gravityScale = 10f;
    [SerializeField] private float maxDuration = 0.3f;
    [SerializeField] private Animator animator;

    [SerializeField] private CapsuleCollider walkCollider;
    [SerializeField] private CapsuleCollider jumpCollider;

    private GroundCheck check;
    private float jumpTime;
    private bool jumping;

    private void FixedUpdate() => rb.AddForce(Physics.gravity * (gravityScale - 1) * rb.mass);
        
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        check = GetComponent<GroundCheck>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        animator.SetBool("IsGrounded", check.isGrounded);
        if(!check.isGrounded )
        {
            jumpCollider.enabled = true;
            walkCollider.enabled = false;
        }
        else
        {
            jumpCollider.enabled = false;
            walkCollider.enabled = true;
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) && check.isGrounded)
        {
            jumping = true;
            jumpTime = 0f;
        }

        if (jumping)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpAmount);
            jumpTime += Time.deltaTime;
        }

        if (Input.GetKeyUp(KeyCode.Mouse0) || jumpTime > maxDuration) jumping = false;
    }
}
