using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemys : MonoBehaviour
{
    public float time = 1.5f;
    public GameObject enemies;
    public float Waittime = 0;


    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }
    void Update()
    {
       if (GameObject.Find("Player").GetComponent<PlayerShooter>().isDead == true)
        {
            gameObject.SetActive(false);
        }
    }
    IEnumerator SpawnEnemy()
    {
        yield return new WaitForSeconds(Waittime);
        Waittime= 0;
        Vector2 spawnPos = GameObject.FindGameObjectWithTag("Player").transform.position;
        spawnPos += Random.insideUnitCircle.normalized * 9f;
        if(spawnPos.x < -16f || spawnPos.x > 11f || spawnPos.y < -4f || spawnPos.y > 10f)
        {
            StartCoroutine(SpawnEnemy());
        }
        else
        {
            Instantiate(enemies, spawnPos, Quaternion.identity);

            yield return new WaitForSeconds(time);
            StartCoroutine(SpawnEnemy());
        }
            
    }
   


}
