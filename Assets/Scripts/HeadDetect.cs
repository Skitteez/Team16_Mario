using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadDetect : MonoBehaviour
{
    GameObject Goomba;
    public Animator animator;
    private GoombaController goombaController;
    private void Awake()
    {
        Goomba = gameObject.transform.parent.gameObject;
        if (Goomba != null)
        {
            goombaController = Goomba.GetComponent<GoombaController>();
        }
    }

    void OnCollisionEnter2D(Collision2D stomp)
    {
        if (stomp.collider.tag == "Kirby")
        {
            goombaController.animator.SetTrigger("Death");
            goombaController.death = true;
            Destroy(Goomba.gameObject, 1f);
        }
    }

    void Update()
    {
        if (goombaController.shellHit == true)
        {
            ShellHit();
        }
    }

    public void ShellHit()
    {
        GetComponent<Collider2D>().enabled = false;
        Goomba.GetComponent<SpriteRenderer>().flipY = true;
        Goomba.GetComponent<Collider2D>().enabled = false;
        Vector3 movement = new Vector3(Random.Range(1, 10), Random.Range(-7, -1), 0f);
        Goomba.transform.position += movement * Time.deltaTime;
    }
}

