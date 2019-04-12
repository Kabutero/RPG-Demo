using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardManager : MonoBehaviour {
    public UnitInfo unitRef;
    public ImageSet portraitRef;
    public Text nameRef;
    public Text levelRef;
    public HealthBar healthRef;
	// Use this for initialization
	void Start () {
		
	}
    //the set functions are so that each card modifies itself rather than having the combat manager do it
	public void SetLvlText(string level)
    {
        levelRef.text = level;
    }
    public void SetNameText(string unitName)
    {
        nameRef.text = unitName;
        //nameRef.text = "Test";
    }
	// Update is called once per frame
	void Update () {
        //KLUDGE
        //Currently, the unit cards are made before the units themselves, so this serves to make sure the card displays the appropriate values
        //* could be useful for health bar modification
		if(unitRef != null)
        {
            SetNameText(unitRef.name);
            SetLvlText(unitRef.level.ToString());
        }
	}
}
