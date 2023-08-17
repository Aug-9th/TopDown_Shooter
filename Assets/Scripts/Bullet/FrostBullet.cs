using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrostBullet : MonoBehaviour
{
    public float speed;
    private Vector2 dir;
    public GameObject Frost;
    // public AudioClip shootClip;
    public bool Main = true, right = true,ADM = false;
    void Awake()      
    {
        transform.eulerAngles = new Vector3(0, 0, GameObject.Find("Weapons").transform.eulerAngles.z);
    }
    void Start()
    {
        if (ADM == true)
        {
            Destroy(gameObject, 1);
        }
        if (Main == true)
        {
            dir = GameObject.Find("Dir").transform.position;
            Destroy(gameObject, 1);
            transform.position = GameObject.Find("ShootingPoint").transform.position;
        }
        else
        {
            if (right == true)
            {
                dir = GameObject.Find("Dir").transform.GetChild(1).position;
                Destroy(gameObject, 1);
                transform.position = GameObject.Find("ShootingPoint").transform.position;
            }
            else
            {
                dir = GameObject.Find("Dir").transform.GetChild(0).position;
                Destroy(gameObject, 1);
                transform.position = GameObject.Find("ShootingPoint").transform.position;
            }
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        
        GameObject[] A = GameObject.FindGameObjectsWithTag("Effect");
        foreach (GameObject enemy in A)
        {
            Destroy(enemy, 0.75f);
        }
        transform.position = Vector2.MoveTowards(transform.position, dir, speed * Time.deltaTime);
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Enemy")
        {
         
            Instantiate(Frost, col.transform.position, Quaternion.identity);

            col.gameObject.GetComponent<EnemyFollow>().speed = speed * .05f;
        }
    }
    
}
