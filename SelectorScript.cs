using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectorScript : MonoBehaviour {
    public enum combatChoice
    {
        Base, Attack, Spell, Item, Status, Solo
    }
    combatChoice currentMenuOption;
    public GameObject unitSpawner;
    public SpawnUnits spawnRef;
    public GameObject[] currentSide;
    public GameObject combatMenuManager;
    public CombatChoiceManager combatMenuRef;
    public GameObject combatManager;
    public CombatManager combatManagerRef;
    public UnitInfo unit;
    public GameObject tileHolder;
    public TileInfo tileInfo;
    public TileProperties tileRef;
    public int rowRef, columnRef, unitRef;
    // Use this for initialization
    void Start () {
        unitRef = 0;
        tileHolder = GameObject.Find("TileHolder");
        tileInfo = tileHolder.GetComponent<TileInfo>();
        currentSide = tileInfo.tileArrayLeft;
        unitSpawner = GameObject.Find("UnitSpawner");
        spawnRef = unitSpawner.GetComponent<SpawnUnits>();
        combatManager = GameObject.Find("CombatCoordinator");
        combatManagerRef = combatManager.GetComponent<CombatManager>();
        combatMenuManager = GameObject.FindGameObjectWithTag("MainBattleUI");
        combatMenuRef = combatMenuManager.GetComponent<CombatChoiceManager>();
        combatMenuManager.gameObject.SetActive(false);
        for(int i = 0; i < currentSide.Length; i++)
        {
            tileRef = currentSide[i].GetComponent<TileProperties>();
            if(tileRef.CurrentUnit == combatManagerRef.attacker)
            {
                Debug.Log("Unit Found");
            }
        }
	}
	public void setCurrentMenuOption(combatChoice option)
    {
        currentMenuOption = option;
    }
    public void LeftSelectorMove()
    {

    }
    public void RightSelectorMove()
    {

    }
    public void UpSelectorMove()
    {
        do
        {
            unitRef--;
            if (unitRef > 0)
            {
                if (currentSide == tileInfo.tileArrayLeft)
                {
                    currentSide = tileInfo.tileArrayRight;
                    unitRef = 5;
                }
                else if (currentSide == tileInfo.tileArrayRight)
                {
                    currentSide = tileInfo.tileArrayLeft;
                    unitRef = 5;
                }
            }
        } while (currentSide[unitRef] == null);
    }
    public void DownSelectorMove()
    {
        do
        {
            unitRef++;
            if (unitRef > 5)
            {
                if (currentSide == tileInfo.tileArrayLeft)
                {
                    currentSide = tileInfo.tileArrayRight;
                    unitRef = 0;
                }
                else if(currentSide == tileInfo.tileArrayRight)
                {
                    currentSide = tileInfo.tileArrayLeft;
                    unitRef = 0;
                }
            }
        } while (currentSide[unitRef] == null);
    }
	// Update is called once per frame
	void Update () {
		
        switch (currentMenuOption)
        {
            case combatChoice.Base:
                break;
            case combatChoice.Attack:
                if (Input.GetKeyDown(KeyCode.UpArrow))
                {

                    UpSelectorMove();
                }
                if (Input.GetKeyDown(KeyCode.DownArrow))
                {
                    DownSelectorMove();
                }
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    combatMenuRef.comManRef.defender = spawnRef.enemyArray[unitRef];
                    combatMenuRef.comManRef.defenderRef = combatMenuRef.comManRef.defender.GetComponent<UnitInfo>();
                    combatMenuRef.comManRef.BattleSequence();
                }
                break;
            case combatChoice.Spell:
                break;
            case combatChoice.Item:
                break;
            case combatChoice.Status:
                if(Input.GetKeyDown(KeyCode.UpArrow))
                {
                    UpSelectorMove();
                }
                if(Input.GetKeyDown(KeyCode.DownArrow))
                {
                    DownSelectorMove();
                }
                if(Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    columnRef -= 2;
                    if(columnRef < 0)
                    {
                        columnRef = 4;
                    }
                }
                if(Input.GetKeyDown(KeyCode.RightArrow))
                {
                    columnRef += 2;
                    if(columnRef > 4)
                    {
                        columnRef = 0;
                    }
                }
                currentSide[unitRef].GetComponent<UnitInfo>().DisplayStats();
                break;
        }
	}
}
