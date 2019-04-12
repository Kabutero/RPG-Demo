using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterLibrary : MonoBehaviour {
    public struct MonsterInfo
    {
        public string name;
        public int index;
        public float baseHP;
        public float baseATK;
        public float baseDEF;
        public float baseMAG;
        public float baseRES;
        public float baseSPD;
        public float HPgrowth;
        public float ATKgrowth;
        public float DEFgrowth;
        public float MAGgrowth;
        public float RESgrowth;
        public float SPDgrowth;
    }
    public MonsterInfo[] dataArray;
    public GameObject[] monsterSprite;
    void Awake()
    {
        dataArray = new MonsterInfo[50];
        /*STAT GUIDELINES
         * MAX BASE VALUE OF STATS IS 20
         * GROWTH IS LIKELYHOOD TO GAIN A BONUS STAT POINT IN A GIVEN STAT
         * ALL MONSTERS SHOULD HAVE DECENT STAT GAINS. THE GOAL IS TO BE ABLE TO USE WHATEVER MONSTERS YOU WANT
         * depending on testing, might need another value to determine if a stat does not increase upon leveling up
         */
        #region Bluebug
        MonsterInfo bug1 = new MonsterInfo();
        bug1.name = "Bluebug";
        bug1.index = 1;
        bug1.baseHP = 15;
        bug1.baseATK = 5;
        bug1.baseDEF = 7;
        bug1.baseMAG = 3;
        bug1.baseRES = 4;
        bug1.baseSPD = 5;
        bug1.HPgrowth = 0.4f;
        bug1.ATKgrowth = 0.7f;
        bug1.DEFgrowth = 0.8f;
        bug1.MAGgrowth = 0.3f;
        bug1.RESgrowth = 0.4f;
        bug1.SPDgrowth = 0.6f;
        dataArray[1] = bug1;
        #endregion
        #region Giant Rat
        MonsterInfo rat1 = new MonsterInfo();
        rat1.name = "Giant Rat";
        rat1.index = 2;
        rat1.baseHP = 15;
        rat1.baseATK = 8;
        rat1.baseDEF = 4;
        rat1.baseMAG = 3;
        rat1.baseRES = 6;
        rat1.baseSPD = 7;
        rat1.HPgrowth = 0.4f;
        rat1.ATKgrowth = 0.6f;
        rat1.DEFgrowth = 0.4f;
        rat1.MAGgrowth = 0.2f;
        rat1.RESgrowth = 0.5f;
        rat1.SPDgrowth = 0.7f;
        dataArray[2] = rat1;
        #endregion
        #region Slime
        MonsterInfo slime1 = new MonsterInfo();
        slime1.name = "Slime";
        slime1.index = 3;
        slime1.baseHP = 18;
        slime1.baseATK = 4;
        slime1.baseDEF = 8;
        slime1.baseMAG = 7;
        slime1.baseRES = 4;
        slime1.baseSPD = 3;
        slime1.HPgrowth = 0.8f;
        slime1.ATKgrowth = 0.3f;
        slime1.DEFgrowth = 0.6f;
        slime1.MAGgrowth = 0.5f;
        slime1.RESgrowth = 0.4f;
        slime1.SPDgrowth = 0.3f;
        dataArray[3] = slime1;
        #endregion
        #region Worm
        MonsterInfo worm1 = new MonsterInfo();
        worm1.name = "Worm";
        worm1.index = 4;
        worm1.baseHP = 12;
        worm1.baseATK = 9;
        worm1.baseDEF = 4;
        worm1.baseMAG = 3;
        worm1.baseRES = 4;
        worm1.baseSPD = 4;
        worm1.HPgrowth = 0.4f;
        worm1.ATKgrowth = 0.9f;
        worm1.DEFgrowth = 0.3f;
        worm1.MAGgrowth = 0.2f;
        worm1.RESgrowth = 0.4f;
        worm1.SPDgrowth = 0.3f;
        dataArray[4] = worm1;
        #endregion
        #region Hornet
        MonsterInfo hornet1 = new MonsterInfo();
        hornet1.name = "Hornet";
        hornet1.index = 5;
        hornet1.baseHP = 14;
        hornet1.baseATK = 7;
        hornet1.baseDEF = 5;
        hornet1.baseMAG = 3;
        hornet1.baseRES = 2;
        hornet1.baseSPD = 9;
        hornet1.HPgrowth = 0.5f;
        hornet1.ATKgrowth = 0.7f;
        hornet1.DEFgrowth = 0.6f;
        hornet1.MAGgrowth = 0.2f;
        hornet1.RESgrowth = 0.3f;
        hornet1.SPDgrowth = 0.8f;
        dataArray[5] = hornet1;
        #endregion
        #region Crab
        MonsterInfo crab1 = new MonsterInfo();
        #endregion
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
