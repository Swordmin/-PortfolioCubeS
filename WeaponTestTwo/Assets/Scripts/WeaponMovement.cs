using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponMovement : MonoBehaviour
{
    [SerializeField] private PlayerMovement _player;
    [SerializeField] private Weapon _mainWeapon;
    [SerializeField] private float _amplitude;
    [SerializeField] private float _freq;
    [SerializeField] private Animator _animator;


    private void Awake()
    {
        _player = GetComponent<PlayerMovement>();
    }

    private void FixedUpdate()
    {
        Movement();
    }

    private void Movement() 
    {
        if (_player.SetStateMovement() == MovementState.Walk)
        {
            _animator.SetBool("Rest", false);
            _animator.Play("MoveMainWeaponWalk");
        }
        else 
        {
            _animator.SetBool("Rest", true);
        }
    }

}
