using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KirbyController : MonoBehaviour
{
    private Rigidbody2D rd2d;
    public float horizontal;
    public float vertical;
    public float speed;
    public float direction;

    public bool isJumping;

    public bool isRunning;

    public bool big;

    public bool gameEnd;

    public bool turn;

    public bool start;

    public bool onFire;
    bool player1Selected;

    public bool isInvinsible;

    public GameObject player1Select;
    public GameObject player2Select;
    public GameObject title;
    public GameObject player1option;
    public GameObject player2option;

    BoxCollider2D kirbyCollider;

    public float starTimer = 20.0f;
    

    void Start()
    {
        rd2d = GetComponent<Rigidbody2D>();
        kirbyCollider = GetComponent<BoxCollider2D>();

        start = false;
        player1Selected = true;
        player2Select.SetActive(false);
        isJumping = false;
        isInvinsible = false;
        gameEnd = false;
        turn = false;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.collider.tag == "Ground")
        {
            if (start == false)
            {
                return;
            }

            if((Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.X)) && gameEnd == false)
            {
                rd2d.AddForce(new Vector2(0, 6), ForceMode2D.Impulse);
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
        if (collision.gameObject.tag == "Tomato" && big == false)
        {
            big = true;
            this.GetComponent<BoxCollider2D>().size = new Vector2(1.729276f, 1.980337f);
            this.GetComponent<BoxCollider2D>().offset = new Vector2(-0.08966541f, 0.4901683f);
        
        }

        if (collision.gameObject.tag == "Hammer")
        {
            isInvinsible = true;
        }

        if (collision.gameObject.tag == "FlagPole")
        {
            Endgame();

        }

        if (collision.gameObject.tag == "FlagTop")
        {
            Endgame();
        }

        if (collision.gameObject.tag == "FlagBottom")
        {
            turn = true;
        }

        if (collision.gameObject.tag == "FireFlower")
        {
            onFire = true;
        }
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
            isRunning = true;
        }
        else
        {
            speed = 11f;
            isRunning = false;
        }

        
        if (isInvinsible == true)
        {
            starTimer -= Time.deltaTime;

            if (starTimer <= 0.0f)
            {
                timerEnded();
            }
        }
    }

    void FixedUpdate()
    {
        if (start == false)
        {
            return;
        }

        if (gameEnd == false)
        {
            horizontal = Input.GetAxis("Horizontal");
            vertical = Input.GetAxis("Vertical");
            rd2d.AddForce(new Vector2(horizontal * speed, vertical * speed));
        }

        if (gameEnd == true && transform.position.y <= -2)
        {
            rd2d.AddForce(new Vector2(10,0));
        }   
    }

    void timerEnded()
    {
        isInvinsible = false;
    }

    void Endgame()
    {
        gameEnd = true;
        transform.position = new Vector3(182.06f, transform.position.y, 0f);

        rd2d.MovePosition(transform.position + Vector3.up * 2.0f);

    }
}
