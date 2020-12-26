using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    public Transform _bulletPos;
    [SerializeField] private GameObject _bullet;
    [SerializeField] private float _callDown;
    [SerializeField] private bool _isShoot;
    public Animator animator;

    // Start is called before the first frame update
    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _isShoot = true;
            StartCoroutine(_callDownFire());
        }
        if (Input.GetMouseButtonUp(0)) 
        {
            _isShoot = false;
            StopAllCoroutines();
        }
    }

    private IEnumerator _callDownFire() 
    {
        Debug.Log("Shooting");
        while (_isShoot) 
        {
            animator.Play("Shoot");
            GameObject _template = Instantiate(_bullet, _bulletPos.position, GetComponentInParent<Camera>().transform.rotation);
            _template.transform.parent = null;
            yield return new WaitForSeconds(_callDown);
        }
    }
}
