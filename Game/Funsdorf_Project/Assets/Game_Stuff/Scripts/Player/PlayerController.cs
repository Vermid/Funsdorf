using UnityEngine;
using System.Collections;

/*  ToDo:
*   Stamina  
*   Vecotr3.down
*/
public class PlayerController : MonoBehaviour
{
    //Variablen Für die Gameobjects, Joints und Rigidbodies
    public float startMovementSpeed = 3;
    public float stamina = 10;
    public float runSpeed = 5;

    private bool running = false;
    private bool canWeSprint = true;
    private float diagonalRunSpeed;
    private float maxStamina;
    private float maxMovementSpeed;
    private float diagonalSpeed;
    private float moveHorizontal;
    private float moveVertical;
    private bool disableMovement = false;
    private bool globalCoolDown = false;
    //Objects
    public Transform playerSpawnPoint;
    private Rigidbody2D rgb2;
    private HealthController healthController;
    private PlayAnimation playAnimation;

    private Animator anim;

    public float rotationSpeed = 450;
    private bool moving;

    void Start()
    {
        rgb2 = this.GetComponent<Rigidbody2D>();
        healthController = GameObject.FindWithTag(MyConst.PlayerBody).GetComponent<HealthController>();
        playAnimation = GetComponentInChildren<PlayAnimation>();
        anim = GetComponent<Animator>();

        SetStartVariables();
    }

    void SetStartVariables()
    {
        maxMovementSpeed = startMovementSpeed;
        diagonalSpeed = maxMovementSpeed - 1.5F;
        diagonalRunSpeed = runSpeed - 1.5F;
        maxStamina = stamina;
    }

    void FixedUpdate()
    {
        PlayerMovement();
        PlayerAction();
        PlayerAttack();
    }
    
    void PlayerAction()
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
        //if (Input.GetButton("Action"))
    }

    void Cooldown()
    {
        globalCoolDown = !globalCoolDown;
    }
    void PlayerAttack()
    {
        //Insert Attack Prime,Special 1 and Special 2
        //if (Input.GetButton("Attack"))
        //Swing melee weapon and shot woth bow or Staff
        //if (Input.GetButton("Special1"))
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
        int deleteMeWhenAnimIsSet = 0;
        if (deleteMeWhenAnimIsSet == 0)
            deleteMeWhenAnimIsSet = 2;

        //if (moveHorizontal < 0)
        //    anim.SetTrigger("Left");
        //if (moveHorizontal > 0)
        //    anim.SetTrigger("Right");
        //if (moveVertical > 0)
        //    anim.SetTrigger("Up");
        //if (moveVertical < 0)
        //    anim.SetTrigger("Down");

        if (moveHorizontal < 0 && moveVertical < 0) 
        deleteMeWhenAnimIsSet = 1; //setAnim RightUp
        if (moveHorizontal < 0 && moveVertical > 0) 
        deleteMeWhenAnimIsSet = 1;//setAnim LeftUp
        if (moveHorizontal > 0 && moveVertical < 0) 
        deleteMeWhenAnimIsSet = 1;//setAnim RightDown
        if (moveHorizontal > 0 && moveVertical > 0) 
        deleteMeWhenAnimIsSet = 1;//setAnim LeftDown
        #endregion

        PlayerRun(disableMovement);
    }

    void PlayerRun(bool disableMove)
    {
        if (moveHorizontal != 0 && moveVertical != 0)
        {
            moving = true;
            if (Input.GetButton("Run"))
                startMovementSpeed = diagonalRunSpeed;
            else
                startMovementSpeed = diagonalSpeed;
        }
        else if (Input.GetButton("Run"))
            startMovementSpeed = runSpeed;
        else
            startMovementSpeed = maxMovementSpeed;

        if (Input.GetButton("Run") && stamina > 1)
        {
            if (canWeSprint)
            {
                stamina -= Time.deltaTime;
                running = true;

                if (stamina < 1)
                    canWeSprint = false;
            }
        }
        else
            running = false;

        if (running == false)
        {
            if (stamina >= 0 && stamina <= maxStamina)
                stamina += Time.deltaTime;

            if (stamina > 3)
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
        if (moveHorizontal == 0 && moveVertical == 0)
            moving = !moving;

            if (!moving)
        {
            float x = gameObject.transform.position.x;
            float y = gameObject.transform.position.y;
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;

            //need this for Fire Rain
            //gameObject.transform.position = mousePos;

            //targetRotation = Quaternion.LookRotation(mousePos);
            // transform.eulerAngles = Vector3.up * Mathf.MoveTowardsAngle(transform.eulerAngles.y, targetRotation.eulerAngles.y, rotationSpeed * Time.deltaTime);

            #region Anim WASD DIRECTION

            if (mousePos.x > (gameObject.transform.position.y + 7.7F) && mousePos.x < (gameObject.transform.position.y + 9F) && mousePos.y > gameObject.transform.position.y)
            {
                Debug.DrawRay(transform.position, Vector2.up, Color.green);
                playAnimation.Up();//
            }

            if (mousePos.x > (gameObject.transform.position.y + 7.7F) && mousePos.x < (gameObject.transform.position.y + 9F) && mousePos.y < gameObject.transform.position.y)
            {
                Debug.DrawRay(transform.position, Vector2.down, Color.blue);
                playAnimation.Down();// anim.SetTrigger("Right");
            }
            if (mousePos.y > (gameObject.transform.position.x -9F)&& mousePos.y < (gameObject.transform.position.x - 7.7F) && mousePos.x < gameObject.transform.position.x)
            {
                Debug.DrawRay(transform.position, Vector2.left, Color.red);
                playAnimation.Left();// anim.SetTrigger("Up");
            }

            if (mousePos.y > (gameObject.transform.position.x - 9F) && mousePos.y < (gameObject.transform.position.x - 7.7F) && mousePos.x > gameObject.transform.position.x)
            {
                Debug.DrawRay(transform.position, Vector2.right, Color.black);
                playAnimation.Right();// anim.SetTrigger("Down");
            }

            //if (mousePos.x < (x + 1.5F) && mousePos.y < (y - 1.5F))
            //    anim.SetTrigger("LeftDown");
            //if (mousePos.x < (x + 1.5F) && mousePos.y > (y + 1.5F))
            //    anim.SetTrigger("LeftUp");
            //if (mousePos.x > (x - 1.5F) && mousePos.y < (y - 1.5F))
            //    anim.SetTrigger("RightDown");
            //if (mousePos.x > (x - 1.5F) && mousePos.y > (y + 1.5F))
            //    anim.SetTrigger("RightUp");
            #endregion
        }

    }

    private void FreezeMovement()
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

    public void StaminaControl(float sta)
    {
        if (sta > 0)
            maxStamina += sta;
        if (sta < 0)
            maxStamina -= sta;
    }
} 