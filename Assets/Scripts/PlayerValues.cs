﻿using UnityEngine;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

[System.Serializable]
class ValuesForPlayer {
	public string name;
	public int dayNumber;
	public float cash;
	public InventoryItems[] inStock;
}

public class PlayerValues : MonoBehaviour {
	// the player name won't be used, it's just here as a formality.
	public string name;
	
	// if this number becomes bigger than the size of DayValues then all hell will break loose
	public int dayNumber;
	
	// how much money the player has at any time, this will impact purchases and deductions
	public float cash;
	
	// here is where all the everything ever lives
	public Inventory inventory;

	// :siren: WATCH OUT IT'S I/O TIME :siren:
	public void Save(){
		Debug.Log ("TRYING TO SAVE!!!!");
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Create (Application.persistentDataPath+"/PlayerValues.dat");

		// @TODO: Try this with the base GameObject and see if this is truly necessary.
		ValuesForPlayer vals = new ValuesForPlayer();
		vals.name = name;
		vals.dayNumber = dayNumber;
		vals.cash = cash;
		vals.inStock = inventory.stock;

		bf.Serialize (file, vals);
		file.Close ();
	}

	public void Load(){
		Debug.Log ("TRYING TO LOAD!!!!");
		if (File.Exists (Application.persistentDataPath + "/PlayerValues.dat")) {
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Open (Application.persistentDataPath+"/PlayerValues.dat", FileMode.Open);
			ValuesForPlayer vals = (ValuesForPlayer)bf.Deserialize(file);
			file.Close();

			name = vals.name;
			dayNumber = vals.dayNumber;
			cash = vals.cash;
			inventory.stock = vals.inStock;
			Debug.Log ("LOADED ALL MY VALUES UP GOOD");
		} else {
			Debug.Log ("NO FILE, DINDU NOTHIN'");
		}
	}

	// IF, FOR WHATEVER REASON WE NEED THIS LOADED BEFORE THE MAIN DAY SCENE, CONSULT:
	// http://unity3d.com/learn/tutorials/modules/beginner/live-training-archive/persistence-data-saving-loading

	public bool CanAfford(float dosh){
		return cash >= dosh;
	}

	public float Spend(float lodsemone){
		if (CanAfford (lodsemone)) {
			Debug.Log ("Bought some stuff for $"+lodsemone.ToString("F2")+"!");
			return cash -= lodsemone;
		} else {
			return cash;
		}
	}
}