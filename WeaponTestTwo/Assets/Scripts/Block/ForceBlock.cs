using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceBlock : MonoBehaviour
{

    [SerializeField] private float _timer = 1;
    [SerializeField] private float _radius;
    [SerializeField] private float _force;

    public void Start()
    {
        BlockController._instance.AddBlock(this);
    }

    public void TimerBoom() 
    {
        Invoke("Boom", _timer);
    }

    public void Boom() 
    {
        Collider[] overCollider = Physics.OverlapSphere(transform.position, _radius);
        for (int i = 0; i < overCollider.Length; i++)
        {
            Rigidbody rigidbody = overCollider[i].attachedRigidbody;
            if (rigidbody)
            {
                rigidbody.AddExplosionForce(_force, transform.position, _radius, 1f);
            }
        }
    }

}
