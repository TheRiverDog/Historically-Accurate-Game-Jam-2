using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HAGJ2.Platforms
{
    public class MovingPlatform : MonoBehaviour
    {
        [SerializeField] Transform platform = null;
        [SerializeField] public Vector2 movementVector = Vector2.up;
        [SerializeField] float maxAngel = 0f;
        [Range(1,10)]
        [SerializeField] float period = 5f;

        Vector3 startingPos;
        float movementFactor;

        private void Update() 
        {
            if (period <= Mathf.Epsilon) { return; } // protect against period is zero
            float cycles = Time.time / period; // grows continually from 0

            const float tau = Mathf.PI * 2f; // about 6.28
            float rawSinWave = Mathf.Sin(cycles * tau); // goes from -1 to +1

            startingPos = transform.position;

            movementFactor = rawSinWave / 2f;
            Vector3 offset = rawSinWave * movementVector;
            platform.position = startingPos + offset;

            float newRotation = movementFactor * maxAngel;
            platform.rotation = Quaternion.Euler(0f, 0f, newRotation);
        }

        public Transform GetPlatform()
        {
            return platform;
        }
    }
}
