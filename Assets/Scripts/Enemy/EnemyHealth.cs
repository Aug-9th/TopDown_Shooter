using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float maxHealth = 70;
    public float curHealth;
    public float knockBackForce = 5f;
    public float knockBackForce2 = 5f;

    private Animator EmAnim;
    private Rigidbody2D EmBody;
    
    public int ScoreGive = 1;

    void Start()
    {
        curHealth = maxHealth * (GamePlayManager.instance.levelNumber + 0.75f);
        EmAnim = GetComponent<Animator>();
        EmBody = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (curHealth <= 0)
        {
            Die();
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Bullet")
        {
            curHealth -= GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerShooter>().currentWeapon.damage;
            Destroy(col.gameObject);

            Vector3 Shot = GameObject.FindGameObjectWithTag("Player").transform.position;
            Vector2 direction = (transform.position - Shot).normalized;
            EmBody.AddForce(direction * knockBackForce);

            if (EmAnim)
            {
                EmAnim.SetTrigger("Hurt");
            }


        }
        if(col.tag == "Thought")
        {
            curHealth -= GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerShooter>().currentWeapon.damage;

            Vector3 Shot = GameObject.FindGameObjectWithTag("Player").transform.position;
            Vector2 direction = (transform.position - Shot).normalized;
            EmBody.AddForce(direction * knockBackForce * 0.05f);

            if (EmAnim)
            {
                EmAnim.SetTrigger("Hurt");
            }
        }
    }
    public void Die()
    {
        GamePlayManager.instance.Addscore(ScoreGive);
        EmAnim.SetTrigger("Hurt");
        EmAnim.SetBool("Death", true);
        GetComponent<Collider2D>().enabled = false;
        GetComponent<EnemyFollow>().enabled = false;
        this.enabled = false;
        Destroy(gameObject, 2);
    }
    void Attack()
    {
        EmAnim.SetTrigger("isAttack");
        Vector3 Shot = GameObject.FindGameObjectWithTag("Player").transform.position;
        Vector2 direction = (transform.position - Shot).normalized;
        EmBody.AddForce(direction * knockBackForce2);

    }


    public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Attack();
            
        }
    }

    
}
