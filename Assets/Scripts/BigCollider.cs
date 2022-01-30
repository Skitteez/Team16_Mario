using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigCollider : MonoBehaviour
{
    GameObject Kirby;

    KirbyController kirbyController;
    private void Awake()
    {
        Kirby = gameObject.transform.parent.gameObject;
    }

    void Start()
    {
        kirbyController = Kirby.GetComponent<KirbyController>();
        GetComponent<Collider2D>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (kirbyController.big == true)
        {
            GetComponent<Collider2D>().enabled = true;
        }
        else
        {
            GetComponent<Collider2D>().enabled = false;
        }
    }
}
