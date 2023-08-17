using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter: MonoBehaviour
{
    public float speed;

    private Animator myAnim;
    private Rigidbody2D myBody;

    public Transform attackPoint;
    public Transform Item;
    public AudioClip shootClipHurt, shootClipDead;

    private Vector2 moveVelocity;
    private float xDir, yDir;

    public int health = 8;
    float nextAttackTime = 0;

    private bool Hit = true;
    public bool isDead = false;
    public bool AutoFire = false;

    public Weapon currentWeapon;

    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();

        transform.GetChild(1).GetComponent<SpriteRenderer>().sprite = currentWeapon.currentWeaponSpr;
    }


    void Update()
    {
        
        xDir = Input.GetAxisRaw("Horizontal");
        yDir = Input.GetAxisRaw("Vertical");
        
        if(Input.GetButton("AutoFire"))
        {
            AutoFire = !AutoFire;
        }

        if (AutoFire == false)
        {
            if (Input.GetMouseButton(0))
            {
                Vector2 Dir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
                if (Dir.x > 0)
                {
                    if (xDir > 0)
                    {
                        myAnim.SetFloat("xAxis", xDir);


                    }
                    else
                    {
                        myAnim.SetFloat("xAxis", -xDir);

                    }
                }
                else
                {
                    if (xDir > 0)
                    {
                        myAnim.SetFloat("xAxis", -xDir);

                    }
                    else
                    {
                        myAnim.SetFloat("xAxis", xDir);

                    }
                }

                if (Dir.y > 0)
                {
                    if (yDir > 0)
                    {
                        myAnim.SetFloat("yAxis", yDir);


                    }
                    else
                    {
                        myAnim.SetFloat("yAxis", -yDir);

                    }
                }
                else
                {
                    if (yDir > 0)
                    {
                        myAnim.SetFloat("yAxis", -yDir);

                    }
                    else
                    {
                        myAnim.SetFloat("yAxis", yDir);

                    }
                }

                if (Time.time >= nextAttackTime)
                {
                    currentWeapon.Shoot();
                    nextAttackTime = Time.time + 1 / currentWeapon.fireRate;

                }

            }

        }
        else
        {
            {
                Vector2 Dir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
                if (Dir.x > 0)
                {
                    if (xDir > 0)
                    {
                        myAnim.SetFloat("xAxis", xDir);


                    }
                    else
                    {
                        myAnim.SetFloat("xAxis", -xDir);

                    }
                }
                else
                {
                    if (xDir > 0)
                    {
                        myAnim.SetFloat("xAxis", -xDir);

                    }
                    else
                    {
                        myAnim.SetFloat("xAxis", xDir);

                    }
                }

                if (Dir.y > 0)
                {
                    if (yDir > 0)
                    {
                        myAnim.SetFloat("yAxis", yDir);


                    }
                    else
                    {
                        myAnim.SetFloat("yAxis", -yDir);

                    }
                }
                else
                {
                    if (yDir > 0)
                    {
                        myAnim.SetFloat("yAxis", -yDir);

                    }
                    else
                    {
                        myAnim.SetFloat("yAxis", yDir);

                    }
                }

                if (Time.time >= nextAttackTime)
                {
                    currentWeapon.Shoot();
                    nextAttackTime = Time.time + 1 / currentWeapon.fireRate;

                }

            }

        }

        Moving();
        Dead();
    }
    
    void Moving()
    {
        Vector2 moveInput = new Vector2(xDir, yDir);
        moveVelocity = moveInput.normalized * speed;
        myBody.MovePosition(myBody.position + moveVelocity * 0.02f);
      
        if (Input.GetMouseButton(0))
            return;

        if (myAnim)
        {
            myAnim.SetFloat("xAxis", xDir);
            myAnim.SetFloat("yAxis", yDir);
            
        }
    }


    IEnumerator HitBoxOff()
    {
        Hit = false;
        myAnim.SetTrigger("Hit");
        yield return new WaitForSeconds(1.5f);
        Hit = true;
    }
    public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {

            if (Hit)
            {
                SoundManager.instance.Voices(shootClipHurt);
                StartCoroutine(HitBoxOff());
                health--;
                Destroy(GameObject.Find("HealthBar").transform.GetChild(0).gameObject);
                Debug.Log("HP is " + health);
            }
        }
    }
    void Dead()
    {
        if (health <= 0)
        {
            myAnim.SetTrigger("isDead");
            isDead = true;
            GameObject.Find("GamePlayManager").GetComponent<OverGame>().GameOver(isDead);
            GameObject.Find("Weapons").GetComponent<Aim>().enabled = false;
            this.enabled = false;
            GameObject[] A = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject enemy in A)
            {
                Destroy(enemy);
            }
        }
    }

  

}
