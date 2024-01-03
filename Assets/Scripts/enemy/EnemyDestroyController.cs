using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestroyController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D cls)
    {
        if (cls.gameObject.CompareTag("Enemy"))
        {
            gameObject.GetComponent<enemyController>().EnemyDestroy();
        }
    }

}
