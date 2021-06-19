using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CreateBlock : MonoBehaviour
{



    [SerializeField] private bool _isGravity = false;
    [SerializeField] private bool _isBoomb = false;
    [SerializeField] private bool _isCenterInOrbit = false;

    [SerializeField] private Color _color;

    [SerializeField] private GameObject _cubeEmpty;

    [SerializeField] private GameObject _ui;
   // [SerializeField] private c

    public void Init() 
    {
        Vector3 createPoint;
        createPoint = transform.TransformDirection(transform.position);
        GameObject cube = Instantiate(_cubeEmpty, createPoint * 2, Quaternion.identity);
        if (_isGravity)
            cube.AddComponent<Rigidbody>();        
        if (_isBoomb)
            cube.AddComponent<ForceBlock>();
        if (_isCenterInOrbit)
            cube.AddComponent<BlockForce>();
    }

    public void FixedUpdate()
    {

        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            OpenUI();
        }
    }

    private void OpenUI() 
    {

        bool isActive;
        if (_ui.activeSelf) 
        {
            isActive = false;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
        else 
        {
            isActive = true;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }

        _ui.SetActive(isActive);
    }

    public void SetGravity(bool value) 
    {
        _isGravity = value;
    }

    public void SetBomb(bool value)
    {
        _isBoomb = value;
    }

    public void SetOrbit(bool value)
    {
        _isCenterInOrbit = value;
    }

}
