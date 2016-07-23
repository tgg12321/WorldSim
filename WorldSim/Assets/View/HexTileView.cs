using UnityEngine;
using System.Collections;
using System;
public class HexTileView {


	// Use this for initialization
	public struct SpriteStruct
	{
		public Sprite sprite;
		public TileType tileType;
	}


	public SpriteStruct[] spriteStructList;

	public HexTileView (Sprite[] spriteList) {
		spriteStructList = new SpriteStruct[spriteList.Length];
		int i = 0;
		foreach (Sprite spr in spriteList){
			TileType type = findType (spr.name);
			if (type.CompareTo( TileType.Void)==1) {
				

				spriteStructList [i].sprite = spr;
				spriteStructList [i].tileType = type;
			
				i++;
			} 


			
		}
	
	}

	public TileType findType(String name){
		foreach (TileType type in Enum.GetValues(typeof(TileType))) {
			if (name.Equals(type.ToString())) {
				return type;
			}

		}
		Debug.Log ("Error, sprite " + name + " doesnt have matching TileType");
		return TileType.Void;

	}

	public Sprite getSprite(TileType type){

	
		foreach (SpriteStruct sprS in spriteStructList) {
	

			if (sprS.tileType.CompareTo( type)==0){
				
				return sprS.sprite;
			}
		}
		Debug.Log ("Error, type " + type + " not found in spriteStruct List");
		return null;

	}
}
