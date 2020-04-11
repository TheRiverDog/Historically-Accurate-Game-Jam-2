using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

namespace HAGJ2.Fleas
{
    public class FleaReleaser : MonoBehaviour
    {
        [SerializeField] IntVariable fleasCollected = null;
        [SerializeField] Flea fleaPrefab = null;
        [SerializeField] GameObject townToRelease = null;
        [SerializeField] PlayableDirector endingCinematicsDir = null;

        [SerializeField] float fleaReleaseTimeGap = 0.3f;

        bool fleasReleased = false;

        private void OnTriggerEnter2D(Collider2D other) 
        {
            if (other.tag == "Player" && !fleasReleased)
            {
                other.gameObject.GetComponent<Rigidbody2D>().simulated = false;
                other.gameObject.GetComponent<PlayerController>().DisablePlayerControlls();
                other.gameObject.GetComponent<Animator>().SetBool("Running", false);

                fleasReleased = true;
                StartCoroutine(ReleaseFleas(other));
            }
        }

        private IEnumerator ReleaseFleas(Collider2D other)
        {
            for (int i = 1; i <= fleasCollected.GetValue(); i++)
            {
                Flea flea = Instantiate(fleaPrefab, other.transform.position, Quaternion.identity);
                AudioClip fleaJumpSFX = flea.GetComponent<AudioSource>().clip;
                AudioSource.PlayClipAtPoint(fleaJumpSFX, transform.position);
                flea.JumpOnTarget(townToRelease);

                yield return new WaitForSeconds(fleaReleaseTimeGap);
            }

            PlayEndingCinematic();
        }

        private void PlayEndingCinematic()
        {
            endingCinematicsDir.Play();
        }
    }

}