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
                if (flea == null) { continue; }

                flea.transform.parent = null;
                flea.JumpOnTarget(target);
                AudioClip fleaJump = flea.GetComponent<AudioSource>().clip;
                AudioSource.PlayClipAtPoint(fleaJump, flea.transform.position);

                yield return new WaitForSeconds(jumpTimeGaps);
            }

            Destroy(gameObject);
        } 

        private void DisorderFleasAnimations()
        {
            foreach (Flea flea in fleas)
            {
                if (flea == null) { continue; }
                flea.DisableAnimator();
            }

            StartCoroutine(RandomAnimatorStart());
        }

        private IEnumerator RandomAnimatorStart()
        {
            foreach (Flea flea in fleas)
            {
                if (flea == null) { continue; }
                flea.EnableAnimator();
                yield return new WaitForSeconds(idleTimeGaps);
            }
        }
    }
}
