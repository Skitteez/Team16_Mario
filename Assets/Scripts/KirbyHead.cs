using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KirbyHead : MonoBehaviour
{
    GameObject Kirby;
    private void Awake()
    {
        Kirby = gameObject.transform.parent.gameObject;
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D kirbyHeadCollide)
    {
        if (kirbyHeadCollide.collider.CompareTag("MysteryBox"))
        {
            Destroy(kirbyHeadCollide.gameObject);
        }
    }
}
