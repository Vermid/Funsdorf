using UnityEngine;
using System.Collections;
using UnityEngine.UI;


/*  ToDo:
*   Stamina  
*   Vecotr3.down
*   Variable try out/ delete
*/
public class PlayerController : MonoBehaviour
{
    //Variablen Für die Gameobjects, Joints und Rigidbodies
    private float startMovementSpeed = 3;
    private float stamina = 10;
    private float runSpeed = 5;
    private int coin = 0;
    private bool running = true;
    private bool canWeSprint = true;
    private float diagonalRunSpeed;
    private float maxStamina;
    private float maxMovementSpeed;
    private float moveHorizontal;
    private float moveVertical;
    private bool moving = true;
    private bool disableMovement = false;
    private bool globalCoolDown = false;

    //Objects
    public Transform playerSpawnPoint;
    private Rigidbody2D rgb2;
    private HealthController healthController;
    private PlayAnimation playAnimation;
    private MoveCamera cam;
    public Text coinText;
    public Text staminaText;
    private SpecialAbilities specialAbilities;

    void Start()
    {
        rgb2 = GetComponent<Rigidbody2D>();
        healthController = GameObject.FindWithTag(MyConst.PlayerBody).GetComponent<HealthController>();
        playAnimation = GetComponentInChildren<PlayAnimation>();
        cam = GetComponentInChildren<MoveCamera>();//  GameObject.FindWithTag("MainCamera").GetComponent<MoveCamera>();
        specialAbilities = GetComponent<SpecialAbilities>();
        SetStartVariables();
    }

    void SetStartVariables()
    {
        maxMovementSpeed = startMovementSpeed;
        diagonalRunSpeed = runSpeed - 1.5F;
        maxStamina = stamina;
    }

    void FixedUpdate()
    {
        PlayerMovement();
        UsePotion();
        PlayerAttack();
        cam.Move_Camera();
        GuiText();
    }

    void GuiText()
    {
        staminaText.text = "Stamina " + stamina.ToString();
        coinText.text = "Coin " + coin.ToString();
}
    void UsePotion()
    {
        //insert potion and actionButton here
        if (Input.GetButton("Potion"))
        {
            if (!globalCoolDown)
            {
                bool healthfilled = false;
                healthfilled =  healthController.AddHealth();
                if (healthfilled)
                {
                    globalCoolDown = !globalCoolDown;
                    Invoke(MyConst.Cooldown, 10);
                }
            }
        }
    }


    void PlayerAttack()
    {
        //Insert Attack Prime,Special 1 and Special 2
        if (Input.GetButton("Attack"))
            playAnimation.AttackNow();

        //Swing melee weapon and shoot with bow or Staff
        if (Input.GetButton("Special1"))
            specialAbilities.Dash();
     
        //if (Input.GetButton("Special2"))
    }


    void PlayerMovement()
    {
        ////MOVEMENT////
        //Positive oder Negative Axis wird gespeichert von dem Horizontal input //GetAxisRaw -1 or 1
        moveHorizontal = Input.GetAxisRaw("Horizontal");
        //Positive oder Negative Axis wird gespeichert von dem Vertical input //GetAxisRaw -1 or 1
        moveVertical = Input.GetAxisRaw("Vertical");

        #region Anim DIRECTION
        if (moveHorizontal < 0)
            playAnimation.Left();
        if (moveHorizontal > 0)
            playAnimation.Right();
        if (moveVertical > 0)
            playAnimation.Up();
        if (moveVertical < 0)
            playAnimation.Down();

        if (moveHorizontal < 0 && moveVertical < 0)
            playAnimation.RightUp();

        if (moveHorizontal < 0 && moveVertical > 0)
            playAnimation.LeftUp();

        if (moveHorizontal > 0 && moveVertical < 0)
            playAnimation.RightDown();

        if (moveHorizontal > 0 && moveVertical > 0)
            playAnimation.LeftDown();

        #endregion

        if (moveHorizontal != 0 || moveVertical != 0)
        {
            moving = true;
        }
        else
            moving = !moving;

        if (!moving)
        {
            #region Anim WASD DIRECTION

            float playerX = gameObject.transform.position.x;
            float playerY = gameObject.transform.position.y;
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;

            //need this for Fire Rain
            //gameObject.transform.position = mousePos;
            //targetRotation = Quaternion.LookRotation(mousePos);
            // transform.eulerAngles = Vector3.up * Mathf.MoveTowardsAngle(transform.eulerAngles.y, targetRotation.eulerAngles.y, rotationSpeed * Time.deltaTime);

            //Debug.DrawRay(transform.position, Vector3.forward, Color.red);

            if (mousePos.x < (playerX + 0.53F) && mousePos.x > (playerX - 0.53F) && mousePos.y < playerY)
                playAnimation.Down();

            if (mousePos.x < (playerX + 0.53F) && mousePos.x > (playerX - 0.53F) && mousePos.y > playerY)
                playAnimation.Up();

            if (mousePos.y < (playerY + 0.53F) && mousePos.y > (playerY - 0.49F) && mousePos.x < playerX)
                playAnimation.Left();

            if (mousePos.y < (playerY + 0.53F) && mousePos.y > (playerY - 0.49F) && mousePos.x > playerX)
                playAnimation.Right();

            if (mousePos.x > (playerX + 0.54F) && mousePos.y > (playerY + 0.54F))
                playAnimation.RightUp();

            if (mousePos.x > (playerX + 0.54F) && mousePos.y < (playerY - 0.54F))
                playAnimation.RightDown();

            if (mousePos.x < (playerX - 0.54F) && mousePos.y > (playerY + 0.54F))
                playAnimation.LeftUp();

            if (mousePos.x < (playerX - 0.54F) && mousePos.y < (playerY - 0.54F))
                playAnimation.LeftDown();
            #endregion
        }

        PlayerRun(disableMovement);
    }

    void PlayerRun(bool disableMove)
    {
        if (Input.GetButton("Run") && canWeSprint)
        {
            if (moveHorizontal != 0 && moveVertical != 0)
                startMovementSpeed = diagonalRunSpeed;

            if (moveHorizontal != 0 || moveVertical != 0)
                startMovementSpeed = runSpeed;

            stamina -= Time.deltaTime;
            running = !running; //running = true;

            if (stamina < 1)
                canWeSprint = false;
        }
        else
        {
            running = !running; //running = false;
            startMovementSpeed = maxMovementSpeed;
        }

        if (!running)
        {
            if (stamina >= 0 && stamina <= maxStamina)
                stamina += Time.deltaTime;

            if (stamina > 5)
                canWeSprint = true;

            if (stamina > maxStamina)
            {
                stamina = Mathf.RoundToInt(stamina);
                stamina = maxStamina;
            }
        }
        
        //Velocity zu Rigidbody vom Spieler 
        if (!disableMove)
            rgb2.velocity = new Vector2(moveHorizontal * startMovementSpeed, moveVertical * startMovementSpeed);
        else
        {
            if (moveHorizontal != 0)
                rgb2.velocity = new Vector2(moveHorizontal * startMovementSpeed, 0);
            else
                rgb2.velocity = new Vector2(0, moveVertical * startMovementSpeed);

            if (moveVertical != 0)
                rgb2.velocity = new Vector2(0, moveVertical * startMovementSpeed);
            else
                rgb2.velocity = new Vector2(moveHorizontal * startMovementSpeed, 0);
        }

        /* Ice World  Player sclide
            if (moveHorizontal != 0)
                rgb2.velocity = new Vector2(moveHorizontal * startMovementSpeed, 0);
            if (moveVertical != 0)
                rgb2.velocity = new Vector2(0, moveVertical * startMovementSpeed);
            else
            Invoke(MyConst.FreezeMovement,2);
         */

    }

    void FreezeMovement()
    {
        rgb2.velocity = new Vector2(0, 0);
    }

    public void SlowMovement(float speed)
    {
        startMovementSpeed = speed;
    }

    public void SetNormalMovement()
    {
        startMovementSpeed = maxMovementSpeed;
    }

    public void PlayerSpawn()
    {
        transform.position = playerSpawnPoint.position;
    }

    public void StaminaControl(float stamina)
    {
        if (stamina > 0)
            maxStamina += stamina;
        if (stamina < 0)
            maxStamina -= stamina;
    }

    public void SetCoin(int coin)
    {
       this.coin += coin;
    }

    public int GetCoin( )
    {
        return coin ;
    }

    void Cooldown()
    {
        globalCoolDown = !globalCoolDown;
    }
}