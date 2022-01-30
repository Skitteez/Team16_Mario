using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BlockHeadCheck : MonoBehaviour
{
    GameObject Block;
    public GameObject Coin;

    public GameObject Mushroom;

    public GameObject Star;

    public bool mysteryCoin;

    public Text coinText;
    public int coinAmount = 0;

    public bool mysteryMushroom;

    public bool isBreakable;

    public bool star;

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
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D blockcollide)
    {
        if (blockcollide.collider.tag == "Kirby")
        {
            if (isBreakable == true)
            {    
                Color tmp = Block.GetComponent<SpriteRenderer>().color;
                tmp.a = 0f;
                Block.GetComponent<SpriteRenderer>().color = tmp;

                GetComponent<Collider2D>().enabled = false;
            }

            if (mysteryCoin == true)
            {
                Vector3 location = new Vector3 (x_Location, y_Location + 1.5f, 0f);
                GameObject coinGet = Instantiate(Coin, location, Quaternion.identity);

                CoinUp();
            }

            if (mysteryMushroom == true)
            {
                Vector3 m_location = new Vector3 (x_Location, y_Location + 1, 0f);
                GameObject mushGet = Instantiate(Mushroom, m_location, Quaternion.identity);
            }

            if (star == true)
            {
                Vector3 m_location = new Vector3 (x_Location, y_Location + 1, 0f);
                GameObject flowGet = Instantiate(Star, m_location, Quaternion.identity);
            }
        }
    }

    public void CoinUp()
    {
        coinAmount += 1;
        coinText.text = "x" + coinAmount.ToString();
    }
}
