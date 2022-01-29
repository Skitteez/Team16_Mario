using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TomatoController : MonoBehaviour
{
    public float speed;
    bool tomatoRight = true;
    Rigidbody2D rigidbody2d;
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (tomatoRight)
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
            Destroy(gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D tomatostay)
    {
        if (tomatostay.gameObject.CompareTag("Ground"))
        {
            rigidbody2d.constraints = RigidbodyConstraints2D.FreezePositionY;
        }
    }
    private void OnTriggerEnter2D(Collider2D tomatocollide)
    {
        if (tomatocollide.gameObject.CompareTag("Turn"))
        {
            if(tomatoRight)
            {
                tomatoRight = false;
            }
            else
            {
                tomatoRight = true;     
            }
        }

        if (tomatocollide.gameObject.CompareTag("Kirby"))
        {
            Destroy(gameObject);
        }
    }
}
