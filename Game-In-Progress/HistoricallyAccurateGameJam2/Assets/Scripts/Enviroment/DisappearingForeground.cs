using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HAGJ2.Enviroment
{
    public class DisappearingForeground : MonoBehaviour
    {
        SpriteRenderer mySpriteRenderer;
        Color startingColor;
        Color startingColorOpaque;

        private void Awake() 
        {
            mySpriteRenderer = GetComponentInParent<SpriteRenderer>();
        }

        private void Start() 
        {
            startingColor = mySpriteRenderer.color;
            SetOpaque();
        }

        private void OnTriggerStay2D(Collider2D other) 
        {
            if (other.tag == "Player")
            {
                mySpriteRenderer.color = startingColor;
            }
        }

        private void OnTriggerExit2D(Collider2D other) 
        {
            if (other.tag == "Player")
            {
                mySpriteRenderer.color = startingColorOpaque;
            }
        }

        private void SetOpaque()
        {
            Color opaque = startingColor;
            opaque.a = 1f;
            startingColorOpaque = opaque;
        }
    }
}
