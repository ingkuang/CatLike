using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

public class PlayerMoveController : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float jumpPower = 5.0f;

    public Animator animator;
    public Rigidbody2D rigid;
    public CoinManager eventSystem;
    public HpManager hpManager;

    float horizontal;

    bool isjumping;

    private void Start()
    {
        animator = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
        eventSystem = GameObject.Find("EventSystem").GetComponent<CoinManager>();
        hpManager = GameObject.Find("EventSystem").GetComponent<HpManager>();
    }
    private void FixedUpdate()
    {
        Move();
        Jump();

        if(this.transform.position.y <-10) //추락
        {
            SceneManager.LoadScene("Game");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) //충돌
    {
        if(collision.gameObject.CompareTag("ground"))
        {
            isjumping = false;
        }
        if(collision.gameObject.CompareTag("obstacle"))
        {
            hpManager.Dead();
            collision.gameObject.SetActive(false);
        }
        if(collision.gameObject.CompareTag("target"))
        {
            SceneManager.LoadScene("GameOver");
        }
        if (collision.gameObject.CompareTag("coin"))
        {
            eventSystem.Add_coin();
            collision.gameObject.SetActive(false);
        }
    }

    void Move()
    {
        horizontal = Input.GetAxis("Horizontal");

        Vector3 dir = horizontal * Vector3.right;

        this.transform.Translate(dir * moveSpeed * Time.deltaTime);
    }

    void Jump()
    {
        if(Input.GetButton("Jump"))
        {
            if (isjumping == false)
            {
                rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
                isjumping = true;
            }
            else return;
        }
    }


}
