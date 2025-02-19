using UnityEngine;

public class Controller : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;

    public float checkRadius;
    public LayerMask platform;
    public GameObject Groundcheck;
    public bool isOnGround;
    bool isDead;
    public GameObject Spawner;

    public float speed;
    float xVelocity;
    void Start()
    {   
        isDead = false;
        rb=GetComponent<Rigidbody2D>();
        anim=GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {

        Edge1();
        isOnGround = Physics2D.OverlapCircle(Groundcheck.transform.position,checkRadius,platform);
        anim.SetBool("isOnGround", isOnGround);
        Movement();

    }

    void Movement()
    {
        xVelocity = Input.GetAxisRaw("Horizontal");

        rb.linearVelocity = new Vector2(xVelocity * speed, rb.linearVelocity.y);

        anim.SetFloat("speed", Mathf.Abs(rb.linearVelocity.x));
        if (xVelocity != 0)
            transform.localScale = new Vector3(xVelocity, 1, 1);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Fan"))
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x,10f);
        }
           
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("spike"))
        {
            anim.SetTrigger("dead");
            Invoke("PlayerDead", 0.7f);
        }
    }



    private void Edge1()
    {
        if(this.transform.position.y < -5f)
            PlayerDead();
    }

    public void PlayerDead()
    {
        
        isDead = true;
        GameManager.GameOver(isDead);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;

        Gizmos.DrawWireSphere(Groundcheck.transform.position, checkRadius);
    }
}
