﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HAGJ2.Fleas
{
    public class Flea : MonoBehaviour
    {
        [SerializeField] Animator myAnimator = null;
        [SerializeField] float lunchSpeed = 1f;
        [SerializeField] float jumpHeight = 0.1f;
        [SerializeField] float jumpHeightPeriod = 2;

        GameObject target;
        bool isJumping = false;
        float timer = 0f;
        float cycles;
        Vector3 startingPosition;

        private void Update() 
        {
            if (isJumping)
            {
                JumpingOnTarget();
            }
        }

        public void PlayJumpAnim()
        {
            myAnimator.SetTrigger("jump");
        }


        public void JumpOnTarget(GameObject target)
        {
            DisableAnimator();
            SetTarget(target);
            startingPosition = transform.position;
            isJumping = true;
        }

        private void SetTarget(GameObject target)
        {
            this.target = target;
        }

        public void DisableAnimator()
        {
            myAnimator.enabled = false;
        }

        public void EnableAnimator()
        {
            myAnimator.enabled = true;
        }

        private void JumpingOnTarget()
        {
            Vector3 targetPosition = target.transform.position;
            Vector3 myPosition = transform.position;

            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, Time.deltaTime * lunchSpeed);
            
            if (cycles < 0.5)
            {
                cycles = timer / jumpHeightPeriod;
                transform.position = new Vector2(
                    transform.position.x,
                    transform.position.y + Mathf.Sin(Mathf.PI * cycles) * jumpHeight
                );

                timer += Time.deltaTime;
            }  

            float distance = Vector3.Distance(target.transform.position, transform.position);
            if (distance <= 0.001f)
            {
                if (target.tag == "Player")
                {
                    // TODO Add Flea To Counter
                }
                Destroy(gameObject);
            }

        }
    }
}