using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnUnits : MonoBehaviour {
    public GameObject tileRef;
    public TileInfo tileScript;
    public TileProperties tileProp;
    public GameObject unitRef;
    public UnitInfo unitScript;
    public GameObject libraryRef;
    public MonsterLibrary libScript;
    public GameObject[] unitArray;
    public GameObject[] UnitArray
    {
        get
        {
            return unitArray;
        }
    }
    public GameObject turnOrderer;
    public TurnOrder turnRef;
    public GameObject[] allyArray;
    public GameObject[] enemyArray;
    public GameObject[] allArray;
    int tileSpot;
    public int totalUnitNum;
    public int arraySizeEnemy;
    public int arraySizeAlly;
    // Use this for initialization
    void Start () {
        tileRef = GameObject.Find("TileHolder");
        tileScript = tileRef.GetComponent<TileInfo>();
        //unitRef = GameObject.Find("UnitInfo");
        //unitScript = unitRef.GetComponent<UnitInfo>();
        libraryRef = GameObject.Find("Library");
        libScript = libraryRef.GetComponent<MonsterLibrary>();
        turnOrderer = GameObject.Find("CombatCoordinator");
        turnRef = turnOrderer.GetComponent<TurnOrder>();
        arraySizeEnemy = 0;
        arraySizeAlly = 0;
        unitArray = new GameObject[12];
        SpawnAlliedUnit();
        SpawnAlliedUnit();
        SpawnEnemyUnit();
        SpawnEnemyUnit();
        CompileUnitArrays();
        turnRef.CreateTurnArray();
	}
	void SpawnUnit()
    {

    }
    void SpawnAlliedUnit()
    {
        for (int i = 0; i < unitArray.Length; i++)
        {
            if (unitArray[i] == null)
            {
                int type = Random.Range(1, 5);
                int tileSpot = Random.Range(0, 5);
                tileProp = tileScript.tileArrayLeft[tileSpot].GetComponent<TileProperties>();
                while(tileProp.ContainsUnit)
                {
                    tileSpot = Random.Range(0, 5);
                    tileProp = tileScript.tileArrayLeft[tileSpot].GetComponent<TileProperties>();
                }
                tileProp = tileScript.tileArrayLeft[tileSpot].GetComponent<TileProperties>();
                unitArray[i] = Instantiate(libScript.monsterSprite[type], new Vector3(tileScript.tileArrayLeft[tileSpot].transform.position.x, tileScript.tileArrayLeft[tileSpot].transform.position.y + .07f, tileScript.tileArrayLeft[tileSpot].transform.position.z - .05f), Quaternion.Euler(38.13f, 0, -90));
                unitScript = unitArray[i].GetComponent<UnitInfo>();
                unitScript.ally = true;
                tileProp.ContainsUnit = true;
                tileProp.CurrentUnit = unitArray[i];
                //arraySizeAlly++;
                totalUnitNum++;
                return;
            }
        }
    }
    void SpawnEnemyUnit()
    {
        for (int i = 0; i < unitArray.Length; i++)
        {
            if (unitArray[i] == null)
            {
                int type = Random.Range(1, 5);
                do
                {
                    tileSpot = Random.Range(0, 6);
                    tileProp = tileScript.tileArrayRight[tileSpot].GetComponent<TileProperties>();
                } while (tileProp.ContainsUnit == true);
                unitArray[i] = Instantiate(libScript.monsterSprite[type], new Vector3(tileScript.tileArrayRight[tileSpot].transform.position.x, tileScript.tileArrayRight[tileSpot].transform.position.y + .07f, tileScript.tileArrayRight[tileSpot].transform.position.z - .05f), Quaternion.Euler(38.13f, 0, 90));
                tileProp = tileScript.tileArrayRight[tileSpot].GetComponent<TileProperties>();
                tileProp.ContainsUnit = true;
                tileProp.CurrentUnit = unitArray[i];
                unitScript = unitArray[i].GetComponent<UnitInfo>();
                unitScript.ally = false;
                //arraySizeEnemy++;
                totalUnitNum++;
                return;
            }
        }
    }
    void SpawnUnit(int side)
    {
        for (int i = 0; i < unitArray.Length; i++)
        {
            if(unitArray[i] == null)
            {
                int type = Random.Range(1, 5);
                int tileSpot = Random.Range(0, 6);
                if (side == 0)
                {
                    unitArray[i] = Instantiate(libScript.monsterSprite[type], new Vector3(tileScript.tileArrayLeft[tileSpot].transform.position.x, tileScript.tileArrayLeft[tileSpot].transform.position.y + .07f, tileScript.tileArrayLeft[tileSpot].transform.position.z - .05f), Quaternion.Euler(38.13f, 0, -90));
                }
                else if(side == 1)
                {
                    unitArray[i] = Instantiate(libScript.monsterSprite[type], new Vector3(tileScript.tileArrayRight[tileSpot].transform.position.x, tileScript.tileArrayRight[tileSpot].transform.position.y + .07f, tileScript.tileArrayRight[tileSpot].transform.position.z - .05f), Quaternion.Euler(38.13f, 0, 90));
                }
                totalUnitNum++;
                    return;
            }
        }
    }
    void CompileUnitArrays()
    {
        int enemyIndex = 0;
        int allyIndex = 0;
        int allIndex = 0;
        foreach(GameObject unit in unitArray)
        {
            if (unit != null)
            {
                unitScript = unit.GetComponent<UnitInfo>();
                if (unitScript.ally == true)
                {
                    arraySizeAlly++;
                }
                else
                {
                    arraySizeEnemy++;
                }
            }
        }
        allyArray = new GameObject[arraySizeAlly];
        enemyArray = new GameObject[arraySizeEnemy];
        allArray = new GameObject[totalUnitNum];
        foreach(GameObject unit in unitArray)
        {
            if (unit != null)
            {
                unitScript = unit.GetComponent<UnitInfo>();
                if (unitScript.ally == true)
                {
                    allyArray[allyIndex] = unit;
                    allyIndex++;
                }
                else
                {
                    enemyArray[enemyIndex] = unit;
                    enemyIndex++;
                }
            }
        }
        foreach(GameObject unit in unitArray)
        {
            if(unit != null)
            {
                allArray[allIndex] = unit;
                allIndex++;
            }
        }
    }
	// Update is called once per frame
	void Update () {
    }
}
