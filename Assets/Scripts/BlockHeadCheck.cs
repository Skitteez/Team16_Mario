using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockHeadCheck : MonoBehaviour
{
    GameObject Block;
    private void Awake()
    {
        Block = gameObject.transform.parent.gameObject;
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D blockcollide)
    {
        if (blockcollide.collider.tag == "Kirby")
        {
            Color tmp = Block.GetComponent<SpriteRenderer>().color;
            tmp.a = 0f;
            Block.GetComponent<SpriteRenderer>().color = tmp;

            GetComponent<Collider2D>().enabled = false;
        }
    }
}
