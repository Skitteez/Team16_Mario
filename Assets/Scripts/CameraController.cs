using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject target;

    void LateUpdate()
    {
        this.transform.position = new Vector3(target.transform.position.x, -1.78f, this.transform.position.z);

        if (target.transform.position.x < -3.18f)
        {
            this.transform.position = new Vector3( -3.18f, -1.78f, this.transform.position.z);
        }
    }
}
