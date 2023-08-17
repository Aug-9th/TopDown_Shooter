using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    private Transform target;

    public float within_range;
    public float speed;
    private bool isFacingRight = true;

    private Animator EmAnim;
    private Rigidbody2D rb;

    void Awake()
    {
        speed = speed + GamePlayManager.instance.levelNumber * 0.3f ;
        EmAnim = GetComponent<Animator>();
    }

    public void Update()
    {
        
        target = GameObject.Find("Player").transform;
        if (Vector2.Distance(transform.position, target.position) < 0.2f)
            return;
        float dist = Vector3.Distance(target.position, transform.position);

        if (dist <= within_range)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            Flip();
            if (EmAnim)
            {
                EmAnim.SetBool("Run", true);
            }
        }
        else
        {
            if (EmAnim)
            {
                EmAnim.SetBool("Run", false);
            }
        }

    }

    void Flip()
    {

        if (isFacingRight && (target.localPosition.x - transform.localPosition.x) < 0f || !isFacingRight && (target.localPosition.x - transform.localPosition.x) > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }


}
