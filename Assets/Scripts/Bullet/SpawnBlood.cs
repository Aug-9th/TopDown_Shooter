using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBlood : MonoBehaviour
{
    public float speed;
    private Vector2 dir;
    public GameObject Blood, BloodEf;
    void Awake()
    {
        transform.eulerAngles = new Vector3(0, 0, GameObject.Find("Weapons").transform.eulerAngles.z);
    }
    void Start()
    {
        dir = GameObject.Find("Dir").transform.position;

        Destroy(gameObject, 1);
        transform.position = GameObject.Find("ShootingPoint").transform.position;

        
    }

    // Update is called once per frame
    void Update()
    {

        transform.position = Vector2.MoveTowards(transform.position, dir, speed * Time.deltaTime);
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Enemy")
        {
            Instantiate(BloodEf, col.transform.position, Quaternion.identity);
            for (int i = 0; i < 5; i++)
            {
                Vector2 spawnPos = col.transform.position;
                spawnPos += Random.insideUnitCircle * 1.6f;

                Instantiate(Blood, spawnPos, Quaternion.identity);

                GameObject[] A = GameObject.FindGameObjectsWithTag("Effect");
                foreach (GameObject enemy in A)
                {
                    Destroy(enemy, 0.75f);
                }
            }


        }
    }

}
