using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

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

    public GameObject deathScreen;
    public GameObject twoLivesScreen;
    public GameObject oneLifeScreen;
    public static int lives = 3;
    public int score;
    public int deathScore;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI deathScoreText;
    


    void Start()
    {
        rd2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        score = 0;
        deathScore = 0;


        SetScoreText();
        SetDeathScoreText();

        start = false;
        player1Selected = true;
        player2Select.SetActive(false);
        deathScreen.SetActive(false);
        twoLivesScreen.SetActive(false);
        oneLifeScreen.SetActive(false);

    }

    
    void SetScoreText()
    {
        scoreText.text = "" + score.ToString();
    }

    void SetDeathScoreText()
    {
        deathScoreText.text = "" + deathScore.ToString();
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
            score = score + 200;
            deathScore = deathScore + 200;
            SetScoreText();
            SetDeathScoreText();
        }

        if (collision.collider.tag == "Head")
        {
            rd2d.AddForce(new Vector2(0, 7), ForceMode2D.Impulse);
            score = score + 100;
            deathScore = deathScore + 100;
            SetScoreText();
            SetDeathScoreText();
        }

        if(collision.collider.tag == "Goomba")
        {
            lives = lives - 1;
            
            if (lives == 0)
            {
                Invoke("LoadDeathScreen", 3.0f);
                Invoke("LoadLevelGame", 7.0f);
                Debug.Log("Ouch!");
            }

            if (lives == 2)
            {
                Invoke("LoadTwoLivesScreen", 3.0f);
                Invoke("LoadLevelGameTwoLives", 7.0f);
                Debug.Log("Ouch!");
            }

            if (lives == 1)
            {
                Invoke("LoadOneLifeScreen", 3.0f);
                Invoke("LoadLevelGameOneLife", 7.0f);
                Debug.Log("Ouch!");
            }
        }

        if(collision.collider.tag == "Koopa")
        {
            lives = lives - 1;
            
            if (lives == 0)
            {
                Invoke("LoadDeathScreen", 3.0f);
                Invoke("LoadLevelGame", 7.0f);
                Debug.Log("Ouch!");
            }

            if (lives == 2)
            {
                Invoke("LoadTwoLivesScreen", 3.0f);
                Invoke("LoadLevelGameTwoLives", 7.0f);
                Debug.Log("Ouch!");
            }

            if (lives == 1)
            {
                Invoke("LoadOneLifeScreen", 3.0f);
                Invoke("LoadLevelGameOneLife", 7.0f);
                Debug.Log("Ouch!");
            }
        }
    }

    void LoadLevelGame()
{
    SceneManager.LoadScene("Scenes/Game");

}
 void LoadLevelGameTwoLives()
{
    SceneManager.LoadScene("Scenes/Game");

}
void LoadLevelGameOneLife()
{
    SceneManager.LoadScene("Scenes/Game");

}

    void LoadDeathScreen()
{
    deathScreen.SetActive(true);
    
}
    void LoadTwoLivesScreen()
    {
        twoLivesScreen.SetActive(true);
    }

    void LoadOneLifeScreen()
    {
        oneLifeScreen.SetActive(true);
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
