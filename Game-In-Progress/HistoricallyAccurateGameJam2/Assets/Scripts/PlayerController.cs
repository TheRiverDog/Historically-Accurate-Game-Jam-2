using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] AudioSource jumpSFX = null;
    [SerializeField] Collider2D myFeet = null;
    [SerializeField] float runSpeed = 5f;
    [SerializeField] float jumpSpeed = 5f;

    Rigidbody2D myRigidbody;
    Animator myAnimator;

    bool isControllAllowed = true;

    private void Awake()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
    }

    private void FixedUpdate() 
    {
        if (isControllAllowed)
        {
            Run();
            FlipSprite();
        }
    }

    private void Update() 
    {
        if (isControllAllowed)
        {
            Jump();
        }
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.gameObject.tag == "MovingPlatform")
        {
            transform.parent = other.transform;
        }
    }

    private void OnCollisionExit2D(Collision2D other) 
    {
        if (other.gameObject.tag == "MovingPlatform")
        {
            transform.parent = null;
        }
    }

    private void Run()
    {
        float controlThrow = Input.GetAxis("Horizontal");
        Vector2 playerVelocity = new Vector2(controlThrow * runSpeed, myRigidbody.velocity.y);
        myRigidbody.velocity = playerVelocity;

        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;
        myAnimator.SetBool("Running", playerHasHorizontalSpeed);
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && myFeet.gameObject.GetComponent<GroundCheck>().isGrounded)
        {
            jumpSFX.Play();
            Vector2 jumpVelocityToAdd = new Vector2(0f, jumpSpeed);
            myRigidbody.velocity += jumpVelocityToAdd;
        }
    }

    private void FlipSprite()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;
        if (playerHasHorizontalSpeed)
        {
            transform.localScale = new Vector2(Mathf.Sign(myRigidbody.velocity.x), 1f);
        }
    }

    public void DisablePlayerControlls()
    {
        isControllAllowed = false;
    }
}
