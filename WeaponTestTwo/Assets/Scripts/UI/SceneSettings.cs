using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SceneSettings : MonoBehaviour
{

    [SerializeField] private TMP_InputField _inputGravity;
    [SerializeField] private GameObject _basicCube;

    public void Awake()
    {
        try
        {
            for (int i = 0; i < WorldSettings.startCubeCount; i++)
            {
                float y = transform.position.y + Random.Range(0, 50);
                float z = transform.position.z + Random.Range(-50, 50);
                float x = transform.position.x + Random.Range(-50, 50);
                Instantiate(_basicCube, new Vector3(x, y, z), Quaternion.identity, transform);
            }
        }
        catch { }
    }

    public void SetGravity() 
    {
        try
        {
            Physics.gravity = new Vector3(0, float.Parse(_inputGravity.text), 0);
        }
        catch { }
    }

}
