using UnityEngine;
using System.Collections;


/*
* log //184
*/
public class EnemyMovementController : MonoBehaviour {

    public float moveSpeed;
    private Rigidbody2D myRigidbody;
    private Animator anim;
    private bool isMoving = false;

    private bool bewegtsich = false;

    public float timeBetweenMove = 30;
    private float timeBetweenMoveCounter = 30;
    public float timeToMove;
    private float timeToMoveCounter;

    GameObject walkarea2;

    public Collider2D walkZone;
    private Vector2 minWalkPoint;
    private Vector2 maxWalkPoint;
    private bool hasWalkZone;

    private bool Living;

    private bool Tracing;   //Verfolgen und angriff noch nicht fertig

    private float StartPosX;
    private float StartPosY;

    //public GameObject EnemyType;    //Für übersicht in EnemyLiving verschieben

    //public bool MultiSpawn; //Multible spawn, nicht fertig
    //private bool FirstSpawn = false;
    //public int EnemyCount = 0;

    void Start ()
    {
        StartPosX = transform.position.x;
        StartPosY = transform.position.y;
        //walkZone = GetComponent<Collider2D>();
        //Collider2D walkZone = gameObject.AddComponent<Collider2D>();

        walkarea2 = this.transform.parent.gameObject;
        walkZone = walkarea2.GetComponent<Collider2D>();
        //walkarea2 = GameObject.FindGameObjectWithTag("WalkArea"); Für Zombie attacke
        //walkZone = walkarea2.GetComponentInParent<Collider2D>();

        if (walkZone != null)
        {
            minWalkPoint = walkZone.bounds.min;
            maxWalkPoint = walkZone.bounds.max;
            hasWalkZone = true;
            //if (!FirstSpawn)
            //{
            //    SpawnEnemy();
            //}
        }

        myRigidbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        timeBetweenMoveCounter = timeBetweenMove;
        timeToMoveCounter = timeToMove;

        if (timeToMoveCounter < 0)
        {
            timeBetweenMoveCounter = timeBetweenMove;
        }


    }

/*****************************************************************************************************************************************/

    void Update () {

        //if (EnemyLivingArea && (gameObject.name == "Player"))
        //{
        //    Debug.Log("hallo");
        //}
        if (Living == true && Tracing == false)
        {
            WalkBack();
            timeBetweenMoveCounter -= Time.deltaTime;
            bewegtsich = false;

            bleibstehn();
        }
        else if (Tracing == true)
        {

        }
        else
        {
            myRigidbody.velocity = Vector2.zero;
        }
    }

/*****************************************************************************************************************************************/

    void bleibstehn()
    {
        int x = 10;
        int y = -10;
        int z = 1, z2 = 1;
        z = Random.Range(-1, 1);
        z2 = Random.Range(-1, 1);
        x = Random.Range(0, 10);
        y = Random.Range(0, 10);
        if (z == 0)
        {
            z = 1;
        }
        if (z2 == 0)
        {
            z2 = 1;
        }
        if (!bewegtsich)
        {
           
            bewegtsich = true;
            if (timeBetweenMoveCounter < 0)
            {
                Invoke(MyConst.StopME, 5);
                timeBetweenMoveCounter = 8;
                timeToMoveCounter = timeToMove;
                if (x > 5 && y > 5)
                {
                    myRigidbody.velocity = new Vector2(z * moveSpeed, z2 * moveSpeed) / 2;
                }
                else
                { 
                    if (x > 5)
                        myRigidbody.velocity = new Vector2(z * moveSpeed, 0) / 2;
                    else
                        myRigidbody.velocity = new Vector2(0, z * moveSpeed) / 2;
                }
            }
        }

        if (myRigidbody.velocity.y != 0 || myRigidbody.velocity.x != 0)
        {
            isMoving = true;
        }
        else
            isMoving = false;

        anim.SetBool("IsMoving", isMoving);
        if(isMoving)
        anim.SetFloat("YSpeed", myRigidbody.velocity.y);
        else
            anim.SetFloat("YSpeed", -1);

        anim.SetFloat("XSpeed", myRigidbody.velocity.x);
    }

    /*****************************************************************************************************************************************/

    public void StopME()
    {
        myRigidbody.velocity = Vector2.zero;
    }

/*****************************************************************************************************************************************/

    void WalkBack()
    {
        if (hasWalkZone && transform.position.y > maxWalkPoint.y)
            myRigidbody.velocity = new Vector2(0, -1 * moveSpeed) / 2;
        else if (hasWalkZone && transform.position.x > maxWalkPoint.x)
            myRigidbody.velocity = new Vector2(-1 * moveSpeed, 0) / 2;
        else if (hasWalkZone && transform.position.y < minWalkPoint.y)
            myRigidbody.velocity = new Vector2(0, 1 * moveSpeed) / 2;
        else if (hasWalkZone && transform.position.x < minWalkPoint.x)
            myRigidbody.velocity = new Vector2(1 * moveSpeed, 0) / 2;
    }

    /*****************************************************************************************************************************************/

    public void ChangeMe()
    {
        Living = !Living;
    }

    /*****************************************************************************************************************************************/

    public void InSight()
    {
        Tracing = !Tracing;
    }

    /*****************************************************************************************************************************************/

    public void ReSpawn()
    {
        myRigidbody.transform.position = new Vector2(StartPosX, StartPosY);
    }

    /*****************************************************************************************************************************************/

    public void RandomSpawn()
    {
        if (hasWalkZone)
        {
            myRigidbody.transform.position = new Vector2(Random.Range(maxWalkPoint.x, minWalkPoint.x), Random.Range(maxWalkPoint.y, minWalkPoint.y));
        }
    }

    /*****************************************************************************************************************************************/

    //public void SpawnEnemy()
    //{
    //    //myRigidbody.transform.position = new Vector2(Random.Range(maxWalkPoint.x, minWalkPoint.x), Random.Range(maxWalkPoint.y, minWalkPoint.y));
    //    //GameObject Child = Instantiate(EnemyType, new Vector2(Random.Range(maxWalkPoint.x, minWalkPoint.x), Random.Range(maxWalkPoint.y, minWalkPoint.y)), Quaternion.identity);

    ////Child.transform.parent =  this.transform.parent;
    //    Debug.Log("funzt");
    //}
}