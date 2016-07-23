using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class WorldController : MonoBehaviour {

	World world;
	GameObject[,] goWorldMap;
	public Canvas canvas;
	public HexTileView hexView;
	public GameObject HexPrefab;
	public Sprite[] spriteList;


	GameObject UI_tileTypeText, UI_Prospects_Likely, UI_Prospects_Unlikely, UI_Prospects_Possible, UI_RegionViewButton;

	public GameObject selectedObject;
	void Start () {
		
		initializeUIReferences ();
		hexView = new HexTileView (spriteList);
		world = new World ();
		goWorldMap = new GameObject[world.width, world.height];
		foreach (HexTile hex in world.map) {

			GameObject hex_go =(GameObject)Instantiate (HexPrefab, new Vector3 (hex.UnityXCoord, hex.UnityYCoord, 0), Quaternion.identity);
			goWorldMap [hex.WorldXCoord, hex.WorldYCoord] = hex_go;
			hex_go.name = "Hex_" + hex.WorldXCoord + "_" + hex.WorldYCoord;
			hex_go.GetComponent<SpriteRenderer> ().sprite = hexView.getSprite (hex.Type);
			hex_go.GetComponent<HexReference> ().HexRef = hex;

		}



	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void updateSelectedObject(GameObject ob){
		selectedObject = ob;
		updateRegionDesc ();
	}

	public void regionViewSelected(){
		if (selectedObject != null) {
			world.iterateGeneration ();
			refreshMap ();


		}
	}

	public void updateRegionDesc(){
			UI_tileTypeText.GetComponent<Text> ().text=selectedObject.GetComponent<HexReference> ().HexRef.tileTypeToString();

	}


	public void refreshGO(GameObject go){
		go.GetComponent<HexReference> ().HexRef.sprite = hexView.getSprite (go.GetComponent<HexReference>().HexRef.Type);
		go.GetComponent<SpriteRenderer> ().sprite = go.GetComponent<HexReference>().HexRef.sprite;

	}


	public void refreshMap(){
		foreach (GameObject go in goWorldMap) {

			refreshGO (go);
		}

	}

	public void initializeUIReferences(){
		UI_tileTypeText = GameObject.Find ("TileTypeText");
		UI_Prospects_Likely = GameObject.Find ("Prospects_Likely");
		UI_Prospects_Possible = GameObject.Find ("Prospects_Possible");
		UI_Prospects_Unlikely= GameObject.Find ("Prospects_Unlikely");
	}


	


}
