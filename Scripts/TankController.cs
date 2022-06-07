using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{

    public enum tankStatus {fire, damage, movement, tankDefeated};
    public tankStatus currentStatus;

    [SerializeField]
    Transform tankObject;
    public Animator anim;

    float time1, time2;

    [Header("Movement")]
    public float moveSpeed;
    public Transform leftTarget, rightTarget;
    bool isRight;
    public GameObject mine;
    public Transform mineLocation;
    public float mineTime;
    float mineCounter;

    [Header("Fire")]
    [SerializeField]
    GameObject bullet;
    public Transform bulletLocation;
    public float bulletTime;
    float bulletTimeCounter;

    [Header("Damage")]
    public float damageTime;
    float damageCounter;

    [Header("Health")]
    public int health = 5;
    public GameObject explosionEffect;
    bool isDefeated;
    public float increaseBulletTime;
    public float increaseMineTime;

    public GameObject tankDestroyerObject;

    private void Start()
    {
        currentStatus = tankStatus.fire; // Ates etme ile basliyor.
    }

    private void Update()
    {
        switch (currentStatus)
        {
            case tankStatus.fire:
                bulletTimeCounter -= Time.deltaTime;

                if(bulletTimeCounter <= 0)
                {
                    bulletTimeCounter = bulletTime;
                    var newBullet = Instantiate(bullet, bulletLocation.position, bulletLocation.rotation); // Yeni bir degiskene atadik cunku mermi sola atiliyor ancak saga atilmiyor.
                    newBullet.transform.localScale = tankObject.localScale; // Tankimizin yonune esitledik, boylece mermiyi saga da sola da atabiliyoruz.
                }

                break;

            case tankStatus.damage:
                if(damageCounter > 0)
                {
                    damageCounter -= Time.deltaTime;
                    if(damageCounter <= 0)
                    {
                        currentStatus = tankStatus.movement;
                        mineCounter = 0;
                        
                        if (isDefeated)
                        {
                            tankObject.gameObject.SetActive(false);
                            Instantiate(explosionEffect, transform.position, transform.rotation);
                            currentStatus = tankStatus.tankDefeated;
                        }
                    }
                }
                break;

            case tankStatus.movement:
                if (isRight)
                {
                    tankObject.position += new Vector3(moveSpeed * Time.deltaTime, 0f, 0f);

                    if(tankObject.position.x > rightTarget.position.x)
                    {
                        tankObject.localScale = Vector3.one;
                        isRight = false;
                        StopMovement();
                    }
                }
                else
                {
                    tankObject.position -= new Vector3(moveSpeed * Time.deltaTime, 0f, 0f);

                    if(tankObject.position.x < leftTarget.position.x)
                    {
                        tankObject.localScale = new Vector3(-1, 1, 1);
                        isRight = true;
                        StopMovement();
                    }
                }

                mineCounter -= Time.deltaTime;

                if(mineCounter <= 0)
                { 
                    mineCounter = mineTime;
                    Instantiate(mine, mineLocation.position, mineLocation.rotation);
                }

                break;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Damage();
        }

    }

    public void Damage()
    {
        currentStatus = tankStatus.damage;
        damageCounter = damageTime;
        anim.SetTrigger("Fire");

        MineController[] mines = FindObjectsOfType<MineController>();

        if(mines.Length > 0)
        {
            foreach (MineController foundedMine in mines)
            {
                foundedMine.Explosion();
            }
        }

        health--;

        if(health <= 0)
        {
            isDefeated = true;
        }
        else
        {
            bulletTime /= increaseBulletTime;
            mineTime /= increaseMineTime;
        }


    }

    void StopMovement()
    {
        tankDestroyerObject.SetActive(true);
        currentStatus = tankStatus.fire;
        bulletTimeCounter = bulletTime;
        anim.SetTrigger("stopMoving");
    }

}
