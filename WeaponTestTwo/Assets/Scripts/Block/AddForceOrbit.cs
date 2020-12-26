using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForceOrbit : MonoBehaviour
{

    public Vector3 _force;

    public void FixedUpdate()
    {
        GetComponent<Rigidbody>().AddForce(_force * Time.deltaTime);
    }

}
