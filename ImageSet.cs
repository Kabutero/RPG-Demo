using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageSet : MonoBehaviour {
    Image imageToSet;
    Image currentImage;
	// Use this for initialization
	void Start () {
        //currentImage = this.gameObject.GetComponent<Image>();
	}

    //This script's sole purpose is to be able to assign the unit picture for modification using GetComponentInChildren. If I used the image itself, it would only return the card image itself.
	public void SetImage(Sprite set)
    {
        currentImage.sprite = set;
    }
	// Update is called once per frame
	void Update () {
		
	}
}
