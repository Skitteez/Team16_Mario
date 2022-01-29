using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KoopaHeadDetect : MonoBehaviour
{
   GameObject Koopa;
   public Animator animator;
   private KoopaController koopaController;

   bool activate;

   public int rollingSpeed = 3;
   private int counter = 0;

    private void Awake()
    {
        Koopa = gameObject.transform.parent.gameObject;
        if (Koopa != null)
        {
            koopaController = Koopa.GetComponent<KoopaController>();
        }
    }

    void Start()
    {
        activate = false;
    }

    void Update()
    {
        if (koopaController.death == true && activate == true)
        {
            if (koopaController.rollingRight)
            {
                Koopa.transform.Translate( 1 * Time.deltaTime * koopaController.speed * rollingSpeed, 0,0);
                Koopa.transform.localScale = new Vector2 (1,1);
            }
            else 
            {
                Koopa.transform.Translate( -1 * Time.deltaTime * koopaController.speed * rollingSpeed, 0,0);
                Koopa.transform.localScale = new Vector2 (-1,1);
            }
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.collider.tag == "Kirby")
        {
            koopaController.animator.SetTrigger("Death");
            koopaController.death = true;
            counter += 1;

            if (koopaController.death == true && counter > 1)
            {
                if (activate == true)
                {
                    activate = false;
                    return;
                }
                if (activate == false)
                {
                    activate = true;
                    return;
                }
            }

        }
    }
}
