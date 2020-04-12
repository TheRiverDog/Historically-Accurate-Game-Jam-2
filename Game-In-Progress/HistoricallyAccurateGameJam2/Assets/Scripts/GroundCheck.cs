using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    [SerializeField] LayerMask layerMask;

    public bool isGrounded;

    private void OnTriggerStay2D(Collider2D other) 
    {
        if (other.gameObject.layer == 10)
        {
            isGrounded = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        isGrounded = false;
    }


}
