using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitInfo : MonoBehaviour {
    public GameObject library;
    public MonsterLibrary reference;
    public GameObject infoUI;
    public UIStatDisplay UIRef;
    public GameObject combatChoice;
    public CombatChoiceManager combatRef;
    public Sprite sprite;
    public int libIndex;
    public string name;
    public bool ally;
    public float health;
    public float Health
    {
        get
        {
            return health;
        }
        set
        {
            health = value;
        }
    }
    public float currentHealth;
    public float CurrentHealth
    {
        get
        {
            return currentHealth;
        }
        set
        {
            currentHealth = value;
        }
    }
    public float attack;
    public float Attack
    {
        get
        {
            return attack;
        }
        set
        {
            attack = value;
        }
    }
    public float defense;
    public float Defense
    {
        get
        {
            return defense;
        }
        set
        {
            defense = value;
        }
    }
    public float magic;
    public float Magic
    {
        get
        {
            return magic;
        }
        set
        {
            magic = value;
        }
    }
    public float resist;
    public float Resist
    {
        get
        {
            return resist;
        }
        set
        {
            resist = value;
        }
    }
    public float speed;
    public float Speed
    {
        get
        {
            return speed;
        }
        set
        {
            speed = value;
        }
    }
    public float hpGrowth;
    public float HPGrowth
    {
        get
        {
            return hpGrowth;
        }
        set
        {
            hpGrowth = value;
        }
    }
    public float atkGrowth;
    public float ATKGrowth
    {
        get
        {
            return atkGrowth;
        }
        set
        {
            atkGrowth = value;
        }
    }
    public float defGrowth;
    public float DEFGrowth
    {
        get
        {
            return defGrowth;
        }
        set
        {
            defGrowth = value;
        }
    }
    public float magGrowth;
    public float MAGGrowth
    {
        get
        {
            return magGrowth;
        }
        set
        {
            magGrowth = value;
        }
    }
    public float resGrowth;
    public float RESGrowth
    {
        get
        {
            return resGrowth;
        }
        set
        {
            resGrowth = value;
        }
    }
    public float speedGrowth;
    public float SpeedGrowth
    {
        get
        {
            return speedGrowth;
        }
        set
        {
            speedGrowth = value;
        }
    }
    public float level;
    public float Level
    {
        get
        {
            return level;
        }
        set
        {
            level = value;
        }
    }
    public float experience;
    public float Experience
    {
        get
        {
            return experience;
        }
        set
        {
            experience = value;
        }
    }
	// Use this for initialization
	void Start () {
        library = GameObject.FindGameObjectWithTag("Library");
        reference = library.GetComponent<MonsterLibrary>();
        combatChoice = GameObject.Find("BattleUI");
        combatRef = combatChoice.GetComponent<CombatChoiceManager>();
        Level = 1;
        AssignAttributes();
        //DisplayStats();
	}
	void AssignAttributes()
    {
        int index = libIndex;
        name = reference.dataArray[index].name;
        Health = reference.dataArray[index].baseHP;
        CurrentHealth = Health;
        Attack = reference.dataArray[index].baseATK;
        Defense = reference.dataArray[index].baseDEF;
        Magic = reference.dataArray[index].baseMAG;
        Resist = reference.dataArray[index].baseRES;
        Speed = reference.dataArray[index].baseSPD;
        HPGrowth = reference.dataArray[index].HPgrowth;
        ATKGrowth = reference.dataArray[index].ATKgrowth;
        DEFGrowth = reference.dataArray[index].DEFgrowth;
        MAGGrowth = reference.dataArray[index].MAGgrowth;
        RESGrowth = reference.dataArray[index].RESgrowth;
        SpeedGrowth = reference.dataArray[index].SPDgrowth;
        Debug.Log(speed);
    }
    public void AssignAttributes(int index)
    {
        name = reference.dataArray[index].name;
        Health = reference.dataArray[index].baseHP;
        Attack = reference.dataArray[index].baseATK;
        Defense = reference.dataArray[index].baseDEF;
        Magic = reference.dataArray[index].baseMAG;
        Resist = reference.dataArray[index].baseRES;
        HPGrowth = reference.dataArray[index].HPgrowth;
        ATKGrowth = reference.dataArray[index].ATKgrowth;
        DEFGrowth = reference.dataArray[index].DEFgrowth;
        MAGGrowth = reference.dataArray[index].MAGgrowth;
        RESGrowth = reference.dataArray[index].RESgrowth;
    }
    public void SetToLevel(int target)
    {
        while(Level != target)
        {
            LevelUp();
        }
    }
    void LevelUp()
    {
        Level++;
        Health += Random.Range((HPGrowth -1), (HPGrowth + 2));
        Attack += Random.Range((ATKGrowth - 1), (ATKGrowth + 2));
        Defense += Random.Range((DEFGrowth - 1), (DEFGrowth + 2));
        Magic += Random.Range((MAGGrowth - 1), (MAGGrowth + 2));
        Resist += Random.Range((RESGrowth - 1), (RESGrowth + 2));
    }
    public float GiveSpeed()
    {
        return speed;
    }
    void OnMouseDown()
    {
        Debug.Log(GiveSpeed());
        DisplayStats();
    }
    public void DisplayStats()
    {
        infoUI = GameObject.Find("UnitInfoDisplay(Clone)");
        if(infoUI == null)
        {
            infoUI = Instantiate(infoUI);
        }
        UIRef = infoUI.GetComponent<UIStatDisplay>();
        UIRef.DisplayInfo(this.GetComponent<SpriteRenderer>().sprite, name, Level, Health, Attack, Defense, Magic, Resist);
    }
	// Update is called once per frame
	void Update () {
		
	}
}
