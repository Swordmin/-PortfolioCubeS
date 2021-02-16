using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public enum MovementState 
{
    State = 0,
    Walk = 1
}

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private Transform cameraTransform;
    [SerializeField] private MovementState _stateMovement;

    [SerializeField] private float jumpHeight;
    private float rotateX, rotateY;
    [SerializeField] private float _sensevity = 1;
    [SerializeField] private float _speed;
    [SerializeField] private float _gravity = -9.81f;
    [SerializeField] private Vector3 _velocity;

    [SerializeField] private Transform _groundCheck;
    [SerializeField] private float _groundDistance = 0.4f;
    [SerializeField] private LayerMask _groundMask;

    [SerializeField] private bool _isGrounded;

    [SerializeField] private bool _freeze;

    [SerializeField] private float _moveX, _moveZ;

    [SerializeField] private TextMeshProUGUI _textTime;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        
    }

    private void Update()
    {
       
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
        if (_freeze)
            Time.timeScale = Mathf.Lerp(Time.timeScale, 0, 1 * Time.unscaledDeltaTime);

        _isGrounded = Physics.CheckSphere(_groundCheck.position, _groundDistance, _groundMask,QueryTriggerInteraction.Collide);

        if(_isGrounded && _velocity.y < 0) 
        {
            _velocity.y = -2;
        }

        rotateX -= Input.GetAxis("Mouse Y") * _sensevity;
        rotateY += Input.GetAxis("Mouse X") * _sensevity;
        rotateX = Mathf.Clamp(rotateX, -70, 70);

        if (Input.GetKey(KeyCode.W)) 
        {
             _moveZ = _speed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            _moveZ = -_speed;
        }
        if (Input.GetKey(KeyCode.D)) 
        {
            _moveX = _speed;
        }       
        if (Input.GetKey(KeyCode.A)) 
        {
            _moveX = -_speed;
        }


        _moveX *= Time.unscaledDeltaTime;
        _moveZ *= Time.unscaledDeltaTime;

        cameraTransform.localRotation = Quaternion.Euler(rotateX, 0, 0);
        transform.rotation = Quaternion.Euler(0, rotateY, 0);

        _velocity.y += _gravity * Time.unscaledDeltaTime;

        GetComponent<CharacterController>().Move((transform.right * _moveX + transform.forward * _moveZ));
        GetComponent<CharacterController>().Move(_velocity * Time.unscaledDeltaTime);

        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded) 
        {
            _velocity.y = Mathf.Sqrt(jumpHeight * -2 * _gravity);
        }

    }


    private MovementState SetStateMovement() 
    {
        return _stateMovement;
    }
    public void SetGroundCheck(bool value) 
    {
       
    }
}
