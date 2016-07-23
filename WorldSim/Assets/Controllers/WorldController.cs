using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class WorldController : MonoBehaviour {

	World world;
	public Canvas canvas;
	public HexTileView hexView;
	public GameObject HexPrefab;
	public Sprite[] spriteList;

	public GameObject selectedObject;
	void Start () {
		hexView = new HexTileView (spriteList);
		world = new World ();
		foreach (HexTile hex in world.map) {
			
			GameObject hex_go =(GameObject)Instantiate (HexPrefab, new Vector3 (hex.UnityXCoord, hex.UnityYCoord, 0), Quaternion.identity);
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
	}

	public void regionViewSelected(){
		if (selectedObject != null) {
			
			GameObject tileTypeOb= GameObject.FindWithTag ("TileTypeText");

			tileTypeOb.GetComponent<Text> ().text=selectedObject.GetComponent<HexReference> ().HexRef.tileTypeToString();

		}
	}	
}
