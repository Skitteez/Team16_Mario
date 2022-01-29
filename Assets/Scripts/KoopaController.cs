using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KoopaController : MonoBehaviour
{
    public float speed;
    public bool moveRight;
    public bool rollingRight;

    public bool death;

    private KirbyController kirbyController;
    private GoombaController goombaController;

    public Animator animator;

    void Start()
    {
        GameObject kirbyControllerObject = GameObject.FindWithTag("Kirby");
        if (kirbyControllerObject != null)
        {
            kirbyController = kirbyControllerObject.GetComponent<KirbyController>();
        }

        GameObject Goomba = GameObject.FindWithTag("Goomba");
        if (Goomba != null)
        {
            goombaController = Goomba.GetComponent<GoombaController>();
        }

        death = false;
    } 
   
    void Update()
    {
        if (kirbyController.start == false)
        {
            return;
        }

        if (death == false)
        {
            if (moveRight)
            {
                transform.Translate( 1 * Time.deltaTime * speed, 0,0);
                transform.localScale = new Vector2 (1,1);
            }
            else
            {
                transform.Translate( -1 * Time.deltaTime * speed, 0,0);
                transform.localScale = new Vector2 (-1,1);
            }
        }
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "Turn" || (other.collider.tag == "Goomba" && (death == false)))
        {
            if(moveRight)
            {
                moveRight = false;
            }
            else
            {
                moveRight = true;     
            }
        }

        if ((death == true) && (other.collider.tag == "LeftLimit" || other.collider.tag == "RollingTurn"))
        {
            if(rollingRight)
            {
                rollingRight = false;
            }
            else
            {
                rollingRight = true;
            }
        }
    }
}
