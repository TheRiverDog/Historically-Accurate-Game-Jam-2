using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDrop : MonoBehaviour
{
    PlatformEffector2D platformEffector;

    private void Awake() 
    {
        platformEffector = GetComponent<PlatformEffector2D>();
    }

   private void OnCollisionStay2D(Collision2D other) 
   {
       if (other.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.S))
       {
            platformEffector.rotationalOffset = 180f;
       }  
   }

   private void OnCollisionExit2D(Collision2D other) 
   {
        if (platformEffector.rotationalOffset == 180f)
        {
            platformEffector.rotationalOffset = 0f;
        }
   }
}
