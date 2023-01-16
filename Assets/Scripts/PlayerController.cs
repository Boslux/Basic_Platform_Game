using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    Animator animator;
  //public GameObject bullet;
    public Text gold;

    public bool isGround;
    private int score;
    public float speed;
    public float jumpPower;
    public bool faceRight;
    public int level;
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        
    }


    void Update()
    {
        playHorizontal();
        if (Input.GetButtonDown("Jump"))
        {
            PlayerJump();
        }
        gold.text = "" + score;
        


    }
    void LevelUp()
    {
        if (score==1)
        {
            level++;
            animator.SetTrigger("LevelUp");
            
        }
    }
    void playHorizontal()
    {
        float hmove = Input.GetAxis("Horizontal") * speed*Time.deltaTime*100;
        Vector2 move = new Vector2(hmove, rb.velocity.y);
        rb.velocity = move;

        Vector2 newScale = transform.localScale;
        if (hmove > 0)
        {
            faceRight = true;
            newScale.x = 1;


        }
        if (hmove < 0)
        {
            faceRight = false;
            newScale.x = -1;

        }
        transform.localScale = newScale;
        if (hmove > 0.5f || hmove < -0.5f)
        {
            animator.SetTrigger("isRunning");
        }
        Debug.Log(Input.GetAxisRaw("Horizontal"));
    }
    void PlayerJump()
    {
        Vector2 jumpCtrl = new Vector2(rb.velocity.x, jumpPower * 100* Time.deltaTime);
        if (isGround == true)
        {
            rb.velocity = jumpCtrl;
            animator.SetTrigger("isJumping");
            isGround = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D cls)
    {
        if (cls.gameObject.CompareTag("Ground"))
        {
            isGround = true;
        }
        if (cls.gameObject.CompareTag("Button"))
        {
            cls.gameObject.GetComponent<ButtonController>().isOn = false;
        }
        if (cls.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            SceneManager.LoadScene(0);
        }
    }
    private void OnTriggerEnter2D(Collider2D cls)
    {
        if (cls.gameObject.CompareTag("Gold"))
        {
            score++;
            Destroy(cls.gameObject);
        }

    }

}


