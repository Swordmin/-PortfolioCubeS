using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockForce : MonoBehaviour
{

    [SerializeField] private float _timer = 1;
    [SerializeField] private float _radius;
    [SerializeField] private float _force;
    [SerializeField] private bool _isForce;

    [SerializeField] private List<Rigidbody> _bodys = new List<Rigidbody>();

    private bool active = true;

    public void Start()
    {


    }


    public void FixedUpdate()
    {
        if(Input.GetKeyDown(KeyCode.J))
            active = active ? false : true;

        if (active)
        {
            foreach (Rigidbody body in _bodys)
            {
                Vector3 dirrectionToCube = (transform.position - body.transform.position).normalized;

                float distance = (transform.position - body.position).magnitude;
                float st = 3f * body.mass * GetComponentInParent<Rigidbody>().mass / (distance);
                body.AddForce(((dirrectionToCube * st)) * Time.deltaTime);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.attachedRigidbody != null) 
        {
            _bodys.Add(other.attachedRigidbody);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.attachedRigidbody != null)
        {
            _bodys.Remove(other.attachedRigidbody);
        }
    }
}
