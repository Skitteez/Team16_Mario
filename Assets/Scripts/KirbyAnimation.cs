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
        animBig = kirbyController.big;
    }

    void Update()
    {
        Vector2 move = new Vector2(kirbyController.horizontal, kirbyController.vertical);

        float animDirection = kirbyController.direction;

        animJumping = kirbyController.isJumping;

        animStar = kirbyController.isInvinsible;

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

        if (animBig == true)
        {
            animator.SetBool("Big", true);
        }

        if (animStar == true)
        {
            animator.SetBool("Star", true);
        }
        if (animStar == false)
        {
            animator.SetBool("Star", false);
        }

    }
}
