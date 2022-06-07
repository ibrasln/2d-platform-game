using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogController : MonoBehaviour
{
    public float moveSpeed;

    [SerializeField]
    Transform leftTarget, rightTarget;

    bool isRight;

    Rigidbody2D rb;
    public SpriteRenderer spriteRenderer;

    public float movementTime, cooldown;
    float movementCounter, cooldownCounter;

    Animator anim;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Start()
    {
        leftTarget.parent = null; // Bu degiskenlere null degeri vermemizin sebebi kurbaganin altinda olmalaridir. Kurbaga hareket ettikce onlar da hareket edecektir. Bunu onlemek icin baslarken parent'larini null yaptik.
        rightTarget.parent = null;
        isRight = true; // Ilk sag tarafa gitmesini istiyoruz.
        movementCounter = movementTime; 
    }

    private void Update()
    {
        // Eger hareket sayaci 0'dan buyukse
        if(movementCounter > 0) 
        {
            movementCounter -= Time.deltaTime; // Hareket sayacini zamanla azalt.
            
            if (isRight)
            {
                rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
                spriteRenderer.flipX = true;

                if(transform.position.x > rightTarget.position.x)
                {
                    isRight = false;
                }
            }
            else
            {
                rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
                spriteRenderer.flipX = false;

                if(transform.position.x < leftTarget.position.x)
                {
                    isRight = true;
                }
            }

            if(movementCounter < 0) // Eger hareket sayaci 0'dan kucukse
            {
                cooldownCounter = Random.Range(cooldown * 0.7f, cooldown * 1.2f); // Bekleme sayacini rastgele bir degere esitle.
            }
            anim.SetBool("isMove", true);
        }   

        else if(cooldownCounter > 0) // Eger bekleme sayaci 0'dan buyukse
        {
            cooldownCounter -= Time.deltaTime; // Bekleme sayacini zamanla azalt.
            rb.velocity = new Vector2(0f, rb.velocity.y); // Hizini 0'a esitle.

            if(cooldownCounter < 0) // Eger bekleme sayaci 0'dan kucukse
            {
                movementCounter = Random.Range(movementTime * 0.5f, movementTime * 1.3f); // Hareket sayacini rastgele bir degere esitle. Boylece tekrar basa don.
            }

            anim.SetBool("isMove", false);
        }
    }


}
