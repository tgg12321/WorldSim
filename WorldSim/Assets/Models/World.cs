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

				map[x, y] = new HexTile(x,y,xPos, y*yOffset);

			}
		}

	}
	







}
