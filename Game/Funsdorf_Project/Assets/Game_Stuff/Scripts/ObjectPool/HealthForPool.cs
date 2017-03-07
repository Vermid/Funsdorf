using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthForPool : MonoBehaviour
{
    //[SerializeField]
    //private int health = 5;

    //private ObjectPool objectPool;
    //private int maxHealth;
    //// Use this for initialization
    //void Start()
    //{
    //    maxHealth = health;
    //    objectPool = GetComponent<ObjectPool>();

    //}

    //public void Damage(int dmg)
    //{
    //    health -= dmg;
    //    if (health <= 0)
    //    {
    //        //  CoinScriptNew.current.Spawn();
    //        //kill me
    //        InvokeRepeating("SpawnObjects", 2F, 0.5F);
    //    }
    //}

    //void SpawnObjects()
    //{
    //    GameObject obj = ObjectPool.current.GetPooledCoin();
    //    obj.transform.position = transform.position;
    //    obj.transform.rotation = transform.rotation;
    //    obj.SetActive(true);
    //}
}
