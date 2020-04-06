using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HAGJ2.Fleas
{
    public class FlockOfFleas : MonoBehaviour
    {
        [SerializeField] float idleTimeGaps = 0.3f;
        [SerializeField] float jumpTimeGaps = 0.3f;

        Flea[] fleas;

        private void Awake() 
        {
            fleas = GetComponentsInChildren<Flea>();
        }

        private void Start() 
        {
            DisorderFleasAnimations();
        }

        private void OnTriggerEnter2D(Collider2D other) 
        {
            if (other.tag == "Player")
            {
                LunchFleas(other.gameObject);
            }
        }

        private void LunchFleas(GameObject target)
        {
            StopAllCoroutines();
            StartCoroutine(DisorderLunchFleas(target));
        }

        private IEnumerator DisorderLunchFleas(GameObject target)
        {
            foreach (Flea flea in fleas)
            {
                flea.transform.parent = null;
                flea.JumpOnTarget(target);
                yield return new WaitForSeconds(jumpTimeGaps);
            }

            Destroy(gameObject);
        } 

        private void DisorderFleasAnimations()
        {
            foreach (Flea flea in fleas)
            {
                flea.DisableAnimator();
            }

            StartCoroutine(RandomAnimatorStart());
        }

        private IEnumerator RandomAnimatorStart()
        {
            foreach (Flea flea in fleas)
            {
                flea.EnableAnimator();
                yield return new WaitForSeconds(idleTimeGaps);
            }
        }
    }
}
