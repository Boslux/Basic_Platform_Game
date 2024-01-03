using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [Header("")]
    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sp;
    public PlayerStats ps;


    [Header("Config")]
    public bool isGround;
    public bool faceRight;
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sp = GetComponent<SpriteRenderer>();
    }


    void Update()
    {
        Move();
    }
    private void Move()
    {
        //Movement
        float hmove = Input.GetAxis("Horizontal") * ps.speed * Time.deltaTime * 100;
        Vector2 move = new Vector2(hmove, rb.velocity.y);
        rb.velocity= move;

        anim.SetFloat("Run", rb.velocity.magnitude);

        if (Input.GetButtonDown("Jump"))
            PlayerJump();

        if (hmove > 0)
            sp.flipX = false;
        if (hmove < 0)
            sp.flipX = true;
        else
            sp.flipX = sp.flipX;

    }
    void PlayerJump()
    {
        // Player Jump Controller
        Vector2 jumpCtrl = new Vector2(rb.velocity.x, ps.jumpPower * 100* Time.deltaTime);
        if (isGround == true)
        {
            rb.velocity = jumpCtrl;
            anim.SetTrigger("isJumping");
            isGround = false;
        }
    }
    private void TakeDamage()
    {
        Destroy(gameObject);
        SceneManager.LoadScene(0);
        ps.gold = 0;
    }

    private void OnCollisionEnter2D(Collision2D cls)
    {   
        if (cls.gameObject.CompareTag("Ground"))
            isGround = true;

        //Button Controlle
        if (cls.gameObject.CompareTag("Button"))
            cls.gameObject.GetComponent<ButtonController>().isOn = false;


        if (cls.gameObject.CompareTag("Enemy"))
            TakeDamage();
    }
    private void OnTriggerEnter2D(Collider2D cls)
    {
        if (cls.gameObject.CompareTag("Gold"))
        {
            ps.gold++;
            Destroy(cls.gameObject);
            
        }
    }
}


