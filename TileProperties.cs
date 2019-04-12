using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileProperties : MonoBehaviour {
    public int row;
    public int Row
    {
        get
        {
            return row;
        }
    }
    public int column;
    public int Column
    {
        get
        {
            return column;
        }
    }
    public bool containsUnit;
    public bool ContainsUnit
    {
        get
        {
            return containsUnit;
        }
        set
        {
            containsUnit = value;
        }
    }
    public GameObject currentUnit;
    public GameObject CurrentUnit
    {
        get
        {
            return currentUnit;
        }
        set
        {
            currentUnit = value;
        }
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
