using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct pleaseJustWork
{
    public GameObject unit;
    public float unitSpeed;
}
public class TurnOrder : MonoBehaviour {
    public GameObject unitSpawner;
    public SpawnUnits spawnRef;
    public GameObject combatManager;
    public CombatManager combatRef;
    public GameObject[] turnOrder;
    public GameObject[] fastestOrder;
    public GameObject[] unitsOnly;
    public GameObject[] placeholder;
    public GameObject[] test;
    public GameObject unit;
    public GameObject unitPlaceholder;
    public GameObject fastestUnit;
    public UnitInfo unitRef;
    public int width, height;
    public pleaseJustWork[] kludgetest;
    public List<GameObject> orderList;
    public List<pleaseJustWork> kludgeList;
    public List<float> newSortTest;
    public bool sortWait;
    public bool oneAndDone;
	// Use this for initialization
	void Start () {
        oneAndDone = false;
        fastestOrder = new GameObject[spawnRef.allArray.Length];
        //unitsOnly = new GameObject[spawnRef.allArray.Length];
        //unitSpawner = GameObject.Find("UnitSpawner");
        //spawnRef = unitSpawner.GetComponent<SpawnUnits>();
	}
    #region Ally + Enemy Turns
    //These functions are to be used to demonstrate turn-based combat wherein allies and enemies take turns attacking a la Fire Emblem
    void CreateAllyArray()
    {

    }
    void CreateEnemyArray()
    {

    }
    #endregion
    #region Individual Turns
    //These functions are to be used to demonstrate turn-based combat wherein turn order is decided by speed a la Final Fantasy Tactics
    public void CreateTurnArray()
    {
        kludgetest = new pleaseJustWork[spawnRef.allArray.Length];
        kludgeList = new List<pleaseJustWork>();
        orderList = new List<GameObject>();
        newSortTest = new List<float>();
        turnOrder = GameObject.FindGameObjectsWithTag("ActiveUnit");
        foreach(GameObject unit in turnOrder)
        {
            unitRef = unit.GetComponent<UnitInfo>();
            //Debug.Log(unitRef.GiveSpeed());
                newSortTest.Add(unitRef.speed);
        }
        orderList = turnOrder.ToList();
        //List<GameObject> SortedList = orderList.OrderByDescending(o => o.GetComponent<UnitInfo>().Speed).ToList();
        //orderList.Sort((x, y) => x.GetComponent<UnitInfo>().Speed.CompareTo(y.GetComponent<UnitInfo>().Speed));
        //orderList.Sort(SpeedSort);
        //orderList.Sort(SpeedSort);
    }
    public void StartBattle()
    {
        combatRef.moveOrder = turnOrder;
        combatRef.BattlePrep();
    }
    #endregion
    private int SpeedSort(GameObject u1, GameObject u2)
    {
        return u1.GetComponent<UnitInfo>().Speed.CompareTo(u2.GetComponent<UnitInfo>().Speed);
        /*if(u1.GetComponent<UnitInfo>().Speed < u2.GetComponent<UnitInfo>().Speed)
        {
            return -1;
        }
        else if(u1.GetComponent<UnitInfo>().Speed > u2.GetComponent<UnitInfo>().Speed)
        {
            return 1;
        }
        return 0;
        */
    }
    // Update is called once per frame
    void Update () {
        if(turnOrder[0].GetComponent<UnitInfo>().Speed == 0)
        {
            sortWait = true;
        }
        else
        {
            sortWait = false;
        }
        if(!sortWait && !oneAndDone)
        {
            orderList.Sort(SpeedSort);
            orderList.Reverse();
            turnOrder = orderList.ToArray();
            sortWait = true;
            oneAndDone = true;
            StartBattle();
        }
    }
}
