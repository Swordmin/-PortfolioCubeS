using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMove : MonoBehaviour
{

    [SerializeField] private Transform cameraTransform;

    private float rotateX, rotateY;
    [SerializeField] private float _gravity = -9.81f;
    [SerializeField] private float _sensivity;
    [SerializeField] private float _speed;
    [SerializeField] private float _movementSpeed;
    [SerializeField] private float _moveX, _moveZ;
    [SerializeField] private float _jumpHeight;

    [SerializeField] private bool _isGrounded;

    [SerializeField] private LayerMask _groundMask;

    [SerializeField] private Vector3 _direction;

    [SerializeField] private Rigidbody _rigidbody;

    [SerializeField] private Vector3 _directionMove;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void FixedUpdate()
    {


        #region SpeshInput
        if (Input.GetKeyDown(KeyCode.F))
        {
            Time.timeScale = 0.1f;
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            Time.timeScale = 1;
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            Time.timeScale = 0;
        }
        #endregion
        #region MouseInput
        rotateX -= Input.GetAxis("Mouse Y") * _sensivity;
        rotateY += Input.GetAxis("Mouse X") * _sensivity;
        rotateX = Mathf.Clamp(rotateX, -70, 70);

        cameraTransform.localRotation = Quaternion.Euler(rotateX, 0, 0);
        transform.rotation = Quaternion.Euler(0, rotateY, 0);
        #endregion
        #region MoveInput

        _directionMove = new Vector3(Input.GetAxis("Horizontal") * _speed, _rigidbody.velocity.y, Input.GetAxis("Vertical") * _speed);
        _directionMove = transform.TransformDirection(new Vector3(_directionMove.x, 0, _directionMove.z).normalized);
        _directionMove = new Vector3(_directionMove.x * _speed, _rigidbody.velocity.y, _directionMove.z * _speed);

        _isGrounded = Physics.CheckSphere(new Vector3(transform.position.x, transform.position.y - 0.52f, transform.position.z), 0.51f, _groundMask);

        if (_isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _rigidbody.AddForce(new Vector3(0, _jumpHeight, 0));
            }
        }

        _rigidbody.velocity = _directionMove;

        #endregion


    }

}
