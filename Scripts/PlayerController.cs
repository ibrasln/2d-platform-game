using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField]
    float moveSpeed, jumpPower;

    bool isGround, canDoubleJump;
    public Transform groundControl;
    public LayerMask groundLayer;

    Rigidbody2D rb;

    Animator anim;

    public float recoilTime, recoilPower;
    float recoilCounter;
    bool isRight;

    public float bouncePower; // Kurbagayi oldurdugumuzdeki ziplama gucu

    public bool isMove = true;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        anim.SetFloat("movementSpeed", Mathf.Abs(rb.velocity.x)); // Mathf.Abs() kullanma sebebimiz objenin - yonde giderken animasyonunun calismamasi. Mutlak degerini alarak pozitif gosterdik.
        anim.SetBool("isGround", isGround);

        if (isMove)
        {
            if (recoilCounter <= 0)
            {
                Movement();
                Jump();
                changeRotation();
            }
            else
            {
                recoilCounter -= Time.deltaTime;

                if (isGround)
                {
                    if (isRight)
                    {
                        rb.velocity = new Vector2(-recoilPower, rb.velocity.y);
                    }
                    else
                    {
                        rb.velocity = new Vector2(recoilPower, rb.velocity.y);
                    }
                }
                else
                {
                    if (isRight)
                    {
                        rb.velocity = new Vector2(rb.velocity.x, recoilPower);
                    }
                    else
                    {
                        rb.velocity = new Vector2(rb.velocity.x, recoilPower);
                    }

                }
            }
        }
        else
        {
            rb.velocity = Vector2.zero;
            anim.SetFloat("movementSpeed", Mathf.Abs(rb.velocity.x));
            anim.SetBool("isGround", true);
        }
    }

    void Movement()
    {
        float h = Input.GetAxis("Horizontal");
        float speed = h * moveSpeed;
        rb.velocity = new Vector2(speed, rb.velocity.y);
    }

    void Jump()
    {

        isGround = Physics2D.OverlapCircle(groundControl.position, .2f, groundLayer); // (Nokta, aci, layer)

        if (isGround)
        {
            canDoubleJump = true;
        }

        if (Input.GetButtonDown("Jump"))
        {
            if (isGround)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpPower);
                SoundController.instance.SoundEffect(3);
            }
            else
            {
                if (canDoubleJump)
                {
                    rb.velocity = new Vector2(rb.velocity.x, jumpPower);
                    canDoubleJump = false;
                    SoundController.instance.SoundEffect(3);
                }
            }
        }
    }

    void changeRotation()
    {
        Vector2 tempScale = transform.localScale;

        if(rb.velocity.x > 0)
        {
            tempScale.x = 1f;
            isRight = true;
        }
        else if(rb.velocity.x < 0)
        {
            tempScale.x = -1f;
            isRight = false;
        }
        transform.localScale = tempScale;
    }

    public void Recoil()
    {
        recoilCounter = recoilTime;
        rb.velocity = new Vector2(0, rb.velocity.y);

        anim.SetTrigger("damage");
    }

    public void JumpJump()
    {
        rb.velocity = new Vector2(rb.velocity.x, bouncePower);
        SoundController.instance.SoundEffect(3);
    }

}
