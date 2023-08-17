using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    private Vector2 dir;
    void Awake()
    {
        transform.eulerAngles = new Vector3(0, 0, GameObject.Find("Weapons").transform.eulerAngles.z);
    }
    void Start()
    {
        dir = GameObject.Find("Dir").transform.position;

        Destroy(gameObject, 2);
        transform.position = GameObject.Find("ShootingPoint").transform.position;


    }

    // Update is called once per frame
    void Update()
    {

        transform.position = Vector2.MoveTowards(transform.position, dir, speed * Time.deltaTime);
    }
    
}
