using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoombaController : MonoBehaviour
{
    public float speed;
    public bool moveRight;

    public bool death;

    private KirbyController kirbyController;

    public Animator animator;

    void Start()
    {
        GameObject kirbyControllerObject = GameObject.FindWithTag("Kirby");
        if (kirbyControllerObject != null)
        {
            kirbyController = kirbyControllerObject.GetComponent<KirbyController>();
        }

        death = false;
    } 
   
    void Update()
    {
        if (kirbyController.start == false || death == true)
        {
            return;
        }

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


    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Turn") || other.gameObject.CompareTag("Goomba") || other.gameObject.CompareTag("Koopa"))
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
    }
}
