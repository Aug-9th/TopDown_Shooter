using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningEf : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Enemy")
        {
            col.gameObject.GetComponent<EnemyHealth>().curHealth -= GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerShooter>().currentWeapon.damage;

        }

       
    }
}