using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KirbyController : MonoBehaviour
{
    private Rigidbody2D rd2d;
    float horizontal;
    float vertical;
    public float speed;

    Animator animator;

    float direction;

    private bool isJumping;

    public bool start;
    bool player1Selected;

    public GameObject player1Select;
    public GameObject player2Select;
    public GameObject title;
    public GameObject player1option;
    public GameObject player2option;


    void Start()
    {
        rd2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        start = false;
        player1Selected = true;
        player2Select.SetActive(false);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.collider.tag == "Ground")
        {
            if (start == false)
            {
                return;
            }

            if(Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.X))
            {
                rd2d.AddForce(new Vector2(0, 6), ForceMode2D.Impulse);
                animator.SetBool("Jump", true);
                isJumping = true;
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (start == false)
        {
            return;
        }

        if(collision.collider.tag == "Ground")
        {
            isJumping = false;
            animator.SetBool("Jump", false);
        }

        if (collision.collider.tag == "KoopaHead")
        {
            rd2d.AddForce(new Vector2(0, 7), ForceMode2D.Impulse);
        }

        if (collision.collider.tag == "Head")
        {
            rd2d.AddForce(new Vector2(0, 7), ForceMode2D.Impulse);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

    }
    void Update()
    {           
        if(Input.GetKey("escape"))
        {
            Application.Quit();
        }

        if (start == false)
        {
            if (player1Selected == true)
            {
                if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
                {
                    player1Select.SetActive(false);
                    player2Select.SetActive(true);

                    player1Selected = false;
                }
                if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.X))
                {
                    start = true;
                    player1Select.SetActive(false);
                    title.SetActive(false);
                    player1option.SetActive(false);
                    player2option.SetActive(false);
                }
            }

            if (player1Selected == false)
            {
                if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
                {
                    player1Select.SetActive(true);
                    player2Select.SetActive(false);

                    player1Selected = true;
                }
            }
            return;
        }

        Vector2 move = new Vector2(horizontal, vertical);

        if (!Mathf.Approximately(move.x, 0.0f))
        {
            direction = move.x;
        }

        if (Input.GetKey(KeyCode.Z) || Input.GetKey(KeyCode.RightShift) || Input.GetKey(KeyCode.LeftShift)) 
        {
            speed = 17f;
            animator.SetFloat("Speed", 17);
        }
        else
        {
            speed = 11f;
            animator.SetFloat("Speed", move.magnitude);
        }

        animator.SetFloat("Move X", direction);

        if (isJumping == true)
        {
            if (direction < 0)
            {
                animator.SetFloat("JumpDirection", 0);
            }
            else
            {
                animator.SetFloat("JumpDirection", 1);
            }
        }

    }

    void FixedUpdate()
    {
        if (start == false)
        {
            return;
        }

        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        rd2d.AddForce(new Vector2(horizontal * speed, vertical * speed));
    }
}
