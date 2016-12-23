﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour {

    public GameObject EnemyType;
    private EnemyMovementController movementScript;

    private Vector2 minWalkPoint;
    private Vector2 maxWalkPoint;

    private GameObject Parent;

    // Use this for initialization
    void Start () {

       BoxCollider2D WalkZone = GetComponent<BoxCollider2D>();

        minWalkPoint = WalkZone.bounds.min;
        maxWalkPoint = WalkZone.bounds.max;

        Parent = GameObject.FindGameObjectWithTag("WalkArea");

        //GameObject Child = Instantiate(EnemyType, new Vector2(Random.Range(maxWalkPoint.x, minWalkPoint.x), Random.Range(maxWalkPoint.y, minWalkPoint.y)), Quaternion.identity);

    }
	
	// Update is called once per frame
	void Update () {
		
	}

   public void SpawnEnemy()
    {
        GameObject Child = Instantiate(EnemyType, new Vector2(Random.Range(maxWalkPoint.x, minWalkPoint.x), Random.Range(maxWalkPoint.y, minWalkPoint.y)), Quaternion.identity);
        Child.transform.parent = Parent.transform;/*parent = this.transform.parent;*/ //Hier script mit WalkArea Zufügen
        //movementScript = Child.GetComponent<EnemyMovementController>();
        //movementScript.walkZone = gameObject.GetComponentInParent<Collider2D>();
    }
}
