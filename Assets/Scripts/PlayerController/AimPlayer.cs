using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimPlayer : MonoBehaviour
{
    public float speed;
    //private bool isFacingRight = true;

    private Animator myAnim;
    private Rigidbody2D myBody;

    public Transform attackPoint;
    public LayerMask enemyLayers;
    public GameObject Bullet;

    private Vector2 moveVelocity;
    private float xDir, yDir;

    public int Dmg = 20;
    public float attackRate;
    float nextAttackTime = 0;

    private bool Hit = true;
    public int health = 8;


    public bool isDead = false;
    public bool Right = true;
    public bool AutoFire = false;

    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
    }


    void Update()
    {
        if (Input.GetButton("AutoFire")) {
            AutoFire = !AutoFire;
        }

        Shoot();
        Dead();

    }
    void FixedUpdate()
    {
        xDir = Input.GetAxisRaw("Horizontal");
        yDir = Input.GetAxisRaw("Vertical");
        // Flip();
        if ((transform.position.x < -19f && xDir < 0) || (transform.position.x > 12.4f && xDir > 0) || (transform.position.y < -5.4f && yDir < 0) || (transform.position.y > 12.5f && yDir > 0))
            return;
        Moving();
    }
    void Moving()
    {
        Vector2 moveInput = new Vector2(xDir, yDir);
        moveVelocity = moveInput.normalized * speed;
        myBody.MovePosition(myBody.position + moveVelocity * 0.02f);
        if (myAnim)
        {
            Flip();
 
        }

      
    }
    
    void Flip()
    {
        Vector2 Dir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        if (Dir.x > 0)
        {
            if (xDir > 0)
            {
                myAnim.SetFloat("xAxis", xDir);
            } else
            {
                myAnim.SetFloat("xAxis", -xDir);
            }
        } else
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
    }
    void Shoot()
    {

        if (AutoFire == false)
        {
            if (Input.GetMouseButton(0))
            {
                if (Time.time >= nextAttackTime)
                {
                    // GameObject.Find("Weapons").GetComponent<Animator>().SetTrigger("isShoot");
                    Instantiate(Bullet, attackPoint.transform.position, Quaternion.identity);
                    nextAttackTime = Time.time + 1 / attackRate;
                }

            }

        }
        else
        {
            if (Time.time >= nextAttackTime)
            {
                // GameObject.Find("Weapons").GetComponent<Animator>().SetTrigger("isShoot");
                Instantiate(Bullet, attackPoint.transform.position, Quaternion.identity);
                nextAttackTime = Time.time + 1 / attackRate;
            }

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
            GameObject.Find("Weapons").GetComponent<Aim>().enabled = false;
            this.enabled = false;
            GameObject[] A = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject enemy in A)
            {
                enemy.GetComponent<EnemyHealth>().Die();
            }
        }
    }

}
