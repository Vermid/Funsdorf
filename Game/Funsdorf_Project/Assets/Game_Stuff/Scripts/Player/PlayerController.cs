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

    private GameObject player;
    private Rigidbody2D rgb2;



    void Start()
    {
        player = gameObject;
        rgb2 = player.GetComponent<Rigidbody2D>();
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

        if (moveHorizontal < 0)
            deleteMeWhenAnimIsSet = 1; //setAnim   left
        if (moveHorizontal > 0) 
        deleteMeWhenAnimIsSet = 1; //setAnim   right
        if (moveVertical < 0) 
        deleteMeWhenAnimIsSet = 1; //setAnim   up
        if (moveVertical > 0) 
        deleteMeWhenAnimIsSet = 1;//setAnim   down   

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

    public void StaminaControl(float sta)
    {
        if (sta > 0)
            maxStamina += sta;
        if (sta < 0)
            maxStamina -= sta;
    }
} 