using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnWeapon : MonoBehaviour
{
    public GameObject[] weapons;

    public float x, y;
    void Start()
    {
        StartCoroutine(SpawnaWeapon());
    }

   IEnumerator SpawnaWeapon()
    {
        yield return new WaitForSeconds(10);
        Vector2 spawnPos = new Vector2(Random.Range(-18f, 12f), Random.Range(-5f, 12f));
        if (GameObject.FindGameObjectsWithTag("Weapon").Length < 4)
        Instantiate(weapons[Random.Range(0, weapons.Length)], spawnPos, Quaternion.identity);
        StartCoroutine(SpawnaWeapon());
    }
}
