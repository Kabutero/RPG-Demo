using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombatManager : MonoBehaviour {
    public GameObject attacker;
    public UnitInfo attackerRef;
    public GameObject defender;
    public UnitInfo defenderRef;
    public GameObject spawnManager;
    public SpawnUnits spawnRef;
    public GameObject turnOrder;
    public TurnOrder turnRef;
    public CombatChoiceManager menuRef;
    public GameObject combatMenu;
    public GameObject[] placeholderArray;
    public GameObject[] allyArray;
    public GameObject[] enemyArray;
    public GameObject[] moveOrder;
    public GameObject[] cardArray;
    public ImageSet setImage;
    public UnitInfo sideRef;
    public int allyIndex;
    public int unitIndex;
    public GameObject unitCard;
    public Sprite allyCard, enemyCard;
    public GameObject currentCard;
    public CardManager currentCardManager;
    public Image currentCardImage;
	// Use this for initialization
	void Start () {
        spawnManager = GameObject.Find("UnitSpawner");
        spawnRef = spawnManager.GetComponent<SpawnUnits>();
        int a = 0;
        int arraySize = 0;
        allyIndex = 0;
        unitIndex = 0;
        cardArray = new GameObject[moveOrder.Length];
        /*placeholderArray = new GameObject[spawnRef.unitArray.Length];
        //counts the number of allied units in order to define the allyArray size
        while (a < 6)
        {
            while (spawnRef.UnitArray[0, a] == null)
            {
                a++;
            }
            arraySize++;
        }
        allyArray = new GameObject[arraySize];
        a = 0;
        int b = 0;
        //populates allyArray with each allied unit
        while (a < 6)
        {
            while (spawnRef.UnitArray[0, a] == null)
            {
                a++;
            }
            allyArray[b] = spawnRef.UnitArray[0, a];
            b++;
        }
        */
        for(int i = 0; i < moveOrder.Length; i++)
        {
            cardArray[i] = Instantiate(unitCard);
            cardArray[i].transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
            //cardArray[i].transform.SetPositionAndRotation(new Vector3(152.7f, 290.5f - (110 * i), 0), Quaternion.identity); *This is for fullsize cards
            cardArray[i].transform.SetPositionAndRotation(new Vector3(103.7f, 310.5f - (70 * i), 0), Quaternion.identity);
            cardArray[i].transform.localScale -= new Vector3(0.35f, 0.35f, 0);
            currentCard = cardArray[i];
            currentCardManager = currentCard.GetComponent<CardManager>();
            currentCardImage = currentCard.GetComponent<Image>();
            setImage = currentCard.GetComponentInChildren<ImageSet>();
            sideRef = moveOrder[i].GetComponent<UnitInfo>();
            currentCardManager.unitRef = sideRef;
            currentCardManager.SetNameText(sideRef.name);
            currentCardManager.SetLvlText(sideRef.level.ToString());
            //setImage.SetImage(sideRef.sprite);
            if(sideRef.ally)
            {
                currentCardImage.sprite = allyCard;
            }
            else
            {
                currentCardImage.sprite = enemyCard;
            }
            //currentCardImage.sprite = moveOrder[i].GetComponent<SpriteRenderer>().sprite;
        }
    }
    public void BattlePrep()
    {
        cardArray = new GameObject[moveOrder.Length];
        /*placeholderArray = new GameObject[spawnRef.unitArray.Length];
        //counts the number of allied units in order to define the allyArray size
        while (a < 6)
        {
            while (spawnRef.UnitArray[0, a] == null)
            {
                a++;
            }
            arraySize++;
        }
        allyArray = new GameObject[arraySize];
        a = 0;
        int b = 0;
        //populates allyArray with each allied unit
        while (a < 6)
        {
            while (spawnRef.UnitArray[0, a] == null)
            {
                a++;
            }
            allyArray[b] = spawnRef.UnitArray[0, a];
            b++;
        }
        */
        for (int i = 0; i < moveOrder.Length; i++)
        {
            cardArray[i] = Instantiate(unitCard);
            cardArray[i].transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
            //cardArray[i].transform.SetPositionAndRotation(new Vector3(152.7f, 290.5f - (110 * i), 0), Quaternion.identity); *This is for fullsize cards
            cardArray[i].transform.SetPositionAndRotation(new Vector3(103.7f, 310.5f - (70 * i), 0), Quaternion.identity);
            cardArray[i].transform.localScale -= new Vector3(0.35f, 0.35f, 0);
            currentCard = cardArray[i];
            currentCardManager = currentCard.GetComponent<CardManager>();
            currentCardImage = currentCard.GetComponent<Image>();
            setImage = currentCard.GetComponentInChildren<ImageSet>();
            sideRef = moveOrder[i].GetComponent<UnitInfo>();
            currentCardManager.unitRef = sideRef;
            currentCardManager.SetNameText(sideRef.name);
            currentCardManager.SetLvlText(sideRef.level.ToString());
            //setImage.SetImage(sideRef.sprite);
            if (sideRef.ally)
            {
                currentCardImage.sprite = allyCard;
            }
            else
            {
                currentCardImage.sprite = enemyCard;
            }
            //currentCardImage.sprite = moveOrder[i].GetComponent<SpriteRenderer>().sprite;
        }
        SequentialBattleStart();
    }
	void BattleStart()
    {
        attacker = allyArray[0];
        attackerRef = attacker.GetComponent<UnitInfo>();
    }
    public void SequentialBattleStart()
    {
        attacker = moveOrder[0];
        attackerRef = attacker.GetComponent<UnitInfo>();
        //menuRef.currentUnitImage.sprite = attackerRef.sprite;
    }
    void SelectNextUnit()
    {
        allyIndex++;
        if(allyIndex > allyArray.Length)
        {
            NewTurn();
        }
        attacker = allyArray[allyIndex];
        attackerRef = attacker.GetComponent<UnitInfo>();
        if(attackerRef.Health == 0)
        {
            SelectNextUnit();
        }
        //TO DO:
        //-Add functionality to scroll unit cards
        //-Adjust scale of unit card corresponding to the current turn
    }
    void SelectNextUnitSequential()
    {
        unitIndex++;
        if (unitIndex >= moveOrder.Length)
        {
            NewTurn();
        }
        attacker = moveOrder[unitIndex];
        attackerRef = attacker.GetComponent<UnitInfo>();
        if (attackerRef.Health == 0)
        {
            SelectNextUnitSequential();
        }
        combatMenu.gameObject.SetActive(true);
        //TO DO:
        //-Add functionality to scroll unit cards
        //-Adjust scale of unit card corresponding to the current turn
    }
    public void BattleSequence()
    {
        defenderRef.CurrentHealth -= (attackerRef.Attack - defenderRef.Defense);
        if (defenderRef.CurrentHealth == 0)
        {
            defender.gameObject.SetActive(false);
        }
        SelectNextUnitSequential();
        //TO DO:
        //-Adjust size of moveorder and enemy/ally arrays when a unit runs out of HP
        //-Create damage formula and apply it to attacker and defender
    }
    void NewTurn()
    {
        allyIndex = 0;
        unitIndex = 0;
        attacker = moveOrder[unitIndex];
        attackerRef = attacker.GetComponent<UnitInfo>();
    }
	// Update is called once per frame
	void Update () {
		
	}
}
