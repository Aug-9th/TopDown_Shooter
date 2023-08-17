using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    //private bool isFacingRight = true;

    private Animator myAnim;
    private Rigidbody2D myBody;

    public Transform attackPoint;
    public LayerMask enemyLayers;

    private Vector2 moveVelocity;
    float xDir, yDir;

    public float attackRange;
    public int Dmg = 20;

    public float attackRate;
    float nextAttackTime = 0;
    

    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
    }

    
    void Update()
    {
        
        xDir = Input.GetAxisRaw("Horizontal");
        yDir = Input.GetAxisRaw("Vertical");
        //Flip();

        if(Time.time >= nextAttackTime)
        {
            if (Input.GetMouseButtonDown(0))
            {
                //Attack();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }

        Moving();
    }

    void Moving()
    {
        Vector2 moveInput = new Vector2(xDir, yDir);
        moveVelocity = moveInput.normalized * speed;
        myBody.MovePosition(myBody.position + moveVelocity * Time.fixedDeltaTime);
        if (myAnim)
        {
            myAnim.SetFloat("xAxis", xDir);
            myAnim.SetFloat("yAxis", yDir);
        }

    }

    /*void Flip()
    {

        if (isFacingRight && xDir < 0f || !isFacingRight && xDir > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }*/

    /*void Attack()
    {
        myAnim.SetTrigger("isAttack");

        Collider2D[] hitEnemys = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);


        foreach(Collider2D enemy in hitEnemys)
        {
            enemy.GetComponent<EnemyHealth>().TakeDmg(Dmg);
        }
        

    }*/

    void OnDrawGizmosSelected()
    {
        if(attackPoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
    void Dead()
    {
        
    }
}
