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

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Kirby"))
        {
            Goomba.gameObject.GetComponent<Collider2D>().enabled = false;
            goombaController.animator.SetTrigger("Death");
            goombaController.death = true;
            Destroy(Goomba.gameObject, 1f);
        }
    }
}

