﻿using UnityEngine;
using System.Collections;

public class EnemyLiving : MonoBehaviour
{

    EnemyMovementController KI;
    Rigidbody2D rgb;

    private float StartPosX;
    private float StartPosY;

    public bool RandomSpawn;

    // Use this for initialization
    void Start ()
    {
        StartPosX = transform.position.x;
        StartPosY = transform.position.y;
        rgb = gameObject.GetComponent<Rigidbody2D>();
        //KI = transform.parent.GetComponent<EnemyMovementController>();   Need for Hirachie
        KI = transform.GetComponentInChildren<EnemyMovementController>();
        Debug.Log(rgb);
	}
	
    void OnTriggerEnter2D (Collider2D other)
    {
        if(other.tag == MyConst.PlayerBody)
        {

            KI.ChangeMe();


        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == MyConst.PlayerBody)
        {
            KI.ChangeMe();
            if (RandomSpawn == false)
            {
                KI.ReSpawn();
                rgb.transform.position = new Vector2(StartPosX, StartPosY);
            }
            else
            {
                KI.RandomSpawn();
                rgb.transform.position = new Vector2(StartPosX, StartPosY);
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate () {
        rgb.velocity = Vector2.zero;
    }
}