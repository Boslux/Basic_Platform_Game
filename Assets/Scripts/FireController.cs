using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireController : MonoBehaviour
{
    public bool fireOn=false;
    
    public void Update()
    {
        
        if (fireOn==true)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D cls)
    {
        if (cls.gameObject.CompareTag("Player"))
        {
            Destroy(cls.gameObject);
        }
        
    }
}
