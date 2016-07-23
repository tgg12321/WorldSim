using UnityEngine;
using System.Collections;

public class World{

	public HexTile[,] map;

	public int height =50;
	public int width =50;
	public float xOffset=1.276f;
	public float yOffset=1.11f;

	// Use this for initialization
	public World() {

		map = new HexTile[width, height];

		for (int x = 0; x < width; x++) {
			for (int y = 0; y < height; y++) {

				float xPos = x*xOffset;
				if (y % 2 == 1) {
					xPos += xOffset/2f;

				} 

				map[x, y] = new HexTile(x,y, xPos, y*yOffset);

			}
		

		}
		fillHexNeighbors ();


	}
			



	public void fillHexNeighbors(){
		foreach (HexTile hex in map) {


			if (hex.WorldYCoord % 2 == 1) {
				try {
					hex.setNeighbor ("NE", map [hex.WorldXCoord + 1, hex.WorldYCoord - 1]);
				} catch {
					
				}
				try {
					hex.setNeighbor ("E", map [hex.WorldXCoord + 1, hex.WorldYCoord]);
				} catch {

				}
				try {
					hex.setNeighbor ("SE", map [hex.WorldXCoord + 1, hex.WorldYCoord + 1]);
				} catch {

				}
				try {
					hex.setNeighbor ("W", map [hex.WorldXCoord - 1, hex.WorldYCoord]);
				} catch {

				}
				try {
					hex.setNeighbor ("NW", map [hex.WorldXCoord, hex.WorldYCoord - 1]);
				} catch {

				}
				try {
					hex.setNeighbor ("SW", map [hex.WorldXCoord, hex.WorldYCoord + 1]);
				} catch {

				}

			} else {

				try {
					hex.setNeighbor ("NE", map [hex.WorldXCoord, hex.WorldYCoord - 1]);
				} catch {

				}
				try {
					hex.setNeighbor ("E", map [hex.WorldXCoord + 1, hex.WorldYCoord]);
				} catch {

				}
				try {
					hex.setNeighbor ("SE", map [hex.WorldXCoord, hex.WorldYCoord + 1]);
				} catch {

				}
				try {
					hex.setNeighbor ("W", map [hex.WorldXCoord - 1, hex.WorldYCoord]);
				} catch {

				}
				try {
					hex.setNeighbor ("NW", map [hex.WorldXCoord - 1, hex.WorldYCoord - 1]);
				} catch {

				}
				try {
					hex.setNeighbor ("SW", map [hex.WorldXCoord - 1, hex.WorldYCoord + 1]);
				} catch {

				}



			}
		}
	}
}
