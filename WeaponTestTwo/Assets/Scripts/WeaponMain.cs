using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponMain : MonoBehaviour
{

    [SerializeField] private Animator _animator;

    private void Start()
    {
        _animator = GetComponentInChildren<Weapon>().animator;
    }

    private void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(1)) 
        {
            Debug.Log("Aim");
            _animator.SetBool("Aim", true);
        }
        if (Input.GetMouseButtonUp(1))
        {
            _animator.SetBool("Aim", false);
        }
    }

}
