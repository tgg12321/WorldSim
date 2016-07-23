using UnityEngine;
using System.Collections;

public class HexTile{
	public Sprite sprite;
	public HexTile NW_NEIGHBOR, NE_NEIGHBOR, E_NEIGHBOR, SE_NEIGHBOR, W_NEIGHBOR, SW_NEIGHBOR;
	int worldXCoord, worldYCoord;
	float unityXCoord, unityYCoord;

	public int testInt = 0;

	public int TestInt {
		get {
			return testInt;
		}
		set {
			testInt = value;
		}
	}

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


	public string tileTypeToString(){

	
		string strType = type.ToString ();
		strType=strType.Replace ("_", " ");
		return strType;

	}




	public void setNeighbor(string direc, HexTile hex){
		switch (direc) {
		case "NW":
			NW_NEIGHBOR = hex;
			return;
		case "W":
			W_NEIGHBOR = hex;
			return;
		case "SW":
			SW_NEIGHBOR = hex;
			return;
		case "E":
			E_NEIGHBOR = hex;
			return;
		case "SE":
			SW_NEIGHBOR = hex;
			return;
		case "NE":
			NE_NEIGHBOR = hex;
			return;



		}


	}


	public void setNeighborsToSelf(int chance){

		for (int i = 0; i < 5; i++) {
			int r= Random.Range(1, chance+1);

			if (r == chance) {

				changeNeighborTile (i);

			}
		}

	}

	void changeNeighborTile(int i){
		
		switch (i) {
		case 0:
			if (NE_NEIGHBOR != null) {
				
				NE_NEIGHBOR.Type = type;
			}
			break;
		case 1:
			if (E_NEIGHBOR != null) {
				E_NEIGHBOR.Type = type;

			}
			break;
		case 2:
			if (SE_NEIGHBOR != null) {
				SE_NEIGHBOR.Type = type;
			}
			break;
		case 3:
			if (SW_NEIGHBOR != null) {
				SW_NEIGHBOR.Type = type;
			}
			break;
		case 4:
			if (W_NEIGHBOR != null) {
				W_NEIGHBOR.Type = type;
			}
			break;
		case 5:
			if (NW_NEIGHBOR != null) {
				NW_NEIGHBOR.Type = type;
			}
			break;


		}



	}

	override public string  ToString(){
		return "" + worldXCoord + "_" + worldYCoord + " " + type;
	}

}
