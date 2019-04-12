using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIStatDisplay : MonoBehaviour {
    public GameObject combatChoice;
    CombatChoiceManager combatRef;
    Image UnitDisplay;
    Sprite elementDisplay;
    Text nameDisplay;
    Text LVLDisplay;
    Text HPDisplay;
    Text ATKDisplay;
    Text DEFDisplay;
    Text MAGDisplay;
    Text RESDisplay;
    Transform UIRef;
	// Use this for initialization
	void Start () {
        UIRef = this.transform.Find("Name");
        nameDisplay = UIRef.GetComponent<Text>();
        UIRef = this.transform.Find("HPText");
        HPDisplay = UIRef.GetComponent<Text>();
        UIRef = this.transform.Find("AtkText");
        ATKDisplay = UIRef.GetComponent<Text>();
        UIRef = this.transform.Find("DefText");
        DEFDisplay = UIRef.GetComponent<Text>();
        UIRef = this.transform.Find("MagText");
        MAGDisplay = UIRef.GetComponent<Text>();
        UIRef = this.transform.Find("ResText");
        RESDisplay = UIRef.GetComponent<Text>();
        UIRef = this.transform.Find("Level");
        LVLDisplay = UIRef.GetComponent<Text>();
        UIRef = this.transform.Find("Image");
        UnitDisplay = UIRef.GetComponent<Image>();
        combatChoice = GameObject.FindGameObjectWithTag("MainBattleUI");
        combatChoice.gameObject.SetActive(false);
        //combatRef = combatChoice.GetComponent<CombatChoiceManager>();
	}
    public void goBack()
    {
        combatChoice.gameObject.SetActive(true);
        Destroy(this.gameObject);
    }
	public void DisplayInfo(Sprite unitImg, string nameDis, float lvl, float hp, float atk, float def, float mag, float res)
    {
        UnitDisplay.sprite = unitImg;
        nameDisplay.text = nameDis;
        HPDisplay.text = "HP: " + hp.ToString();
        ATKDisplay.text = "ATK: " + atk.ToString();
        DEFDisplay.text = "DEF: " + def.ToString();
        MAGDisplay.text = "MAG: " + mag.ToString();
        RESDisplay.text = "RES: " + res.ToString();
    }
	// Update is called once per frame
	void Update () {
		
	}
}
