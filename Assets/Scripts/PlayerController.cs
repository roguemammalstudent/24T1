using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Variables for movement and jumping
    private float horizontal;
    public float speed = 5f;
    public float jumpingPower = 16f;
    public GameObject interactiveText;

    //Variable for flipping the Player sprite
    private bool isFacingRight = true;

    private bool canInteract = false;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;


    void Start()
    {
        interactiveText.SetActive(false);
    }

    void Update()
    {

        // Get Horizontal input from the Player
        horizontal = Input.GetAxisRaw("Horizontal");


        // Player presses the jump button and is grounded = jump
        //  if (Input.GetButtonDown("Jump") && IsGrounded())
        //  {
        //      rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        //  }

        // Player releases the jump button while still jumping = reduce jump height
        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }

        // Flip the player sprite if moving in the opposite direction
        Flip();


        {

            if (Input.GetKeyDown(KeyCode.E) && canInteract)

            {

                 Interact(); 

            }

        }

        private void OnTriggerEnter2D(Collider2D collision)

        {

            if (collision.CompareTag("Interactive"))

            {
                canInteract = true; interactiveText.SetActive(true);

            }

        }

        private void OnTriggerExit2D(Collider2D collision)

        {

            if (collision.CompareTag("Interactive"))

            {

                canInteract = false; interactiveText.SetActive(false);

            }

        }

        public void Interact()

        {

            // put what u want to happen in here 
            // display text
            // interact after effects

        }


    }

    private void FixedUpdate()
    {
        // Move the Player horizontally based on input
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    // Check if the player is on the ground
    //  private bool isGrounded
    //  {
    // Use a Circle Cast to detect if there is ground beneath the Player
    //   return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);



    // Flip the player sprite if moving in the opposite direction
    private void Flip()
    {

        // If moving right but facing left, or moving left but facing right = flip the sprite
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }

    }


}

