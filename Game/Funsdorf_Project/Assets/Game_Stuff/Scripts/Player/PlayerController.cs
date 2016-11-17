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
    public bool running = false;
    public bool canWeSprint = true;

    private float diagonalRunSpeed;
    private float maxStamina;
    private float maxMovementSpeed;
    private float diagonalSpeed;
    public float moveHorizontal;
    public float moveVertical;

    private GameObject player;
    private Rigidbody2D rgb2;
    private Quaternion NewRot;


    // Use this for initialization
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
        // diagonalRunSpeed = (runSpeed / 4) + runSpeed / 2; why this?
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
        //MAUSVERFOLGUNG UND ROTATION//

        #region QUARTER DIRECTION
        if (moveHorizontal < 0) ;
        //setAnim   left
        if (moveHorizontal > 0) ;
        //setAnim   right
        if (moveVertical < 0) ;
        //setAnim   up
        if (moveVertical > 0) ;
        //setAnim   down   
        #endregion

        if (moveHorizontal < 0 && moveVertical < 0) ;
        //setAnim RightUp
        if (moveHorizontal < 0 && moveVertical > 0) ;
        //setAnim LeftUp
        if (moveHorizontal > 0 && moveVertical < 0) ;
        //setAnim RightDown
        if (moveHorizontal > 0 && moveVertical > 0) ;
        //setAnim LeftDown


        //die rotation vom Spieler wird auf NewRot Gesetzt;
        player.transform.rotation = NewRot;
        //Die EulerischenAngles werden auch richtig gesetzt sonst würde die Rotation ins 3D gehen
        player.transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z);

        PlayerRun();
    }

    void PlayerRun()
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
        {
            running = false;
        }

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
        rgb2.velocity = new Vector2(moveHorizontal * startMovementSpeed, rgb2.velocity.y);
        rgb2.velocity = new Vector2(rgb2.velocity.x, moveVertical * startMovementSpeed);
    }

    public void IncreaseStamina(float sta)
    {
        maxStamina += sta;
    }

    public void DecreaseStamina(float sta)
    {
        maxStamina -= sta;
    }
}