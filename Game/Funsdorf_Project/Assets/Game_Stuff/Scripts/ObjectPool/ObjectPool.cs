using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    //[SerializeField]
    //private GameObject coin;
    //[SerializeField]
    //private GameObject healthOrb;
    //[SerializeField]
    //private GameObject enemy;

    //public static Dictionary<GameObject, List<GameObject>> objectDictionary;
    //public static GameObject currentCoin;
    //public static ObjectPool current;

    //public List<GameObject> coinList = new List<GameObject>();
    //public List<GameObject> healthOrbList = new List<GameObject>();
    //public List<GameObject> enemyList = new List<GameObject>();

    //private GameObject parent;
    //public int maxCoins;
    //public int maxHealthOrbs;
    //public int maxEnemys;

    //private int countEnemys = 0;
    //private int countHealthOrbs = 0;

    //public bool willGrowCoins = true;
    //public bool willGrowHealthOrbs = true;

    //void Awake()
    //{
    //    current = this;
    //}

    //void Start()
    //{
    //    parent = GameObject.FindGameObjectWithTag(MyConst.Clones);
    //    for (int i = 0; i < maxCoins -1 ; i++)
    //    {
    //        //if (countHealthOrbs < maxHealthOrbs)
    //        //{
    //        //    obj = (GameObject)Instantiate(healthOrb, parent.transform);
    //        //    obj.SetActive(false);
    //        //    healthOrbList.Add(obj);
    //        //    countHealthOrbs++;
    //        //}

    //        GameObject obj = (GameObject)Instantiate(coin);
    //        obj.SetActive(false);
    //        coinList.Add(obj);
    //    }
    //}

    //public GameObject GetPooledCoin()
    //{
    //    parent = GameObject.FindGameObjectWithTag(MyConst.Clones);
    //    for (int i = 0; i < coinList.Count; i++)
    //    {
    //        if (coinList[i].activeInHierarchy)
    //        {
    //            return coinList[i];
    //        }
    //    }
    //    if (willGrowCoins)
    //    {
    //        GameObject obj = (GameObject)Instantiate(coin);
    //        obj.SetActive(false);
    //        coinList.Add(obj);
    //        return obj;
    //    }
    //    return null;
    //}

    //public GameObject GetPooledHealthOrb()
    //{
    //    parent = GameObject.FindGameObjectWithTag(MyConst.Clones);

    //    for (int i = 0; i < healthOrbList.Count; i++)
    //    {
    //        if (!healthOrbList[i].activeInHierarchy)
    //        {
    //            return healthOrbList[i];
    //        }
    //    }
    //    if (willGrowHealthOrbs)
    //    {
    //        GameObject obj = (GameObject)Instantiate(healthOrb, parent.transform);
    //        obj.SetActive(false);
    //        healthOrbList.Add(obj);
    //        countHealthOrbs++;
    //        return obj;
    //    }
    //    return null;
    //}
}
