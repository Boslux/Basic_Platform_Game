using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyController : MonoBehaviour
{
    Rigidbody2D rb;
    BoxCollider2D bc;

    public float speed = 1.5f;

    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
        bc=GetComponent<BoxCollider2D>();
    }

   
    void Update()
    {
        Walk();

    }

    private void OnTriggerExit2D(Collider2D cls)
    {

        //for turn
        transform.localScale = new Vector2(-(Mathf.Sign(rb.velocity.x)), transform.localScale.y);
    }
     public void EnemyDestroy()
    {
        Destroy(gameObject);
    }
    private void Walk()
    {
        //Right and left control
        if (IsFaceingRight() == true)
        {
            rb.velocity = new Vector2(speed, 0);
        }
        else
        {
            rb.velocity = new Vector2(-speed, 0);
        }
    }
    private bool IsFaceingRight()
    {
        return transform.localScale.x > Mathf.Epsilon;
    }
}
