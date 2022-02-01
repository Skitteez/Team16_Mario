using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KirbyAnimation : MonoBehaviour
{
    Animator animator;
    GameObject Kirby;

    KirbyController kirbyController;

    bool animBig;

    bool animJumping;

    bool animStar;

    private void Awake()
    {
        Kirby = gameObject.transform.parent.gameObject;
    }
    void Start()
    {
        animator = GetComponent<Animator>();
        kirbyController = Kirby.GetComponent<KirbyController>();
        animator.SetBool("Big", false);
        GetComponent<Renderer>();
    }

    void Update()
    {
        Vector2 move = new Vector2(kirbyController.horizontal, kirbyController.vertical);

        float animDirection = kirbyController.direction;

        animJumping = kirbyController.isJumping;

        animStar = kirbyController.isInvinsible;

        animBig = kirbyController.big;

        if (kirbyController.onFire == true)
        {
            
        }
        
        if (kirbyController.isRunning == true)
        {
            animator.SetFloat("Speed", 17); 
        }
        else
        {
            animator.SetFloat("Speed", move.magnitude);
        }


        animator.SetFloat("Move X", animDirection);


        if (animJumping == true)
        {
            animator.SetBool("Jump", true);

            if (animDirection < 0)
            {
                animator.SetFloat("JumpDirection", 0);
            }
            else
            {
                animator.SetFloat("JumpDirection", 1);
            }
        }
        if (animJumping == false)
        {
            animator.SetBool("Jump", false);
        }

        if (animStar == true)
        {
            animator.SetBool("Star", true);
        }
        if (animStar == false)
        {
            animator.SetBool("Star", false);
        }

        if (animBig == true)
        {
            animator.SetBool("Big", true);
        }
        if (animBig == false)
        {
            animator.SetBool("Big", false);
        }

        if (kirbyController.gameEnd == true)
        {
            if (kirbyController.turn == false)
            {
                animator.SetFloat("JumpDirection", 0);
                animator.SetBool("Jump", true);
            }
            if (kirbyController.turn == true)
            {
                animator.SetFloat("Move X", 0.3f);
                animator.SetFloat("Speed", 0.5f);
            }
        }

        if (transform.position.x >= 189.08)
        {
            Color tmp = GetComponent<SpriteRenderer>().color;
            tmp.a = 0f;
            GetComponent<SpriteRenderer>().color = tmp;
        }    
    }
}
