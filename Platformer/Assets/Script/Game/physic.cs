using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class physic : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private SpriteRenderer sprend2d;
    public bool IsGrounded = true;
    public float Speed = 5f;
    public float JumpSpeed = 25f;
    public static bool canShoot = true;
    private Animator Anim;
    private bool isMoving = false;
    private bool isDeath = false;


    public static int hearth = 5;
    public float fireCoolDown = 0.5f;

    [SerializeField]
    Transform GroundCheck;  
    [SerializeField]
    Transform GroundCheck_L;
    [SerializeField]
    Transform GroundCheck_R;
    [SerializeField]
    Transform GroundCheck_LL;
    [SerializeField]
    Transform GroundCheck_RR;
    [SerializeField]
    Transform GroundCheck_UP;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        sprend2d = GetComponent<SpriteRenderer>();
        Anim = GetComponent<Animator>(); 
    }

    // Update is called once per frame
    void Update()
    {
        Anim.SetBool("isMoving", isMoving);
        if(Physics2D.Linecast(transform.position, GroundCheck.position, 1 <<LayerMask.NameToLayer("Ground")) ||
            Physics2D.Linecast(transform.position, GroundCheck_L.position, 1 << LayerMask.NameToLayer("Ground")) ||
            Physics2D.Linecast(transform.position, GroundCheck_R.position, 1 << LayerMask.NameToLayer("Ground")) ||
            Physics2D.Linecast(transform.position, GroundCheck_LL.position, 1 << LayerMask.NameToLayer("Ground")) ||
            Physics2D.Linecast(transform.position, GroundCheck_RR.position, 1 << LayerMask.NameToLayer("Ground")) ||
            Physics2D.Linecast(transform.position, GroundCheck_UP.position, 1 << LayerMask.NameToLayer("Ground")))
        {
            IsGrounded = true;
        }
        else
        {
            IsGrounded = false;
        }
        if (Input.GetKey(KeyCode.D) || (Input.GetKeyDown("right")))
        {
            rb2d.velocity = new Vector2(Speed, rb2d.velocity.y);
            isMoving = true;
        }
        if (Input.GetKey(KeyCode.A) || (Input.GetKeyDown("left")))
        {
            rb2d.velocity = new Vector2(-Speed, rb2d.velocity.y);
            isMoving = true;
        }
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded == true || (Input.GetKey("up")) && IsGrounded == true)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, JumpSpeed);
        }
        if (Input.GetKeyUp(KeyCode.D));
        {
            isMoving = false;
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            isMoving = false;
        }
    }

    IEnumerator FireCoolDown()
    {
        yield return new WaitForSeconds(fireCoolDown);
    }

    private IEnumerator Death1()
    {
        print("2");
        Anim.SetBool("Death", isDeath);
        yield return new WaitForSeconds(2f);
        hearth = 5;
        SceneManager.LoadScene(1);
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            hearth--;
            print("1");
            if (hearth <= 0)
            {
                isDeath = true;
                StartCoroutine("Death1");
            }
        }
    }
}
