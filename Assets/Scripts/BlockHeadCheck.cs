using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlockHeadCheck : MonoBehaviour
{
    GameObject Block;
    public GameObject Coin;

    public GameObject Mushroom;

    public GameObject Flower;

    public bool mysteryCoin;

    public Text coinText;
    public int coinAmount;

    public bool mysteryMushroom;

    public bool flower;

    public AudioSource soundSource;

    public AudioClip coinSound;

    public AudioClip mushroomSound;

    float x_Location, y_Location;
    private void Awake()
    {
        Block = gameObject.transform.parent.gameObject;
    }

    void Start()
    {
        x_Location = transform.position.x;
        y_Location = transform.position.y;

        coinText.text = coinAmount.ToString();
        coinAmount = 0;
    }

    private void OnCollisionEnter2D(Collision2D blockcollide)
    {
        if (blockcollide.collider.tag == "Kirby")
        {
            Color tmp = Block.GetComponent<SpriteRenderer>().color;
            tmp.a = 0f;
            Block.GetComponent<SpriteRenderer>().color = tmp;

            GetComponent<Collider2D>().enabled = false;

            if (mysteryCoin == true)
            {
                Vector3 location = new Vector3 (x_Location, y_Location + 1.5f, 0f);
                GameObject coinGet = Instantiate(Coin, location, Quaternion.identity);

                CoinUp();

                soundSource.clip = coinSound;
                soundSource.Play();
            }

            if (mysteryMushroom == true)
            {
                Vector3 m_location = new Vector3 (x_Location, y_Location + 1, 0f);
                GameObject mushGet = Instantiate(Mushroom, m_location, Quaternion.identity);

                soundSource.clip = mushroomSound;
                soundSource.Play();
            }

            if (flower == true)
            {
                Vector3 m_location = new Vector3 (x_Location, y_Location + 1, 0f);
                GameObject flowGet = Instantiate(Flower, m_location, Quaternion.identity);

                soundSource.clip = mushroomSound;
                soundSource.Play();
            }
        }
    }

    public void CoinUp()
    {
        coinAmount += 1;
        coinText.text = "x" + coinAmount.ToString();
    }
}
