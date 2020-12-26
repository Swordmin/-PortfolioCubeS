using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spesh : MonoBehaviour
{

    public float radius;
    public float force;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            Boom();
        }
        if (Input.GetMouseButtonDown(1))
        {
            BlockController._instance.BoomForce();
        }
    }

    private void Boom() 
    {
        Collider[] overCollider = Physics.OverlapSphere(transform.position, radius);
        for(int i = 0; i < overCollider.Length; i++) 
        {
            Rigidbody rigidbody = overCollider[i].attachedRigidbody;
            if (rigidbody) 
            {
                rigidbody.AddExplosionForce(force, transform.position, radius, 1f);
            }
        }
    }
}
