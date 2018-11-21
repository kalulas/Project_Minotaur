using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class SortLayer : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

	
	// Update is called once per frame
	void Update () {
		int layer = 0;
		Dictionary<GameObject,float> SortDict = new Dictionary<GameObject,float>();
		GameObject[] SortList = new GameObject[50];
		SortList = GameObject.FindGameObjectsWithTag("NeedSort");
		foreach( GameObject Object in SortList){
			//Debug.Log(Object);
			float y = Object.GetComponent<Transform>().position.y;
			SortDict.Add(Object, y);
		}
		var SortedDict = from entry in SortDict orderby entry.Value descending select entry;
		Debug.Log(SortedDict);
		foreach( var Object in SortedDict){
			//if(Object.Key.GetComponent<SpriteRenderer>())
			Object.Key.GetComponent<Renderer>().sortingOrder = layer;
			//else
			//Object.Key.GetComponent<Renderer>().sortingOrder = layer;
			layer ++;
		}
	}
}
