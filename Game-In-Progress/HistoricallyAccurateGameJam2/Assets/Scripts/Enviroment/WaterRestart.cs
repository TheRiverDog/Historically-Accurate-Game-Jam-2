using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class WaterRestart : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Player")
        {
            SpriteRenderer[] sprites = other.gameObject.GetComponentsInChildren<SpriteRenderer>();
            foreach(var sprite in sprites)
            {
                sprite.enabled = false;
            }

            Rigidbody2D playerRB = other.gameObject.GetComponent<Rigidbody2D>();
            playerRB.simulated = false;

            AudioSource splash = GetComponent<AudioSource>();
            splash.Play();

            StartCoroutine(ReloadScene());
        }
    }

    private IEnumerator ReloadScene()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
