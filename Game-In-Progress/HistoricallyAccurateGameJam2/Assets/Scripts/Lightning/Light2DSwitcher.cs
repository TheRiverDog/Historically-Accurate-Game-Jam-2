using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Experimental.Rendering.Universal;

namespace HAGJ2.Lights
{
    public class Light2DSwitcher : MonoBehaviour
    {
        [SerializeField] Light2D lightToSwitch = null;
        [SerializeField] Color colorToSwitch = new Color();
        [SerializeField] float switchingDistance = 3f;

        Color startColor;

        private void Start() 
        {
            startColor = lightToSwitch.color;
        }

        private void OnTriggerStay2D(Collider2D other) 
        {
            Transform player = null;
            if (other.tag == "Player")
            {
                player = other.gameObject.transform;
            }

            if (player != null)
            {
                Vector3 switcherPos = transform.position;

                float distnace = Vector3.Distance(other.transform.position, switcherPos);
                if (distnace <= switchingDistance)
                {
                    lightToSwitch.color = colorToSwitch;
                }
                else
                {
                    lightToSwitch.color = startColor;
                }
            }

        }
    }
}
