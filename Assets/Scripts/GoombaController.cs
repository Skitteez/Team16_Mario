using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoombaController : MonoBehaviour
{
    public float speed;
    public bool moveRight;

    public bool death;

    public bool shellHit = false;

    private KirbyController kirbyController;

    private KoopaController koopaController;

    private KoopaHeadDetect koopaHeadController;
    public Animator animator;

    GameObject Koopa;

    void Start()
    {
        GameObject kirbyControllerObject = GameObject.FindWithTag("Kirby");
        if (kirbyControllerObject != null)
        {
            kirbyController = kirbyControllerObject.GetComponent<KirbyController>();
        }

        GameObject Koopa = GameObject.FindWithTag("Koopa");
        if (Koopa != null)
        {
            koopaController = Koopa.GetComponent<KoopaController>();
        }

        GameObject KoopaHead = GameObject.FindWithTag("KoopaHead");
        if (KoopaHead != null)
        {
            koopaHeadController = KoopaHead.GetComponent<KoopaHeadDetect>();
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

        if (transform.position.y < -10)
        {
            Destroy(this.gameObject);
        }
    }


    private void OnCollisionEnter2D(Collision2D goombaCollide)
    {
        if(goombaCollide.collider.tag == "Turn" || goombaCollide.collider.tag == "Goomba" || (koopaController.death == true && koopaController.transform.position.x == 0 && goombaCollide.collider.tag == "Koopa"))
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

        if (koopaController.transform.position.x != 0 && goombaCollide.collider.tag == "Koopa")
        {
            shellHit = true;
        }
    }
}
