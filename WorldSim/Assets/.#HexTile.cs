﻿using UnityEngine;
using System.Collections;

public class HexTile{
	public Sprite sprite;
	int worldXCoord, worldYCoord;
	float unityXCoord, unityYCoord;




	TileType type;

	public TileType Type {
		get {
			return type;
		}
		set {
			type = value;
		}
	}

	GameObject hexObject;

	public HexTile(int wx, int wy, float ux, float uy){
		type = randomizeTile ();
		worldXCoord = wx;
		worldYCoord = wy;
		unityXCoord = ux;
		unityYCoord = uy;



	}

	TileType randomizeTile(){
		int r= Random.Range (0, 6);
	
		switch (r) {

		case 0:
			return TileType.Dirt;
		case 1:
			return TileType.Forest;
		case 2:
			return TileType.Grassland;
		case 3:
			return TileType.Desert;
		case 4:
			return TileType.Mountain;
		case 5:
			return TileType.Deep_Ocean;
		
		}
		Debug.Log ("Range finding error, rolled: " + r);
		return TileType.Void;
	}

	public float UnityYCoord {
		get {
			return unityYCoord;
		}
	}

	public float UnityXCoord {
		get {
			return unityXCoord;
		}
	}

	public int WorldYCoord {
		get {
			return worldYCoord;
		}
	}

	public int WorldXCoord {
		get {
			return worldXCoord;
		}
	}
}
