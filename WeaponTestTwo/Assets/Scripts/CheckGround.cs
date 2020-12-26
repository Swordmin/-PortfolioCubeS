using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGround : MonoBehaviour
{

    private void OnTriggerStay(Collider other)
    {
        if(other.transform.tag == "Ground") 
        {
            Debug.Log("Colise");
            GetComponent<PlayerMovement>().isGrounded = true;
        }
    }

}
