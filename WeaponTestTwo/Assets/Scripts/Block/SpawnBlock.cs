using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBlock : MonoBehaviour
{

    public GameObject _pref;
    public float _time;

    public void Start()
    {
        InvokeRepeating("Spawn", 1,_time);
    }

    public void Spawn() 
    {
        GameObject objectPref = Instantiate(_pref, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
        objectPref.GetComponent<Rigidbody>().AddForce(transform.up * 4, ForceMode.Impulse);
    }

}
