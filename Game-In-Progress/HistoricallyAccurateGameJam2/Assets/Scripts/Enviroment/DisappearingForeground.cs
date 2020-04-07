using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Cinemachine;

namespace HAGJ2.Enviroment
{
    public class DisappearingForeground : MonoBehaviour
    {
        [SerializeField] float transitionTime = 3f;

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

        private void OnTriggerEnter2D(Collider2D other) 
        {
            if (other.tag == "Player")
            {
                FadeOut();

                GameObject player = GameObject.FindGameObjectWithTag("Player");
                player.GetComponent<Animator>().SetTrigger("CMTrigger");
            }

        }

        private void OnTriggerExit2D(Collider2D other) 
        {
            if (other.tag == "Player")
            {
                FadeIn();

                GameObject player = GameObject.FindGameObjectWithTag("Player");
                player.GetComponent<Animator>().SetTrigger("CMTrigger");
            }
        }

        private void SetOpaque()
        {
            Color opaque = startingColor;
            opaque.a = 1f;
            startingColorOpaque = opaque;
        }

        private void FadeIn()
        {
            StopAllCoroutines();
            StartCoroutine(SlowFade(true));
        }

        private void FadeOut()
        {
            StopAllCoroutines();
            StartCoroutine(SlowFade(false));
        }

        private IEnumerator SlowFade(bool isTransparent)
        {
            float newAlphaAdd;

            if (isTransparent)
            {
                while (mySpriteRenderer.color.a <= 1f)
                {
                    newAlphaAdd = Time.deltaTime / transitionTime;
                    Color newColor = new Color(
                        mySpriteRenderer.color.r,
                        mySpriteRenderer.color.g,
                        mySpriteRenderer.color.b,
                        mySpriteRenderer.color.a + newAlphaAdd);

                    mySpriteRenderer.color = newColor;

                    yield return null;
                }

            }
            else
            {
                while (mySpriteRenderer.color.a >= 0f)
                {
                    newAlphaAdd = Time.deltaTime / transitionTime;
                    Color newColor = new Color(
                        mySpriteRenderer.color.r,
                        mySpriteRenderer.color.g,
                        mySpriteRenderer.color.b,
                        mySpriteRenderer.color.a - newAlphaAdd);

                    mySpriteRenderer.color = newColor;

                    yield return null;
                }
            }
        }
    }
}
