using UnityEngine;
using System.Collections;

public class EnemyLiving : MonoBehaviour
{

    EnemyMovementController KI;
    EnemySpawn Spawn;
    Rigidbody2D rgb;



    private float StartPosX;
    private float StartPosY;

    public bool RandomSpawn;

    public bool MultiSpawn;
    private bool FirstSpawn = false;
    public int EnemyCount = 0;

    /*****************************************************************************************************************************************/

    void Start ()
    {
        StartPosX = transform.position.x;
        StartPosY = transform.position.y;
        rgb = gameObject.GetComponent<Rigidbody2D>();
        //KI = transform.parent.GetComponent<EnemyMovementController>();   Need for Hirachie

        KI = transform.GetComponentInChildren<EnemyMovementController>();
        Spawn = transform.GetComponentInChildren<EnemySpawn>();
        
	}

    /*****************************************************************************************************************************************/

    void OnTriggerEnter2D (Collider2D other)
    {
        if(other.tag == MyConst.PlayerBody)
        {
            if (FirstSpawn == false)
            {
                while (EnemyCount > 0)
                {
                    Spawn.SpawnEnemy();
                    EnemyCount -= 1;
                }
                FirstSpawn = true;
            }
            BroadcastMessage("ChangeMe");
        }
    }

    /*****************************************************************************************************************************************/

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == MyConst.PlayerBody)
        {
            BroadcastMessage("ChangeMe");
            if (RandomSpawn == false)
            {
                BroadcastMessage("ReSpawn");
                rgb.transform.position = new Vector2(StartPosX, StartPosY);
            }
            else
            {
                BroadcastMessage("RandomSpawn");
                rgb.transform.position = new Vector2(StartPosX, StartPosY);
            }
        }
    }

    /*****************************************************************************************************************************************/

    void FixedUpdate () {
        rgb.velocity = Vector2.zero;
    }
}