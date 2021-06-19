using System.Collections;
using System.Linq;
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
        foreach(Collider collider in overCollider.Where(coll => coll != gameObject.GetComponent<CapsuleCollider>()))
        {
            Rigidbody rigidbody = collider.GetComponent<Rigidbody>();
            if (rigidbody) 
            {
                rigidbody.AddExplosionForce(force, transform.position, radius, 1f);
            }
        }
    }
}
