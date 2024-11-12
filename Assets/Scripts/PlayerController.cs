using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float jumpForce = 500;
    [SerializeField]
    float WalljumpForce = 20;

    bool mayJump = true;

        bool hasdash = false;

bool maydash = false;

    [SerializeField]
    Transform grounchecker;
    [SerializeField]
    Transform leftwallchecker;
    [SerializeField]
    Transform rightwallchecker;
    [SerializeField]
    LayerMask groundlayer;
    [SerializeField]
    LayerMask Wallclimblayer;
    [SerializeField]
    float movespeed = 5;
    [SerializeField]
    float dashforce=50;

    void Update()
    {
        float xMove = Input.GetAxisRaw("Horizontal");

        //transform.Translate(Vector2.right * xMove * Time.deltaTime);

        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = new(
        xMove * movespeed,
        rb.velocity.y
        );







        if (Input.GetAxisRaw("Jump") > 0 && mayJump == true)
        {
            Rigidbody2D rbb = GetComponent<Rigidbody2D>();
            rbb.AddForce(Vector2.up * jumpForce);
            mayJump = false;
            if(CanWallClimbRight() && IsGrounded()!=true)
            {
            rbb.AddForce(Vector2.left * WalljumpForce);
            }
            if(CanWallClimbLeft() && IsGrounded()!=true)
            {
            rbb.AddForce(Vector2.right * WalljumpForce);
            }
        }
        if (IsGrounded() || IsGroundedWallClimb() || CanWallClimbLeft() || CanWallClimbRight())
        {
            mayJump=true;
            maydash=true;
            if ( CanWallClimbLeft() || CanWallClimbRight())
            {
            rb.gravityScale=13;
            }
            else
            {
            rb.gravityScale=11;
            }
        }

        if (Input.GetKeyDown(KeyCode.K) ==true && hasdash == true && maydash == true)
        {
            Rigidbody2D rbb = GetComponent<Rigidbody2D>();
            rbb.AddForce(Vector2.left * dashforce);
            maydash = false;
        }
        if (Input.GetKeyDown(KeyCode.P) && hasdash == true && maydash == true)
        {
            Rigidbody2D rbb = GetComponent<Rigidbody2D>();
            rbb.AddForce(Vector2.right * dashforce);
            maydash = false;
        }
        if (rb.velocity.x > 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        if (rb.velocity.x < 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
    }
    private bool IsGrounded() => Physics2D.OverlapCircle(grounchecker.position, .2f, groundlayer);
    private bool IsGroundedWallClimb() => Physics2D.OverlapCircle(grounchecker.position, .2f, Wallclimblayer);

    private bool CanWallClimbLeft() => Physics2D.OverlapCircle(leftwallchecker.position, .2f, Wallclimblayer);

    private bool CanWallClimbRight() => Physics2D.OverlapCircle(rightwallchecker.position, .2f, Wallclimblayer);

    private void OnTriggerEnter2D(Collider2D Other)
    {
        if (Other.tag == "DashUnlock")
        {
        hasdash=true;
        }
        if (Other.tag == "WinTriangle")
        {
        SceneManager.LoadScene("Winscreen");
        }
    }
}

