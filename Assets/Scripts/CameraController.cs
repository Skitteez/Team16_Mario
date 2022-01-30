using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject target;

    void LateUpdate()
    {
        this.transform.position = new Vector3(target.transform.position.x, -0.52f, this.transform.position.z);

        if (target.transform.position.x < -6.19)
        {
            this.transform.position = new Vector3( -6.19f, -0.52f, this.transform.position.z);
        }

        if (target.transform.position.x >= 189.08f)
        {
            this.transform.position = new Vector3( 189.08f, -0.52f, this.transform.position.z);
        }
    }
}
