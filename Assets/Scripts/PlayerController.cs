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
    public GameObject interactedText;
    public AudioSource AudioSource;

    //Variable for flipping the Player sprite
    private bool isFacingRight = true;

    private bool canInteract = false;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    public GameObject mainCamera;
    public GameObject clinicCamera;
    public Transform clinicSpawnpoint;

    public Inventory inventoryUI;


    private int eyeparts;
    private int coreparts;


    void Start()
    {
        if (interactiveText!= null)
        interactiveText.SetActive(false);
        if (interactedText!= null)
        interactedText.SetActive(false);
    }



    void Update()
    {
        // Get Horizontal input from the Player
        horizontal = Input.GetAxisRaw("Horizontal");
        // Move the Player horizontally based on input
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
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
            interactedText.SetActive(false);
        }

        {
            if (collision.CompareTag("Eye"))
            {
                Destroy(collision.gameObject);
                eyeparts += 1; // Increment the parts by 1 
                UpdateInventoryUI(); // Update the parts UI display 
            }

            if (collision.CompareTag("Core"))
            {
                Destroy(collision.gameObject);
                coreparts += 1;
                UpdateInventoryUI();
            }
        }
    }

    public void Interact()
    {
        Debug.Log("Interacted!");
        // put what u want to happen in here 
        interactedText.SetActive(true);

        // interact after effects(?)
    }

    //// Check if the player is on the ground
    //private bool isGrounded()
    //{
    //   // Use a Circle Cast to detect if there is ground beneath the Player
    //   return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    //}

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

    public void MoveToClinic()
    {
        transform.position = clinicSpawnpoint.position;
    }

    public void MoveToHell()
    {
        transform.position = new Vector3(0,0,0);
    }


    public void UpdateInventoryUI()
    {
        if (inventoryUI != null)
        {
            inventoryUI.UpdateEyesDisplay(eyeparts);
            inventoryUI.UpdateCoreDisplay(coreparts);
        }
    }
}

