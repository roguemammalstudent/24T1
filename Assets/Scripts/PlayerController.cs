using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Variables for movement and jumping
    private float horizontal;
    public float speed = 5f;
    public float jumpingPower = 16f;

    // Interactive texts
    public GameObject wellInteractiveText;
    public GameObject wellInteractedText;
    public GameObject bushInteractiveText;
    public GameObject bushInteractedText;

    public AudioSource AudioSource;
    public SoundManager soundManager;

    //Variable for flipping the Player sprite
    private bool isFacingRight = true;

    private bool canWellInteract = false;
    private bool canBushInteract = false;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    [Header("Cameras")]
    public GameObject mainCamera;
    public GameObject clinicCamera;
    public GameObject saloonCamera;
    public GameObject saloonBalconyCamera;
    public GameObject cemeteryCamera;
    public GameObject orphanAlleyCamera;
    public GameObject houseCamera;
    public GameObject hutCamera;
    public GameObject townHallCamera;

    public Inventory inventoryUI;


    public GameObject barkeepCanvas1;
    public GameObject hatCanvas1;
    public GameObject doctorCanvas1;

    [Header("Inventory Stuff")]
    [SerializeField] private int eyeparts;
    [SerializeField] private int coreparts;
    public bool hasCollectedTheAirhorn = false;
    public bool hasCollectedTheBadgeQuest = false;
    public bool hasCollectedTheBird = false;
    public bool hasCollectedTheBloodyBat = false;
    public bool hasCollectedTheBlueFlower = false;
    public bool hasCollectedTheBootsQuest = false;
    public bool hasCollectedTheBoozeBottle = false;
    public bool hasCollectedTheBoozeQuest = false;
    public bool hasCollectedTheCactus = false;
    public bool hasCollectedTheChair = false;
    public bool hasCollectedTheDress = false;
    public bool hasCollectedTheExperimentVial = false;
    public bool hasCollectedTheFroggyHat = false;
    public bool hasCollectedTheGratitude = false;
    public bool hasCollectedTheHappy = false;
    public bool hasCollectedTheHatQuest = false;
    public bool hasCollectedTheJJBullet = false;
    public bool hasCollectedTheJacketQuest = false;
    public bool hasCollectedTheJeansQuest = false;
    public bool hasCollectedTheJustice = false;
    public bool hasCollectedTheKey = false;
    public bool hasCollectedTheKnife = false;
    public bool hasCollectedTheLavaRock = false;
    public bool hasCollectedTheMabel = false;
    public bool hasCollectedTheMemoriam = false;
    public bool hasCollectedTheMemory = false;
    public bool hasCollectedTheMission = false;
    public bool hasCollectedTheNote = false;
    public bool hasCollectedThePatientBoots = false;
    public bool hasCollectedThePatientHat = false;
    public bool hasCollectedThePatientJacket = false;
    public bool hasCollectedThePatientJeans = false;
    public bool hasCollectedThePeteyPlan = false;
    public bool hasCollectedThePillow = false;
    public bool hasCollectedThePotion = false;
    public bool hasCollectedThePotionQuest = false;
    public bool hasCollectedTheQuiet = false;
    public bool hasCollectedTheQuietQuest = false;
    public bool hasCollectedTheSheriffBadge = false;
    public bool hasCollectedTheSunflowerSeeds = false;
    public bool hasCollectedTheTruth = false;
    public bool hasCollectedTheTreasure = false;
    public bool hasCollectedTheTreasureMap = false;
    public bool hasCollectedTheWife = false;
    public bool hasCollectedTheWifeDeployed = false;
    public bool hasCollectedTheWig = false;


    void Start()
    {
        if (wellInteractiveText!= null)
        wellInteractiveText.SetActive(false);
        if (wellInteractedText!= null)
        wellInteractedText.SetActive(false);

        if (bushInteractiveText != null)
            bushInteractiveText.SetActive(false);
        if (bushInteractedText != null)
            bushInteractedText.SetActive(false);
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

        if (Input.GetKeyDown(KeyCode.E) && canWellInteract)
        {
            WellInteract();
        }

        if (Input.GetKeyDown(KeyCode.E) && canBushInteract)
        {
            BushInteract();
        }

        if (hasCollectedTheAirhorn == true);

        {
            AirhornFun();
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Interactive"))
        {
            canWellInteract = true; wellInteractiveText.SetActive(true);

            // AG: Wherever you want to check if the player has collect a specific item or not...
            //     ...use an if statement to check if that boolean is TRUE or FALSE.
            if (hasCollectedTheFroggyHat == true)
            {
                Debug.Log("You have collected the froggy hat!");
            }
        }

        if (collision.CompareTag("Bush"))
        {
            canBushInteract = true; bushInteractiveText.SetActive(true);

        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Interactive"))
        {
            canWellInteract = false; wellInteractiveText.SetActive(false);
            wellInteractedText.SetActive(false);
        }

        if (collision.CompareTag("Bush"))
        {
            canBushInteract = false; bushInteractiveText.SetActive(false);
            bushInteractedText.SetActive(false);
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

        if (collision.CompareTag("FroggyHat"))
        {
            hasCollectedTheFroggyHat = true;
        }

        if (collision.CompareTag("BoozeBottle"))
        {
            hasCollectedTheBoozeBottle = true;
        }

        if (collision.CompareTag("BlueFlower"))
        {
            hasCollectedTheBlueFlower = true;
        }

        if (collision.CompareTag("Quiet"))
        {
            hasCollectedTheBoozeBottle = true;
        }

        if (collision.CompareTag("Jeans"))
        {
            hasCollectedThePatientJeans = true;
        }

    }

    public void ActivateFunctionByName(string functionName)
    {
        Invoke(functionName ,0);
    }

    public void collectTheBoozeQuest()
    {
        hasCollectedTheBoozeQuest = true;
        barkeepCanvas1.SetActive(true);
    }

    public void collectTheQuietQuest()
    {
        hasCollectedTheQuietQuest = true;
        hatCanvas1 .SetActive(true);
    }

    public void collectTheQuiet()
    {
        hasCollectedTheQuiet = true;
    }

    public void collectTheBoozeBottle()
    {
        hasCollectedTheBoozeBottle = true;
    }

    public void collectTheJJBullet()
    {
        hasCollectedTheJJBullet = true;
    }

    public void collectTheJeansQuest()
    {
        hasCollectedTheJeansQuest = true;
        doctorCanvas1 .SetActive(true);
    }

    public void WellInteract()
    {
        Debug.Log("Interacted!");
        // put what u want to happen in here 
        wellInteractedText.SetActive(true);

        // interact after effects(?)
    }

    public void BushInteract()
    {
        Debug.Log("Airhorn get!");
        // put what u want to happen in here 
        bushInteractedText.SetActive(true);

        // interact after effects(?)
        hasCollectedTheAirhorn = true;
    }

    public void AirhornFun()
    {
        if (Input.GetKeyDown(KeyCode.F) && hasCollectedTheAirhorn)
        {
            soundManager.AirhornSound();
        }
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

    //public void MoveToClinicInt()
    //{
    //    transform.position = new Vector3(130, 34, 0);
    //}

    //public void MoveToClinicExt()
    //{
    //    transform.position = new Vector3(130, -1, 0);
    //    saloonCamera.SetActive(false);
    //    Debug.Log("Exit clinic");
    //}

    //public void MoveToSaloonInt()
    //{
    //    transform.position = new Vector3(80, 53, 0);
    //}

    //public void MoveToSaloonExt()
    //{
    //    transform.position = new Vector3(108, -1, 0);
    //    Debug.Log("Exit outside saloon");
    //}

    //public void MoveToCemeteryInt()
    //{
    //    transform.position = new Vector3(140, 66, 0);
    //}

    //public void MoveToCemeteryExt()
    //{
    //    transform.position = new Vector3(180, -1, 0);
    //    saloonCamera.SetActive(false);
    //    Debug.Log("Exit clinic");
    //}


    public void UpdateInventoryUI()
    {
        if (inventoryUI != null)
        {
            inventoryUI.UpdateEyesDisplay(eyeparts);
            inventoryUI.UpdateCoreDisplay(coreparts);
        }
    }
}

