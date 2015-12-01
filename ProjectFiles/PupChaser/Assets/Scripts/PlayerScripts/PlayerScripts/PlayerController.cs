using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour {

    //Attack cooldown for character, might want to change this system later, not sure if there is a better way.
	public float attackCooldown;

    //Time for charge attack to charge
    public float chargeTime;

    //Boolean for if player has charged attack long enough
    public bool isCharge;

    //Bool for attack script to know when to charge attack
    public bool chargeAttack;

    //Bool used for attack scripts and cooldowns
    public bool attack;
    public float chargeCooldown;
    public int healthPoints;
    public bool dead;
    public bool inCharge;
    public bool invincible;
    public float invincibilityCoolDown;
    public bool canShoot;
    public float shootCooldown;

    //Floats for xbox controller axis
    public float xMovement;
    public float yMovement;

    public Rigidbody2D rBody;

    //Movement speed of character
    public float walkSpeed;

    //Global variable useful for other scipts to be able to tell your direction
    //Directions: Up = 1, Left = 2, Down = 3, Right = 4
    public int directionFacing;
   
    //Character animator
	public Animator playerAnimation;

    //Global variable of character position
	public Vector3 charPosition;

	//slider 
	public Slider healthBarSlider;
    public float triggerMovement;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.name == "explosion(Clone)")
        {
            if(!invincible)
            {
                healthBarSlider.value -= 4.0f;
                healthPoints -= 4;
            }
            invincible = true;
            invincibilityCoolDown = 0.5f;
            SoundController.PlaySound(sounds.playerHurt);
        }
        if (other.tag == "heart")
        {
            if (healthPoints + 3 > 20)
            {
                healthBarSlider.value = 20;
                healthPoints = 20;
            }
            else
            {
                healthBarSlider.value += 3.0f;
                healthPoints += 3;
            }
        }
        if (other.tag == "Berserker")
        {
            if (!invincible)
            {
                healthBarSlider.value -= 3f;
                healthPoints = healthPoints-3;
            }
            invincible = true;
            invincibilityCoolDown = 0.5f;
			SoundController.PlaySound(sounds.playerHurt);
        }
        if(other.gameObject.name == "leaf(Clone)")
        {
            if (!invincible)
            {
                healthBarSlider.value -= 1f;
                healthPoints = healthPoints--;
            }
            invincible = true;
            invincibilityCoolDown = 0.5f;
			SoundController.PlaySound(sounds.playerHurt);
        }
        if (other.gameObject.name == "rock(Clone)")
        {
            if (!invincible)
            {
                healthBarSlider.value -= 1f;
                healthPoints = healthPoints--;
            }
            invincible = true;
            invincibilityCoolDown = 0.5f;
			SoundController.PlaySound(sounds.playerHurt);
        }
		if (other.gameObject.name == "fireBall(Clone)")
		{
            if (!invincible)
            {
                healthBarSlider.value -= 1f;
                healthPoints = healthPoints--;
            }
            invincible = true;
			invincibilityCoolDown = 0.5f;
			SoundController.PlaySound(sounds.playerHurt);
		}
		if (other.gameObject.name == "iceShard(Clone)")
		{
            if (!invincible)
            {
                healthBarSlider.value -= 1f;
                healthPoints = healthPoints--;
            }
            invincible = true;
			invincibilityCoolDown = 0.5f;
			SoundController.PlaySound(sounds.playerHurt);
		}
		if (other.gameObject.name == "lightning(Clone)")
		{
            if (!invincible)
            {
                healthBarSlider.value -= 1f;
                healthPoints = healthPoints--;
            }
            invincible = true;
			invincibilityCoolDown = 0.5f;
			SoundController.PlaySound(sounds.playerHurt);
		}

		if (other.gameObject.name == "Spider Enemy(Clone)")
		{
            if(!invincible)
            {
                healthBarSlider.value -=1f;
                healthPoints = healthPoints--;
            }

			invincible = true;
			invincibilityCoolDown = 0.5f;
			SoundController.PlaySound(sounds.playerHurt);
		}

		if (other.gameObject.name == "spider web(Clone)")
		{
            if (!invincible)
            {
                healthBarSlider.value -= 1f;
                healthPoints = healthPoints--;
            }
			invincible = true;
			invincibilityCoolDown = 0.5f;
			SoundController.PlaySound(sounds.playerHurt);
		}
		if (other.gameObject.name == "weakAttack(Clone)")
		{
            if (!invincible)
            {
                healthBarSlider.value -= 1f;
                healthPoints = healthPoints--;
            }

            invincible = true;
			invincibilityCoolDown = 0.5f;
			SoundController.PlaySound(sounds.playerHurt);
		}
		if (other.gameObject.name == "mediumAttack(Clone)")
		{
            if (!invincible)
            {
                healthBarSlider.value -= 2f;
                healthPoints = healthPoints-2;
            }

            invincible = true;
			invincibilityCoolDown = 0.5f;
			SoundController.PlaySound(sounds.playerHurt);
		}
		if (other.gameObject.name == "strongAttack(Clone)")
		{
            if (!invincible)
            {
                healthBarSlider.value -= 3f;
                healthPoints = healthPoints-3;
            }

            invincible = true;
			invincibilityCoolDown = 0.5f;
			SoundController.PlaySound(sounds.playerHurt);
		}
		if (other.gameObject.name == "explosion(Clone)")
		{
            if (!invincible)
            {
                healthBarSlider.value -= 3f;
                healthPoints = healthPoints - 3;
            }
            invincible = true;
			invincibilityCoolDown = 0.5f;
			SoundController.PlaySound(sounds.playerHurt);
		}

		if (other.gameObject.name == "spikesup(Clone)")
		{
            if (!invincible)
            {
                healthBarSlider.value -= 1f;
                healthPoints = healthPoints--;
            }

            invincible = true;
			invincibilityCoolDown = 0.5f;
		}

    }


    // Use this for initialization
    void Start ()
    {
        //Get components and initialize variables
        rBody = GetComponent<Rigidbody2D>();
        charPosition = transform.position;
        healthPoints = 20;

        dead = false;
        isCharge = false;
        canShoot = true;
        chargeCooldown = 0.1f;
        chargeTime = -1;
        chargeTime = 0.0f;
        invincible = false;
        invincibilityCoolDown = 0.5f;

        playerAnimation = GetComponent<Animator>();
        playerAnimation.SetBool("isMoving", false);
		playerAnimation.SetBool ("Attack", false);
		playerAnimation.SetInteger("DirectionFacing", 3);
		attackCooldown = 0.0f;
	}
	
	// Update is called once per frame
	void Update ()
    {

        xMovement = Input.GetAxis("LeftStickHorizontal");
        yMovement = Input.GetAxis("LeftStickVertical");

        triggerMovement = Input.GetAxis("RightTrigger");

        print(triggerMovement);

        //Update character position for other scripts
        charPosition = transform.position;
        if (healthPoints < 1 || healthBarSlider.value < 1) 
		{
            playerAnimation.SetBool("isDead", true);
            dead = true;
			SoundController.PlaySound(sounds.playerDie);
        }

        if (invincible)
        {
            invincibilityCoolDown -= Time.deltaTime;
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.5f);
        }
        if (invincibilityCoolDown < 0)
        {
            invincible = false;
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
        }
        if(inCharge)
        {
            chargeCooldown -= Time.deltaTime;
        }
        if(chargeCooldown < 0)
        {
            inCharge = false;
        }

        if (!dead)
        {
            //Lower attack cooldown. Is there a better  way for this?
            if (attackCooldown > 0.0f)
            {
                attackCooldown -= Time.deltaTime;
            }

            if(shootCooldown >= 0.0f)
            {
                shootCooldown -= Time.deltaTime;
                canShoot = true;
            }

            if (chargeTime >= 1.0f)
            {
                isCharge = true;
                GetComponent<SpriteRenderer>().color = Color.cyan;
            }
            if (chargeTime > 1.2)
            {
                GetComponent<SpriteRenderer>().color = Color.white;
            }
            if (inCharge)
            {
                chargeCooldown -= Time.deltaTime;
            }

            if (chargeCooldown < 0)
            {
                inCharge = false;
            }


            //Checking if the character is moving or not, used for moving and idle animations
            if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.RightArrow) || Mathf.Abs(xMovement) != 0 || Mathf.Abs(yMovement) != 0) 
            {
                playerAnimation.SetBool("isMoving", true);
            }
            else
            {
                playerAnimation.SetBool("isMoving", false);
            }

            //Code for attack and charge attack.
            if ((Input.GetKeyUp(KeyCode.X) || Input.GetButtonUp("AButton")) && isCharge && attackCooldown < 0)
            {
                //do charged attack animation
                isCharge = false;
                chargeAttack = true;
                chargeTime = 0.0f;
				SoundController.PlaySound(sounds.playerDash);
                if (directionFacing == 1)
                {
                    invincible = true;
                    inCharge = true;
                    chargeCooldown = 0.5f;
                    invincibilityCoolDown = 0.5f;
                    playerAnimation.SetBool("ChargeAttack", true);
                    rBody.AddForce(Vector3.up * 5000);
                }
                if (directionFacing == 2)
                {
                    invincible = true;
                    inCharge = true;
                    chargeCooldown = 0.5f;
                    invincibilityCoolDown = 0.5f;
                    playerAnimation.SetBool("ChargeAttack", true);
                    rBody.AddForce(Vector3.left * 5000);
                }
                if (directionFacing == 3)
                {
                    invincible = true;
                    inCharge = true;
                    chargeCooldown = 0.5f;
                    invincibilityCoolDown = 0.5f;
                    playerAnimation.SetBool("ChargeAttack", true);
                    rBody.AddForce(Vector3.down * 5000);
                }
                if (directionFacing == 4)
                {
                    invincible = true;
                    inCharge = true;
                    chargeCooldown = 0.5f;
                    invincibilityCoolDown = 0.5f;
                    playerAnimation.SetBool("ChargeAttack", true);
                    rBody.AddForce(Vector3.right * 5000);
                }
            }
            else if ((Input.GetKeyUp(KeyCode.X) || Input.GetButtonDown("AButton")) && !isCharge && attackCooldown < 0 && shootCooldown < 0)
            {
                playerAnimation.SetBool("Attack", true);
                attack = true;
                chargeTime = 0;
                attackCooldown = 0.5f;
				SoundController.PlaySound(sounds.playerSword);
            }
            
            else if((Input.GetKeyDown(KeyCode.Z)  || Input.GetButtonDown("BButton")) && attackCooldown < 0 && shootCooldown < 0)
            {
                canShoot = false;
                playerAnimation.SetBool("isShooting", true);
                shootCooldown = 0.2f;
				SoundController.PlaySound(sounds.playerFireball);
            }
            //Letting the animator know that we arent attacking.
            else
            {
                playerAnimation.SetBool("Attack", false);
                playerAnimation.SetBool("ChargeAttack", false); 
                attack = false;
                chargeAttack = false;
                attackCooldown -= Time.deltaTime;
            }


            //Statement used to check if attack has been input, if so we tell the animator, update our global variable and reset the cooldown
            if ((Input.GetKey(KeyCode.X) || triggerMovement > 0) && (attackCooldown <= 0.0f))
            {
                chargeTime += Time.deltaTime;
            }


            //Moving Player in all directions. We update the direction facing, add our force, and let our animator know what direction we are facing. For side walking I flip the image.
            //Directions: Up = 1, Left = 2, Down = 3, Right = 4

            if (!inCharge)
            {
                //Move Player Up
                if (Input.GetKey(KeyCode.UpArrow) || yMovement < 0)
                {
                    rBody.AddForce(Vector3.up * walkSpeed);
                    playerAnimation.SetInteger("DirectionFacing", 1);
                    directionFacing = 1;
                }

                //Move Player Left
                if (Input.GetKey(KeyCode.LeftArrow) || xMovement < 0)
                {
                    if (transform.localScale.x < 0)
                    {
                        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
                    }

                    rBody.AddForce(Vector3.left * walkSpeed);
                    playerAnimation.SetInteger("DirectionFacing", 2);
                    directionFacing = 2;
                }

                //Move Player Down
                if (Input.GetKey(KeyCode.DownArrow) || yMovement > 0)
                {
                    rBody.AddForce(Vector3.down * walkSpeed);
                    playerAnimation.SetInteger("DirectionFacing", 3);
                    directionFacing = 3;
                }

                //Move Player Right
                if (Input.GetKey(KeyCode.RightArrow) || xMovement > 0)
                {
                    if (transform.localScale.x > 0)
                    {
                        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
                    }

                    rBody.AddForce(Vector3.right * walkSpeed);
                    playerAnimation.SetInteger("DirectionFacing", 4);
                    directionFacing = 4;

                }

            }
        }
    }
}
