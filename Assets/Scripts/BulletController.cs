using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    float  bulletSpeed=10;
    void Start()
    {
        
    }

    
    void Update()
    {
        transform.Translate(bulletSpeed * Time.deltaTime, 0, 0);
    }
}
