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
    public Rigidbody rb;

    [SerializeField] private Transform cameraTransform;
    [SerializeField] private MovementState _stateMovement;

    public float jumpHeight;

    public float speedNormal, maxSpeed;
    private float rotateX, rotateY;
    public float sensevity = 1;
    public float speed, speedFall;
    public float gravity = -9.81f;
    public Vector3 velocity;

    public float speedByTime;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    public bool isGrounded;

    public float magnitude;

    public bool freeze;

    float x, z;

    public TextMeshProUGUI _textTime;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        speedNormal = speed;
    }

    void Update()
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
        if (freeze)
            Time.timeScale = Mathf.Lerp(Time.timeScale, 0, 1 * Time.unscaledDeltaTime);

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask,QueryTriggerInteraction.Collide);
     

        try
        {
            if (rb.velocity.magnitude > 0.3f)
            {
                magnitude = rb.velocity.magnitude;
                _stateMovement = MovementState.Walk;
            }
            else { _stateMovement = MovementState.State; }
        }
        catch { }

        if(isGrounded && velocity.y < 0) 
        {
            velocity.y = -2;
        }

        rotateX -= Input.GetAxis("Mouse Y") * sensevity;
        rotateY += Input.GetAxis("Mouse X") * sensevity;
        rotateX = Mathf.Clamp(rotateX, -70, 70);

        if (Input.GetKey(KeyCode.W)) 
        {
             z = speed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            z = -speed;
        }
        if (Input.GetKey(KeyCode.D)) 
        {
            x = speed;
        }       
        if (Input.GetKey(KeyCode.A)) 
        {
            x = -speed;
        }


        x *= Time.unscaledDeltaTime;
        z *= Time.unscaledDeltaTime;

        cameraTransform.localRotation = Quaternion.Euler(rotateX, 0, 0);
        transform.rotation = Quaternion.Euler(0, rotateY, 0);

        velocity.y += gravity * Time.unscaledDeltaTime;

        GetComponent<CharacterController>().Move((transform.right * x + transform.forward * z));
        GetComponent<CharacterController>().Move(velocity * Time.unscaledDeltaTime);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded) 
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }

        #region old
        /*
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(rb.transform.forward * speedNormal, ForceMode.Force);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(-rb.transform.forward * speedNormal, ForceMode.Force);
        }

        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(-rb.transform.right * speedNormal, ForceMode.Force);
        }
        else if (Input.GetKey(KeyCode.D))   
        {
            rb.AddForce(rb.transform.right * speedNormal, ForceMode.Force);
        }

        if(!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D)) 
        {
            speedNormal = 0;
        }
        else { speedNormal = speed; }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(rb.transform.up * _jumpHeight, ForceMode.Impulse);
        }*/

        #endregion
    }

    public MovementState SetStateMovement() 
    {
        return _stateMovement;
    }
}
