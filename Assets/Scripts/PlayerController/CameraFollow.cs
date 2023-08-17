using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform playpos;
    void Awake()
    {
        playpos = GameObject.FindGameObjectWithTag("Player").transform;
    }


    void Update()
    {
        transform.position = new Vector3(playpos.position.x, playpos.position.y, transform.position.z);
    }
}
