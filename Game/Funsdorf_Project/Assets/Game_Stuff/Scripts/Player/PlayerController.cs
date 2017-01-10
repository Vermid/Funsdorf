using UnityEngine;
using System.Collections;

/*  ToDo:
*   Stamina  
*   Vecotr3.down
*   Variable try out/ delete
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
    public int camDistance = 3;
    private MoveCamera cam;
    public Vector3 camPos;
    public Vector3 playerPos;

    public float rotationSpeed = 450;
    private bool moving = true;
    public int coin = 0;

    void Start()
    {
        rgb2 = GetComponent<Rigidbody2D>();
        healthController = GameObject.FindWithTag(MyConst.PlayerBody).GetComponent<HealthController>();
        playAnimation = GetComponentInChildren<PlayAnimation>();
        cam = GetComponentInChildren<MoveCamera>();//  GameObject.FindWithTag("MainCamera").GetComponent<MoveCamera>();
        SetStartVariables();
    }

    void SetStartVariables()
    {
        maxMovementSpeed = startMovementSpeed;
        diagonalSpeed = maxMovementSpeed - 0.5F;
        diagonalRunSpeed = runSpeed - 1.5F;
        maxStamina = stamina;
    }

    void FixedUpdate()
    {
        PlayerMovement();
        UsePotion();
        PlayerAttack();
        cam.Move_Camera();
    }


    //public void Move_Camera()
    //{
    //    cam.transform.position += new Vector3(Input.GetAxisRaw("Mouse X") * Time.deltaTime, Input.GetAxisRaw("Mouse Y") * Time.deltaTime, 0f);
    //    cam.transform.position = new Vector3(
    //        Mathf.Clamp(cam.transform.position.x, transform.position.x + clampXLeft, transform.position.x + clampXRight), 
    //        Mathf.Clamp(cam.transform.position.y, transform.position.y + clampYDown, transform.position.y + clampYUp),
    //        Mathf.Clamp(cam.transform.position.z, transform.position.z + clampZIn, transform.position.z + clampZOut));
    //    //maybe you have to change clampZIn with clampZOut i made it in 2D
    //    //playerPos.y = Mathf.Clamp(cam.transform.position.y, transform.position.y + clampYDown, transform.position.y + clampYUp);
    //    //playerPos.x = Mathf.Clamp(cam.transform.position.x, transform.position.x + clampXLeft, transform.position.x + clampXRight);
    //    //playerPos.z = -10;
    //    //cam.transform.position = playerPos;
    //}


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
        //if (moveHorizontal < 0)
        //    playAnimation.Left();
        //if (moveHorizontal > 0)
        //    playAnimation.Right();
        //if (moveVertical > 0)
        //    playAnimation.Up();
        //if (moveVertical < 0)
        //    playAnimation.Down();

        //if (moveHorizontal < 0 && moveVertical < 0)
        //    playAnimation.RightUp();

        //if (moveHorizontal < 0 && moveVertical > 0)
        //    playAnimation.LeftUp();

        //if (moveHorizontal > 0 && moveVertical < 0)
        //    playAnimation.RightDown();

        //if (moveHorizontal > 0 && moveVertical > 0)
        //    playAnimation.LeftDown();

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

            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;

            //need this for Fire Rain
            //gameObject.transform.position = mousePos;
            //targetRotation = Quaternion.LookRotation(mousePos);
            // transform.eulerAngles = Vector3.up * Mathf.MoveTowardsAngle(transform.eulerAngles.y, targetRotation.eulerAngles.y, rotationSpeed * Time.deltaTime);

            //Debug.DrawRay(transform.position, Vector3.forward, Color.red);

            if (mousePos.x < (gameObject.transform.position.x + 0.53F) && mousePos.x > (gameObject.transform.position.x - 0.53F) && mousePos.y < gameObject.transform.position.y)
                playAnimation.Down();

            if (mousePos.x < (gameObject.transform.position.x + 0.53F) && mousePos.x > (gameObject.transform.position.x - 0.53F) && mousePos.y > gameObject.transform.position.y)
                playAnimation.Up();

            if (mousePos.y < (gameObject.transform.position.y + 0.53F) && mousePos.y > (gameObject.transform.position.y - 0.49F) && mousePos.x < gameObject.transform.position.x)
                playAnimation.Left();

            if (mousePos.y < (gameObject.transform.position.y + 0.53F) && mousePos.y > (gameObject.transform.position.y - 0.49F) && mousePos.x > gameObject.transform.position.x)
                playAnimation.Right();

            if (mousePos.x > (gameObject.transform.position.x + 0.54F) && mousePos.y > (gameObject.transform.position.y + 0.54F))
                playAnimation.RightUp();

            if (mousePos.x > (gameObject.transform.position.x + 0.54F) && mousePos.y < (gameObject.transform.position.y - 0.54F))
                playAnimation.RightDown();

            if (mousePos.x < (gameObject.transform.position.x - 0.54F) && mousePos.y > (gameObject.transform.position.y + 0.54F))
                playAnimation.LeftUp();

            if (mousePos.x < (gameObject.transform.position.x - 0.54F) && mousePos.y < (gameObject.transform.position.y - 0.54F))
                playAnimation.LeftDown();
            #endregion
        }

        PlayerRun(disableMovement);
    }

    void PlayerRun(bool disableMove)
    {
        if (moveHorizontal != 0 && moveVertical != 0)
        {
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

}