using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackArrowMover : MonoBehaviour{
    public GameObject unitSpawner;
    public SpawnUnits spawnRef;
    public GameObject combatMenuManager;
    public CombatChoiceManager combatMenuRef;
    public int rowRef, columnRef, unitRef;
	// Use this for initialization
	void Start () {
        unitSpawner = GameObject.Find("UnitSpawner");
        spawnRef = unitSpawner.GetComponent<SpawnUnits>();
        combatMenuManager = GameObject.FindGameObjectWithTag("MainBattleUI");
        combatMenuRef = combatMenuManager.GetComponent<CombatChoiceManager>();
        combatMenuManager.gameObject.SetActive(false);
        rowRef = 0;
        columnRef = 0;
        unitRef = 0;
        this.transform.SetPositionAndRotation(new Vector3(spawnRef.enemyArray[unitRef].transform.position.x, spawnRef.enemyArray[unitRef].transform.position.y + 1.58f, spawnRef.enemyArray[unitRef].transform.position.z), Quaternion.identity);
    }

    // Update is called once per frame
    void Update () {
		if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            
            columnRef -= 1;
            if(columnRef < 0)
            {
                columnRef = 5;
            }
        }
        if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            columnRef += 1;
            if(columnRef > 5)
            {
                //Rather than preventing the arrow from continuing down the array, it wraps back around to the beginning
                columnRef = 0;
            }
        }
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            int placeholder = rowRef;
            columnRef -= 2;
            if(columnRef < 0)
            {
                columnRef = placeholder;
            }
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            int placeholder = rowRef;
            columnRef += 2;
            if (columnRef >= 6)
            {
                columnRef = placeholder;
            }
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            combatMenuRef.comManRef.defender = spawnRef.enemyArray[unitRef];
            combatMenuRef.comManRef.defenderRef = combatMenuRef.comManRef.defender.GetComponent<UnitInfo>();
            combatMenuRef.comManRef.BattleSequence();
            combatMenuManager.gameObject.SetActive(true);
            Destroy(this.gameObject);
        }
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            //set main combat menu active again
            combatMenuManager.gameObject.SetActive(true);
            Destroy(this.gameObject);
        }
        //this.transform.SetPositionAndRotation(new Vector3(spawnRef.tileScript.tileArrayRight[columnRef].transform.position.x, spawnRef.tileScript.tileArrayRight[columnRef].transform.position.y + 1.58f, spawnRef.tileScript.tileArrayRight[columnRef].transform.position.z), Quaternion.identity);
    }
}
