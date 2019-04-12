using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombatChoiceManager : MonoBehaviour {
    public enum combatChoice
    {
        Base, Attack, Spell, Item, Status, Solo
    }
    int choice;
    public Canvas canvas;
    public GameObject combatManager;
    public CombatManager comManRef;
    public GameObject statDisplayPrefab;
    public GameObject statDisplay;
    public GameObject currentTarget;
    public GameObject attackArrow;
    public UnitInfo unitRef;
    public Image currentUnitImage;
    public GameObject CurrentTarget
    {
        get
        {
            return currentTarget;
        }
        set
        {
            currentTarget = value;
            unitRef = currentTarget.GetComponent<UnitInfo>();
        }
    }
	// Use this for initialization
	void Start () {
        canvas = GetComponentInParent<Canvas>();
        choice = (int)combatChoice.Base;
        comManRef = combatManager.GetComponent<CombatManager>();
	}
    public void setAtk()
    {
        choice = (int)combatChoice.Attack;
        Instantiate(attackArrow);
    }
    public void setCurrentUnit()
    {
        
    }
    public void setSpell()
    {
        choice = (int)combatChoice.Spell;
    }
    public void setStatus()
    {
        choice = (int)combatChoice.Status;
        statDisplay = Instantiate(statDisplayPrefab);
        statDisplay.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
        //unitRef.DisplayStats();
    }
	void Reset()
    {
        choice = (int)combatChoice.Base;
    }
	// Update is called once per frame
	void Update () {
		
	}
}
