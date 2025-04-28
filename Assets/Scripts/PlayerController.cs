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

    public GameObject beginningWall;

    [Header("Interactive Texts")]
    public GameObject wellInteractiveText;
    public GameObject wellInteractedText;
    public GameObject bushInteractiveText;
    public GameObject bushInteractedText;
    public GameObject morganInteractiveText;

    [Header("cat texts")]
    public GameObject misoPatText;
    public GameObject misoPattedText;
    public GameObject cookiePatText;
    public GameObject cookiePattedText;
    public GameObject danielPatText;
    public GameObject danielPattedText;
    public GameObject yoghurtPatText;
    public GameObject yoghurtPattedText;
    public GameObject herbertPatText;
    public GameObject herbertPattedText;
    public GameObject jenkinsPatText;
    public GameObject jenkinsPattedText;

    public AudioSource AudioSource;
    public SoundManager soundManager;

    private Animator animator;

    //Variable for flipping the Player sprite
    private bool isFacingRight = true;

    private bool canWellInteract = false;
    private bool canBushInteract = false;
    private bool canMorganInteract = false;
    private bool canMisoPat = false;
    private bool canCookiePat = false;
    private bool canDanielPat = false;
    private bool canYoghurtPat = false;
    private bool canHerbertPat = false;
    private bool canJenkinsPat = false;

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
    //[SerializeField] private int eyeparts;
    //[SerializeField] private int coreparts;
    public bool hasCollectedTheAirhorn = false;
    public bool hasCollectedTheBadgeQuest = false;
    public bool hasCollectedTheBeginning = false;
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
    public bool hasCollectedTheMemoriamQuest = false;
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

    [Header("get people'd idiot")]
    // The Patient
    public GameObject patientPrime;
    public GameObject patientJeans;
    public GameObject patientJacket;
    public GameObject patientBoots;
    public GameObject patientHat;
    public GameObject patientBadge;
    public GameObject patientHealed;

    // Doctor Chuck
    public GameObject doctorPrime;
    public GameObject doctorQuest;
    public GameObject doctorFlowerDelivered;
    public GameObject doctorQuestCompleted;
    public GameObject doctorIngredient;

    // Poor Petey
    public GameObject peteyPrime;
    public GameObject peteyInstructions;
    public GameObject peteyWifed;
    public GameObject peteyDeployed;
    public GameObject peteyRansacked;
    public GameObject peteyBat;

    // Susie
    public GameObject susiePrime;
    public GameObject susieInstructions;
    public GameObject susieDelivered;
    public GameObject susieBrewed;
    public GameObject susieComplete;
    public GameObject susieRemarks;

    // Jebediah
    public GameObject jebediahPrime;
    public GameObject jebediahFriend;
    public GameObject jebediahComplete;

    // Mayor Thamp
    public GameObject mayorPrime;
    public GameObject mayorHappy;
    public GameObject mayorComplete;
    public GameObject mayorIngredient;

    [Header("Get conversation'd idiot")]
    // The Patient
    public GameObject patientPrimeConversation;
    public GameObject patientJeansConversation;
    public GameObject patientJacketConversation;
    public GameObject patientBootsConversation;
    public GameObject patientHatConversation;
    public GameObject patientBadgeConversation;
    public GameObject patientHealedConversation;

    // Doctor Chuck
    public GameObject doctorPrimeConversation;
    public GameObject doctorQuestConversation;
    public GameObject doctorFlowerDeliveredConversation;
    public GameObject doctorQuestCompletedConversation;
    public GameObject doctorIngredientConversation;

    // Poor Petey
    public GameObject peteyPrimeConversation;
    public GameObject peteyInstructionsConversation;
    public GameObject peteyWifedConversation;
    public GameObject peteyDeployedConversation;
    public GameObject peteyRansackedConversation;
    public GameObject peteyBatConversation;

    // Susie
    public GameObject susiePrimeConversation;
    public GameObject susieInstructionsConversation;
    public GameObject susieDeliveredConversation;
    public GameObject susieBrewedConversation;
    public GameObject susieCompleteConversation;
    public GameObject susieRemarksConversation;

    // Jebediah
    public GameObject jebediahPrimeConversation;
    public GameObject jebediahFriendConversation;
    public GameObject jebediahCompleteConversation;

    // Mayor Thamp
    public GameObject mayorPrimeConversation;
    public GameObject mayorHappyConversation;
    public GameObject mayorCompleteConversation;
    public GameObject mayorIngredientConversation;


    void Start()
    {

        // Barnaby Well -- Big Sippy
        if (wellInteractiveText != null)
            wellInteractiveText.SetActive(false);
        if (wellInteractedText != null)
            wellInteractedText.SetActive(false);

        // Thamp Bush -- Airhorn
        if (bushInteractiveText != null)
            bushInteractiveText.SetActive(false);
        if (bushInteractedText != null)
            bushInteractedText.SetActive(false);

        // Morgan's Grave -- Doctor Chuck
        if (morganInteractiveText != null)
            morganInteractiveText.SetActive(false);

        // Cats
        // Miso
        if (misoPatText != null)
            misoPatText.SetActive(false);
        if (misoPattedText != null)
            misoPattedText.SetActive(false);

        // Cookie
        if (cookiePatText != null)
            cookiePatText.SetActive(false);
        if (cookiePattedText != null)
            cookiePattedText.SetActive(false);

        // Daniel
        if (danielPatText != null)
            danielPatText.SetActive(false);
        if (danielPattedText != null)
            danielPattedText.SetActive(false);

        // Yoghurt
        if (yoghurtPatText != null)
            yoghurtPatText.SetActive(false);
        if (yoghurtPattedText != null)
            yoghurtPattedText.SetActive(false);

        // Herbert
        if (herbertPatText != null)
            herbertPatText.SetActive(false);
        if (herbertPattedText != null)
            herbertPattedText.SetActive(false);

        // Jenkins
        if (jenkinsPatText !=null)
            jenkinsPatText.SetActive(false);
        if (jenkinsPattedText != null)
            jenkinsPattedText.SetActive(false);

        beginningWall.SetActive(true);

    }



    void Update()
    {
        // Get Horizontal input from the Player
        horizontal = Input.GetAxisRaw("Horizontal");
        // Move the Player horizontally based on input
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        // Player presses the jump button and is grounded = jump
          if (Input.GetButtonDown("Jump") && isGrounded())
          {
              rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
          }

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

        // Cats input
        if (Input.GetKeyDown(KeyCode.E) && canMisoPat)
        {
            MisoPat();
            soundManager.CatPatSound();
        }

        if (Input.GetKeyDown(KeyCode.E) && canCookiePat)
        {
            CookiePat();
            soundManager.CatPatSound();
        }

        if (Input.GetKeyDown(KeyCode.E) && canDanielPat)
        {
            DanielPat();
            soundManager.CatPatSound();
        }

        if (Input.GetKeyDown(KeyCode.E) && canYoghurtPat)
        {
            YoghurtPat();
            soundManager.CatPatSound();
        }

        if (Input.GetKeyDown(KeyCode.E) && canHerbertPat)
        {
            HerbertPat();
            soundManager.CatPatSound();
        }

        if (Input.GetKeyDown(KeyCode.E) && canJenkinsPat)
        {
            JenkinsPat();
            soundManager.JenkinsPatSound();
        }

        if (Input.GetKeyDown(KeyCode.E) && canMorganInteract && hasCollectedTheMemoriamQuest && hasCollectedTheBlueFlower)
        {
            MorganInteract();
        }

        if (hasCollectedTheAirhorn)
        {
            AirhornFun();
        }

        // Cats again

        if (Input.GetKeyDown(KeyCode.E) && canWellInteract)
        {
            WellInteract();
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

        if (collision.CompareTag("Miso"))
        {
            canMisoPat = true; misoPatText.SetActive(true);

        }

        if (collision.CompareTag("Cookie"))
        {
            canCookiePat = true; cookiePatText.SetActive(true);

        }

        if (collision.CompareTag("Daniel"))
        {
            canDanielPat = true; danielPatText.SetActive(true);

        }

        if (collision.CompareTag("Yoghurt"))
        {
            canYoghurtPat = true; yoghurtPatText.SetActive(true);

        }

        if (collision.CompareTag("Herbert"))
        {
            canHerbertPat = true; herbertPatText.SetActive(true);

        }

        if (collision.CompareTag("Jenkins"))
        {
            canJenkinsPat = true; jenkinsPatText.SetActive(true);

        }

        if (collision.CompareTag("Bush"))
        {
            canBushInteract = true; bushInteractiveText.SetActive(true);

        }

        if (collision.CompareTag("MorganGrave") && hasCollectedTheMemoriamQuest && hasCollectedTheBlueFlower)
        {
            canMorganInteract = true; morganInteractiveText.SetActive(true);

        }

        if (collision.CompareTag("ClinicDoor"))
        {
            transform.position = new Vector3(140, -2, 0);
            clinicCamera.SetActive(false);
            mainCamera.SetActive(true);
            Debug.Log("Exit Clinic");
        }

        if (collision.CompareTag("HouseDoor"))
        {
            transform.position = new Vector3(96, -2, 0);
            houseCamera.SetActive(false);
            mainCamera.SetActive(true);
            Debug.Log("Exit Jedediah's House");
        }

        if (collision.CompareTag("HutDoor"))
        {
            transform.position = new Vector3(217, -2, 0);
            hutCamera.SetActive(false);
            mainCamera.SetActive(true);
            Debug.Log("Exit Susie's Hut");
        }

        if (collision.CompareTag("OrphanDoor"))
        {
            transform.position = new Vector3(122, -2, 0);
            orphanAlleyCamera.SetActive(false);
            mainCamera.SetActive(true);
            Debug.Log("Exit Orphan Alley");
        }

        if (collision.CompareTag("SaloonDownstairsDoor"))
        {
            transform.position = new Vector3(112, -2, 0);
            saloonCamera.SetActive(false);
            mainCamera.SetActive(true);
            Debug.Log("Exit Saloon");
        }

        if (collision.CompareTag("SaloonUpstairsDoor"))
        {
            transform.position = new Vector3(24, 74, 0);
            saloonCamera.SetActive(false);
            saloonBalconyCamera.SetActive(true);
            Debug.Log("Exit Saloon Upstairs");

        }

        if (collision.CompareTag("TownHallDoor"))
        {
            transform.position = new Vector3(164, -2, 0);
            townHallCamera.SetActive(false);
            mainCamera.SetActive(true);
            Debug.Log("Exit Town Hall");
        }

        if (collision.CompareTag("CemeteryDoor"))
        {
            transform.position = new Vector3(180, -2, 0);
            cemeteryCamera.SetActive(false);
            mainCamera.SetActive(true);
            Debug.Log("Exit Cemetery");
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Interactive"))
        {
            canWellInteract = false; 
            wellInteractiveText.SetActive(false);
            wellInteractedText.SetActive(false);
        }

        if (collision.CompareTag("Bush"))
        {
            canBushInteract = false; 
            bushInteractiveText.SetActive(false);
            bushInteractedText.SetActive(false);
        }

        if (collision.CompareTag("Miso"))
        {
            canMisoPat = false;
            misoPatText.SetActive(false);
            misoPattedText.SetActive(false);
        }

        if (collision.CompareTag("Cookie"))
        {
            canCookiePat = false;
            cookiePatText.SetActive(false);
            cookiePattedText.SetActive(false);
        }

        if (collision.CompareTag("Daniel"))
        {
            canDanielPat = false;
            danielPatText.SetActive(false);
            danielPattedText.SetActive(false);
        }

        if (collision.CompareTag("Yoghurt"))
        {
            canYoghurtPat = false;
            yoghurtPatText.SetActive(false);
            yoghurtPattedText.SetActive(false);
        }

        if (collision.CompareTag("Herbert"))
        {
            canHerbertPat = false;
            herbertPatText.SetActive(false);
            herbertPattedText.SetActive(false);
        }

        if (collision.CompareTag("Jenkins"))
        {
            canJenkinsPat = false;
            jenkinsPatText.SetActive(false);
            jenkinsPattedText.SetActive(false);
        }

        if (collision.CompareTag("MorganGrave"))
        {
            canMorganInteract = false; morganInteractiveText.SetActive(false);
        }

        //{
        //    if (collision.CompareTag("Eye"))
        //    {
        //        Destroy(collision.gameObject);
        //        eyeparts += 1; // Increment the parts by 1 
        //        UpdateInventoryUI(); // Update the parts UI display 
        //    }

        //    if (collision.CompareTag("Core"))
        //    {
        //        Destroy(collision.gameObject);
        //        coreparts += 1;
        //        UpdateInventoryUI();
        //    }
        //}

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

/*        if (collision.CompareTag("Quiet"))
        {
            hasCollectedTheBoozeBottle = true;
        }*/

        if (collision.CompareTag("Jeans"))
        {
            hasCollectedThePatientJeans = true;
        }

    }

    public void ActivateFunctionByName(string functionName)
    {
        Invoke(functionName, 0);
        // if function name is has completed__quest, disable the first game object and enable the next

        // Collect the jeans, unlock jacket quest
        if (functionName == "hasCollectedTheJeans")
        {
            patientPrime.SetActive(false);
            patientPrimeConversation.SetActive(false);
            patientJeans.SetActive(true);
            patientJeansConversation.SetActive(true);
        }

        // Collect the jacket, unlock boots quest
        else if (functionName == "hasCollectedTheJacket")
        {
            patientJeans.SetActive(false);
            patientJeansConversation.SetActive(false);
            patientJacket.SetActive(true);
            patientJacketConversation.SetActive(true);
        }

        // Collect the boots, unlock hat quest
        else if (functionName == "hasCollectedTheBoots")
        {
            patientJacket.SetActive(false);
            patientJacketConversation.SetActive(false);
            patientBoots.SetActive(true);
            patientBootsConversation.SetActive(true);
        }

        // Collect the hat, unlock the badge quest
        else if (functionName == "hasCollectedTheHat")
        {
            patientBoots.SetActive(false);
            patientBootsConversation.SetActive(false);
            patientHat.SetActive(true);
            patientHatConversation.SetActive(true);
        }

        // Collect the badge, unlock the treasure map
        else if (functionName == "hasCollectedTheBadge")
        {
            patientHat.SetActive(false);
            patientHatConversation.SetActive(false);
            patientBadge.SetActive(true);
            patientBadgeConversation.SetActive(true);
        }

        // Final conversation
        else if (functionName == "hasCollectedTheTreasureMap")
        {
            patientBadge.SetActive(false);
            patientBadgeConversation.SetActive(false);
            patientHealed.SetActive(true);
            patientHealedConversation.SetActive(true);
        }

        // Doctor Chuck
        // Collect the jeans quest, speak to Doctor
        else if (functionName == "hasCollectedTheJeansQuest")
        {
            doctorPrime.SetActive(false);
            doctorPrimeConversation.SetActive(false);
            doctorQuest.SetActive(true);
            doctorQuestConversation.SetActive(true);
        }

        // Laid the flower, return for Gratitude
        else if (functionName == "hasCollectedTheMemoriam")
        {
            doctorQuest.SetActive(false);
            doctorQuestConversation.SetActive(false);
            doctorFlowerDelivered.SetActive(true);
            doctorFlowerDeliveredConversation.SetActive(true);
        }

        // Have Gratitude, DON'T have Susie's quest active
        else if (functionName == "hasCollectedTheGratitude")
        {
            doctorFlowerDelivered.SetActive(false);
            doctorFlowerDeliveredConversation.SetActive(false);
            doctorQuestCompleted.SetActive(true);
            doctorQuestCompletedConversation.SetActive(true);
        }

        // Have Gratitude, AND have Susie's quest active (PotionQuest)
        else if (functionName == "hasCollectedTheMemoriam" && functionName == "hasCollectedThePotionQuest")
        {
            doctorQuestCompleted.SetActive(false);
            doctorIngredient.SetActive(true);
        }

        // Have Gratitude, AND have the experimental vial (PotionQuest)
        else if (functionName == "hasCollectedTheMemoriam" && functionName == "hasCollectedTheExperimentalVial")
        {
            doctorIngredient.SetActive(false);
            doctorQuestCompleted.SetActive(true);
        }

        // Petey
        // Speak to again after first time without ingredients
        else if (functionName == "hasCollectedThePeteyPlan")
        {
            peteyPrime.SetActive(false);
            peteyInstructions.SetActive(true);
        }

        // Return to Petey with the ingredients
        else if (functionName == "hasCollectedTheCactus" && functionName == "hasCollectedTheDress" && functionName == "hasCollectedTheWig")
        {
            peteyInstructions.SetActive(false);
            peteyWifed.SetActive(true);
        }

        // Speak to Petey after deploying the decoy
        else if (functionName == "hasCollectedThePeteyPlan")
        {
            peteyWifed.SetActive(false);
            peteyDeployed.SetActive(true);
        }

        // Speak to Petey again after ransacking Jebediah's home
        else if (functionName == "hasCollectedTheChair" && functionName == "hasCollectedTheKnife" && functionName == "hasCollectedThePillow")
        {
            peteyDeployed.SetActive(false);
            peteyRansacked.SetActive(true);
        }

        // Speak to Petey anytime after completing his quest
        else if (functionName == "hasCollectedTheBloodyBat")
        {
            peteyRansacked.SetActive(false);
            peteyBat.SetActive(true);
        }

        // Susie
        // Speak to Susie for the second time
        else if (functionName == "hasCollectedThePotionQuest")
        {
            peteyRansacked.SetActive(false);
            peteyBat.SetActive(true);
        }

        // Jebediah
        // 
        else if (functionName == "hasCollectedTheWife")
        {
            jebediahPrime.SetActive(false);
            jebediahFriend.SetActive(true);
        }

        else if (functionName == "hasCollectedTheWifeDeployed")
        {
            jebediahFriend.SetActive(false);
            jebediahComplete.SetActive(true);
        }

        // Mayor Thamp
        else if (functionName == "hasCollectedTheBird")
        {
            mayorPrime.SetActive(false);
            mayorHappy.SetActive(true);
        }

        else if (functionName == "hasCollectedTheHappy")
        {
            mayorHappy.SetActive(false);
            mayorComplete.SetActive(true);
        }
        
        
        else if (functionName == "hasCollectedThePotionQuest" && functionName == "hasCollectedTheNote")
        {
            mayorComplete.SetActive(false);
            mayorIngredient.SetActive(true);
        }

        else if (functionName == "hasCollectedTheSunflowerSeeds")
        {
            mayorIngredient.SetActive(false);
            mayorComplete.SetActive(true);

        }

    }
    public void collectTheBeginning()
    {
        hasCollectedTheBeginning = true;
        beginningWall.SetActive(false);
    }
    public void collectTheBoozeQuest()
    {
        hasCollectedTheBoozeQuest = true;
        barkeepCanvas1.SetActive(true);
    }

    public void collectTheQuietQuest()
    {
        hasCollectedTheQuietQuest = true;
        hatCanvas1.SetActive(true);
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
        doctorPrime.SetActive(false);
        doctorPrimeConversation.SetActive(false);
        doctorQuest.SetActive(true);
        doctorQuestConversation.SetActive(true);
    }

    public void collectTheJacketQuest()
    {
        hasCollectedTheJacketQuest = true;
    }

    public void collectTheMemoriamQuest()
    {
        hasCollectedTheMemoriamQuest = true;
    }

    public void collectTheMemoriam()
    {
        hasCollectedTheMemoriam = true;
        doctorQuest.SetActive(false);
        doctorQuestConversation.SetActive(false);
        doctorFlowerDelivered.SetActive(true);
        doctorFlowerDeliveredConversation.SetActive(true);
    }

    public void collectTheGratitude()
    {
        hasCollectedTheGratitude = true;
        doctorFlowerDelivered.SetActive(false);
        doctorFlowerDeliveredConversation.SetActive(false);
        doctorQuestCompleted.SetActive(true);
        doctorQuestCompletedConversation.SetActive(true);
    }

    public void collectThePeteyPlan()
    {
        hasCollectedThePeteyPlan = true;
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

    public void MisoPat()
    {
        Debug.Log("Pat!");
        // put what u want to happen in here 
        misoPattedText.SetActive(true);
    }

    public void CookiePat()
    {
        Debug.Log("Pat!");
        // put what u want to happen in here 
        cookiePattedText.SetActive(true);
    }

    public void DanielPat()
    {
        Debug.Log("Pat!");
        // put what u want to happen in here 
        danielPattedText.SetActive(true);
    }

    public void YoghurtPat()
    {
        Debug.Log("Pat!");
        // put what u want to happen in here 
        yoghurtPattedText.SetActive(true);
    }

    public void HerbertPat()
    {
        Debug.Log("Pat!");
        // put what u want to happen in here 
        herbertPattedText.SetActive(true);
    }

    public void JenkinsPat()
    {
        Debug.Log("Pat!");
        // put what u want to happen in here 
        jenkinsPattedText.SetActive(true);
    }

    public void MorganInteract()
    {
        Debug.Log("Memoriam");
        hasCollectedTheMemoriam = true;
    }

    public void AirhornFun()
    {
        if (Input.GetKeyDown(KeyCode.F) && hasCollectedTheAirhorn)
        {
            soundManager.AirhornSound();
        }
    }


    //// Check if the player is on the ground
    private bool isGrounded()
    {
    //   // Use a Circle Cast to detect if there is ground beneath the Player
       return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

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

    //public void MoveToClinicInt()
    //{
    //    transform.position = new Vector3(130, 34, 0);
    //}

    //public void MoveToClinicExt()
    //{
        
    //    transform.position = new Vector3(130, -1, 0);
    //    clinicCamera.SetActive(false);
    //    Debug.Log("Exit clinic");
    //}

    //public void MoveToSaloonInt()
    //{
    //    transform.position = new Vector3(80, 53, 0);
    //}

    //public void MoveToSaloonExt()
    //{
    //    transform.position = new Vector3(108, -1, 0);
    //    saloonCamera.SetActive(false);
    //    Debug.Log("Exit outside saloon");
    //}

    //public void MoveToCemeteryInt()
    //{
    //    transform.position = new Vector3(140, 66, 0);
    //}

    //public void MoveToCemeteryExt()
    //{
    //    transform.position = new Vector3(180, -1, 0);
    //    cemeteryCamera.SetActive(false);
    //    Debug.Log("Exit Cemetery");
    //}


//    public void UpdateInventoryUI()
//    {
//        if (inventoryUI != null)
//        {
//            inventoryUI.UpdateEyesDisplay(eyeparts);
//            inventoryUI.UpdateCoreDisplay(coreparts);
//        }
//    }
//}

