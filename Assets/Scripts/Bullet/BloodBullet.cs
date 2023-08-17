using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodBullet : MonoBehaviour
{

    void Start()
    {
        Destroy(gameObject, 1);
    }
    
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Enemy")
        {
            
            col.gameObject.GetComponent<EnemyHealth>().curHealth -= 30;

        }

        
    }
}
