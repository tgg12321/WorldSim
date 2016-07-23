using UnityEngine;
using System.Collections;

public class HexReference : MonoBehaviour {

	public HexTile hexRef;
	
	public HexTile HexRef {
		get {
			return hexRef;
		}
		set {
			hexRef = value;
		}
	}
}
