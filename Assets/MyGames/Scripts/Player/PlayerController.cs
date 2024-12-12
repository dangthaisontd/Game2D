using UnityEngine;
[AddComponentMenu("DangSon/PlayerController")]
public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    private Rigidbody2D rb;
    public float jumFore=5.0f;
    [SerializeField] private Transform groundCheck;
    public LayerMask groundLayer;
    public float radius = 0.5f;
    bool facingRight = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        //
        if(IsGround()&&Input.GetKeyDown(KeyCode.Space))
        {
            Jum();
        }
    }
    private void Move()
    {
        float horizontal = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(horizontal * moveSpeed, rb.linearVelocity.y);
        if((horizontal>0&&!facingRight)||(horizontal<0&&facingRight))
        {
            Flip();
        }
    }
    bool IsGround()
    {
        bool isLocalGround = Physics2D.OverlapCircle(groundCheck.position, radius, groundLayer);
        return isLocalGround;
    }
    void Jum()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumFore);
    }
    void Flip()
    {
        facingRight = !facingRight;
        Vector2 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(groundCheck.position, radius);
    }
    
}
