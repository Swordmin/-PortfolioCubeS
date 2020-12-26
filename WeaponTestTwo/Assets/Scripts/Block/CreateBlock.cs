using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CreateBlock : MonoBehaviour
{

    public bool isGravity;
    public bool mass;

    public bool[] type = new bool[2]; // 0 - noone, 1 - bomb, 2 -force

    public Gradient _gradient;

    public void Start()
    {
        
    }


}
