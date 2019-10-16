using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class mapGrid
{
	mapTile [][] dungeon;
	int maxX;
	int maxZ;
	
	public mapGrid(int x, int z){
		this.maxX = x;
		this.maxZ = z;
		Debug.Log("Max X: " + this.maxX + " | Max Z: " + this.maxZ);
		this.dungeon = new mapTile[this.maxX][];
		for(int indexX = 0; indexX <= this.maxX-1; indexX+=1){
			Debug.Log("Added X: " + indexX + " of size: " + maxZ);
			dungeon[indexX] = new mapTile[maxZ];
			for(int indexZ = 0; indexZ <= this.maxZ-1; indexZ+=1){
				Debug.Log("Added Z: " + indexZ);
				mapTile temp = new mapTile(x, z, 0);
				this.dungeon[indexX][indexZ] = temp;
			}
		}
		initializeDungeon();
	}
	
	public void initializeDungeon(){
		for(int x = 0; x <= this.maxX-1; x++){
			for(int z = 0; z <= this.maxZ-1; z++){
				this.dungeon[x][z] = new mapTile(x, z, 0);
				if(x == 0)
					this.dungeon[x][z].setSouthExit(false);
				if(x == this.maxX-1)
					this.dungeon[x][z].setNorthExit(false);
				if(z == 0)
					this.dungeon[x][z].setEastExit(false);
				if(z == this.maxZ-1)
					this.dungeon[x][z].setWestExit(false);
				if(x == 0 && z == 0)
					this.dungeon[x][z].setSouthExit(true);
				if(x == this.maxX && z == this.maxZ)
					this.dungeon[x][z].setNorthExit(true);
			}
		}
		Debug.Log("Dungeon Initialized!");
	}
	
	public mapTile getTile(int x, int z){
		return this.dungeon[x][z];
	}
	
	public void setDoorways(bool[] compass, int x, int z){
		//0: North | false: Closed, true: Open
		//1: South | false: Closed, true: Open
		//2: East | false: Closed, true: Open
		//3: West | false: Closed, true: Open
		if(compass[0] == false && x != this.maxX)
			this.dungeon[x+1][z].setNorthExit(false);
		if(compass[1] == false && x != 0)
			this.dungeon[x-1][z].setSouthExit(false);
		if(compass[2] == false && z != 0)
			this.dungeon[x][z-1].setEastExit(false);
		if(compass[3] == false && z != this.maxZ)
			this.dungeon[x][z+1].setWestExit(false);
	}
}

public class mapTile
{
	int xCoor;
	int zCoor;
	int tileType;
	bool northExit;
	bool southExit;
	bool eastExit;
	bool westExit;
	
	public mapTile(int x, int z, int type){
		this.xCoor = x;
		this.zCoor = z;
		this.tileType = type; //0 means uninitialized. i.e. no tile has been placed yet.
		this.northExit = true; //true means it has a doorway going north
		this.southExit = true; //true means it has a doorway going south
		this.eastExit = true; //true means it has a doorway going east
		this.westExit = true; //true means it has a doorway going west
	}
	
	public bool[] getCompass(){
		bool[] compass = {true, true, true, true};
		compass[0] = this.northExit;
		compass[1] = this.southExit;
		compass[2] = this.eastExit;
		compass[3] = this.westExit;
		return compass;
	}
	
	public int getZCoor(){
		return this.zCoor;
	}
	public int getXCoor(){
		return this.xCoor;
	}
	public bool getNorthExit(){
		return this.northExit;
	}
	public void setNorthExit(bool doorway){
		this.northExit = doorway;
	}
	public bool getSouthExit(){
		return this.southExit;
	}
	public void setSouthExit(bool doorway){
		this.southExit = doorway;
	}
	public bool getEastExit(){
		return this.eastExit;
	}
	public void setEastExit(bool doorway){
		this.eastExit = doorway;
	}
	public bool getWestExit(){
		return this.westExit;
	}
	public void setWestExit(bool doorway){
		this.westExit = doorway;
	}
	public int getTileType(){
		return this.tileType;
	}
	public void setTileType(int type){
		this.tileType = type;
		if(type == 1){
			this.setNorthExit(true);
			this.setSouthExit(true);
			this.setEastExit(true);
			this.setWestExit(true);
		}else if(type == 2){
			this.setNorthExit(true);
			this.setSouthExit(true);
			this.setEastExit(true);
			this.setWestExit(false);
		}else if(type == 3){
			this.setNorthExit(true);
			this.setSouthExit(true);
			this.setEastExit(false);
			this.setWestExit(true);
		}else if(type == 4){
			this.setNorthExit(true);
			this.setSouthExit(false);
			this.setEastExit(true);
			this.setWestExit(true);
		}else if(type == 5){
			this.setNorthExit(false);
			this.setSouthExit(true);
			this.setEastExit(true);
			this.setWestExit(true);
		}else if(type == 6){
			this.setNorthExit(false);
			this.setSouthExit(false);
			this.setEastExit(true);
			this.setWestExit(true);
		}else if(type == 7){
			this.setNorthExit(true);
			this.setSouthExit(true);
			this.setEastExit(false);
			this.setWestExit(false);
		}else if(type == 8){
			this.setNorthExit(false);
			this.setSouthExit(true);
			this.setEastExit(false);
			this.setWestExit(true);
		}else if(type == 9){
			this.setNorthExit(false);
			this.setSouthExit(true);
			this.setEastExit(true);
			this.setWestExit(false);
		}else if(type == 10){
			this.setNorthExit(true);
			this.setSouthExit(false);
			this.setEastExit(false);
			this.setWestExit(true);
		}else if(type == 11){
			this.setNorthExit(true);
			this.setSouthExit(false);
			this.setEastExit(true);
			this.setWestExit(false);
		}else if(type == -1){
			this.setNorthExit(false);
			this.setSouthExit(false);
			this.setEastExit(false);
			this.setWestExit(false);
		}
	}
}

public class dungeonConstruction : MonoBehaviour
{
	
	public NavMeshSurface nmSurface;
	
	public GameObject floorTile;
	public GameObject cornerWall;
	public GameObject sideWallV;
	public GameObject sideWallH;
	public mapGrid dungeon;
	public int xGridSize;
	public int zGridSize;
	
    // Start is called before the first frame update
    void Start()
    {
		dungeon = new mapGrid(xGridSize, zGridSize);
		generateDungeon();
		
		//Update NavMesh
		nmSurface.BuildNavMesh();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	public void generateDungeon(){
		int[] typeChoices;
		bool[] doorways;
		int typeSet;
		constructPerimeter();
		randomizeDungeon();
		for(int x = 0; x <= xGridSize-1; x++){
			for(int z = 0; z <= zGridSize-1; z++){
				if(x == 0 && z ==0){
					Debug.Log("Placing start tile");
					typeChoices = new int[] {3,7,8};
					typeSet = setTile(typeChoices, x, z);
					dungeon.getTile(x, z).setTileType(typeSet);				
				}else if(x == (xGridSize-1) && z == (zGridSize-1)){
					Debug.Log("Placing end tile");
					typeChoices = new int[] {1};
					typeSet = setTile(typeChoices, x, z);
					dungeon.getTile(x, z).setTileType(typeSet);							
				}else if(dungeon.getTile(x, z).getTileType() == 0){
					Debug.Log("Placing tile at: (" + x + ", " + z + ")");
					doorways = dungeon.getTile(x, z).getCompass();
					typeChoices = getTypes(doorways);
					typeSet = setTile(typeChoices, x, z);
					dungeon.getTile(x, z).setTileType(typeSet);
				}
			}
		}
	}
	
	public void constructPerimeter(){
		for(int z = 0; z <= zGridSize-1; z++){
			float zNorthAdj = -3.5f + (xGridSize*10);
			Vector3 posSouthWall = new Vector3(-6f, 2.5f, (z*10));
			Vector3 posNorthWall = new Vector3(zNorthAdj, 0.25f, (z*10));
			if(z != 0)
				Instantiate(sideWallH, posSouthWall, sideWallH.transform.rotation);
			if(z != (zGridSize-1))
				Instantiate(sideWallH, posNorthWall, sideWallH.transform.rotation);
		}
		for(int x = 0; x <= xGridSize-1; x++){
			float xWestAdj = -3.5f + (zGridSize*10);
			Vector3 posEastWall = new Vector3((x*10), 2.5f, -6f);
			Vector3 posWestWall = new Vector3((x*10), 2.5f, xWestAdj);
			Instantiate(sideWallV, posEastWall, sideWallV.transform.rotation);
			Instantiate(sideWallV, posWestWall, sideWallV.transform.rotation);
		}
	}
	
	public void randomizeDungeon(){
		int[] typeChoices;
		int rCount = (int)(((xGridSize*zGridSize)/2) + ((int)(xGridSize/3)));
		if((xGridSize*zGridSize) <= 25)
			rCount = (int)(((xGridSize*zGridSize)/2) - ((int)(xGridSize)));
		Debug.Log("Randomizing: " + rCount + " tiles.");
		int count = 0;
		int typeSet;
		int loopShield = rCount;
		while(count <= rCount){
			int randX = Random.Range(0, xGridSize);
			int randZ = Random.Range(0, zGridSize);
			if(dungeon.getTile(randX, randZ).getTileType() == 0){
				if((randX != 0 && randZ != 0) && (randX != (xGridSize-1) && randZ != (zGridSize-1))){
					loopShield = rCount;
					typeChoices = new int[] {2,3,4,5,6,7,8,9,10,11};
					typeSet = setTile(typeChoices, randX, randZ);
					dungeon.getTile(randX, randZ).setTileType(typeSet);
					count+=1;
				}
			}
			loopShield-=1;
			if(loopShield <= 0)
				return;
		}
	}
	
	public int setTile(int[] avlTypes, int x, int z){
		int choices = avlTypes.Length;
		int chosenType;
		if(choices == 1){
			if(avlTypes[0] == 1){
				placeTypeOne(x, z);
				return 1;
			}else if(avlTypes[0] == 0){
				return 0;
			}
		}
		
		chosenType = avlTypes[Random.Range(0, choices)];
		switch(chosenType)
		{
			case 1:
				placeTypeOne(x, z);
				return 1;
			case 2:
				placeTypeTwo(x, z);
				return 2;
			case 3:
				placeTypeThree(x, z);
				return 3;
			case 4:
				placeTypeFour(x, z);
				return 4;
			case 5:
				placeTypeFive(x, z);
				return 5;
			case 6:
				placeTypeSix(x, z);
				return 6;
			case 7:
				placeTypeSeven(x, z);
				return 7;
			case 8:
				placeTypeEight(x, z);
				return 8;
			case 9:
				placeTypeNine(x, z);
				return 9;
			case 10:
				placeTypeTen(x, z);
				return 10;
			case 11:
				placeTypeEleven(x, z);
				return 11;
			default:
				return -1;
		}
	}
	
	public int[] getTypes(bool[] compass){
		int[] avlTypes;
		if(compass[0] == true){
			if(compass[1] == true){
				if(compass[2] == true){
					if(compass[3] == true){
						// All doorways available
						return avlTypes = new int[] {1};
					}else{
						//West doorway closed
						return avlTypes = new int[] {1,2};
					}
				}else{
					if(compass[3] == true){
						//East doorway closed
						return avlTypes = new int[] {1,3};
					}else{
						//East and West doorways closed
						return avlTypes = new int[] {1,2,3,7};
					}				
				}
			}else{
				if(compass[2] == true){
					if(compass[3] == true){
						//South doorway closed
						return avlTypes = new int[] {1,4};
					}else{
						//South and West doorway closed
						return avlTypes = new int[] {1,2,4,11};
					}					
				}else{
					if(compass[3] == true){
						//South and East doorway closed
						return avlTypes = new int[] {1,3,4,10};
					}else{
						//South, East, and West doorway closed
						return avlTypes = new int[] {1,2,3,4,7,10,11};
					}						
				}	
			}
		}else{
			if(compass[1] == true){
				if(compass[2] == true){
					if(compass[3] == true){
						//North doorway closed
						return avlTypes = new int[] {1,5};
					}else{
						//North and West doorways closed
						return avlTypes = new int[] {1,2,5,9};
					}
				}else{
					if(compass[3] == true){
						//North and East doorways closed
						return avlTypes = new int[] {1,3,5,8};
					}else{
						//North, East, and West doorways closed
						return avlTypes = new int[] {1,2,3,5,7,8,9};
					}				
				}				
			}else{
				if(compass[2] == true){
					if(compass[3] == true){
						//North and South doorways closed
						return avlTypes = new int[] {1,4,5,6};
					}else{
						//North, South, and West doorways closed
						return avlTypes = new int[] {1,2,4,5,6,9,11};
					}
				}else{
					if(compass[3] == true){
						//North, South, and East doorways closed
						return avlTypes = new int[] {1,3,4,5,6,8,10};
					}else{
						//All doorways closed
						return avlTypes = new int[] {0};
					}				
				}				
			}
		}
	}
	
	//Type 1: A tile going all 4 directions (intersection).
	public void placeTypeOne(int x, int z){
		Debug.Log("Placed Type 1");
		float zAdjPos = 3.5f + (z*10);
		float zAdjNeg = -3.5f + (z*10);
		float xAdjPos = 3.5f + (x*10);
		float xAdjNeg = -3.5f + (x*10);
		Vector3 pillarPosNE = new Vector3(xAdjPos, 2.5f, zAdjNeg);
		Vector3 pillarPosNW = new Vector3(xAdjPos, 2.5f, zAdjPos);
		Vector3 pillarPosSW = new Vector3(xAdjNeg, 2.5f, zAdjPos);
		Vector3 pillarPosSE = new Vector3(xAdjNeg, 2.5f, zAdjNeg);
		Vector3 tilePos = new Vector3((x*10), 0, (z*10));
		Instantiate(floorTile, tilePos, Quaternion.identity);
		Instantiate(cornerWall, pillarPosNE, Quaternion.identity);
		Instantiate(cornerWall, pillarPosNW, Quaternion.identity);
		Instantiate(cornerWall, pillarPosSE, Quaternion.identity);
		Instantiate(cornerWall, pillarPosSW, Quaternion.identity);
	}
	
	//Type 2: A tile going south/north and east.
	public void placeTypeTwo(int x, int z){
		Debug.Log("Placed Type 2");
		float zAdjPos = 3.5f + (z*10);
		float zAdjNeg = -3.5f + (z*10);
		float xAdjPos = 3.5f + (x*10);
		float xAdjNeg = -3.5f + (x*10);
		Vector3 pillarPosNE = new Vector3(xAdjPos, 2.5f, zAdjNeg);
		Vector3 pillarPosSE = new Vector3(xAdjNeg, 2.5f, zAdjNeg);
		Vector3 wallPosW = new Vector3((x*10), 2.5f, zAdjPos);
		Vector3 tilePos = new Vector3((x*10), 0, (z*10));
		Instantiate(floorTile, tilePos, Quaternion.identity);
		Instantiate(sideWallV, wallPosW, Quaternion.identity);
		Instantiate(cornerWall, pillarPosSE, Quaternion.identity);
		Instantiate(cornerWall, pillarPosNE, Quaternion.identity);
	}
	
	//Type 3: A tile going south/north and west.
	public void placeTypeThree(int x, int z){
		Debug.Log("Placed Type 3");
		float zAdjPos = 3.5f + (z*10);
		float zAdjNeg = -3.5f + (z*10);
		float xAdjPos = 3.5f + (x*10);
		float xAdjNeg = -3.5f + (x*10);
		Vector3 pillarPosNW = new Vector3(xAdjPos, 2.5f, zAdjPos);
		Vector3 pillarPosSW = new Vector3(xAdjNeg, 2.5f, zAdjPos);
		Vector3 wallPosE = new Vector3((x*10), 2.5f, zAdjNeg);
		Vector3 tilePos = new Vector3((x*10), 0, (z*10));
		Instantiate(floorTile, tilePos, Quaternion.identity);
		Instantiate(sideWallV, wallPosE, Quaternion.identity);
		Instantiate(cornerWall, pillarPosSW, Quaternion.identity);
		Instantiate(cornerWall, pillarPosNW, Quaternion.identity);
	}
	
	//Type 4: A tile going east/west and north.
	public void placeTypeFour(int x, int z){
		Debug.Log("Placed Type 4");
		float zAdjPos = 3.5f + (z*10);
		float zAdjNeg = -3.5f + (z*10);
		float xAdjPos = 3.5f + (x*10);
		float xAdjNeg = -3.5f + (x*10);
		Vector3 pillarPosNE = new Vector3(xAdjPos, 2.5f, zAdjNeg);
		Vector3 pillarPosNW = new Vector3(xAdjPos, 2.5f, zAdjPos);
		Vector3 wallPosS = new Vector3(xAdjNeg, 2.5f, (z*10));
		Vector3 tilePos = new Vector3((x*10), 0, (z*10));
		Instantiate(floorTile, tilePos, Quaternion.identity);
		Instantiate(sideWallH, wallPosS, sideWallH.transform.rotation);
		Instantiate(cornerWall, pillarPosNE, Quaternion.identity);
		Instantiate(cornerWall, pillarPosNW, Quaternion.identity);
	}

	//Type 5: A tile going east/west and south.
	public void placeTypeFive(int x, int z){
		Debug.Log("Placed Type 5");
		float zAdjPos = 3.5f + (z*10);
		float zAdjNeg = -3.5f + (z*10);
		float xAdjPos = 3.5f + (x*10);
		float xAdjNeg = -3.5f + (x*10);
		Vector3 pillarPosSW = new Vector3(xAdjNeg, 2.5f, zAdjPos);
		Vector3 pillarPosSE = new Vector3(xAdjNeg, 2.5f, zAdjNeg);
		Vector3 wallPosN = new Vector3(xAdjPos, 2.5f, (z*10));
		Vector3 tilePos = new Vector3((x*10), 0, (z*10));
		Instantiate(floorTile, tilePos, Quaternion.identity);
		Instantiate(sideWallH, wallPosN, sideWallH.transform.rotation);
		Instantiate(cornerWall, pillarPosSE, Quaternion.identity);
		Instantiate(cornerWall, pillarPosSW, Quaternion.identity);
	}
	
	//Type 6: A tile going east/west.
	public void placeTypeSix(int x, int z){
		Debug.Log("Placed Type 6");
		float zAdjPos = 3.5f + (z*10);
		float zAdjNeg = -3.5f + (z*10);
		float xAdjPos = 3.5f + (x*10);
		float xAdjNeg = -3.5f + (x*10);
		Vector3 wallPosN = new Vector3(xAdjPos, 2.5f, (z*10));
		Vector3 wallPosS = new Vector3(xAdjNeg, 2.5f, (z*10));
		Vector3 tilePos = new Vector3((x*10), 0, (z*10));
		Instantiate(floorTile, tilePos, Quaternion.identity);
		Instantiate(sideWallH, wallPosN, sideWallH.transform.rotation);
		Instantiate(sideWallH, wallPosS, sideWallH.transform.rotation);
	}
	
	//Type 7: A tile going north/south.
	public void placeTypeSeven(int x, int z){
		Debug.Log("Placed Type 7");
		float zAdjPos = 3.5f + (z*10);
		float zAdjNeg = -3.5f + (z*10);
		float xAdjPos = 3.5f + (x*10);
		float xAdjNeg = -3.5f + (x*10);
		Vector3 wallPosW = new Vector3((x*10), 2.5f, zAdjPos);
		Vector3 wallPosE = new Vector3((x*10), 2.5f, zAdjNeg);
		Vector3 tilePos = new Vector3((x*10), 0, (z*10));
		Instantiate(floorTile, tilePos, Quaternion.identity);
		Instantiate(sideWallV, wallPosE, Quaternion.identity);
		Instantiate(sideWallV, wallPosW, Quaternion.identity);
	}
	
	//Type 8: A 90 degree tile going south and west.`
	public void placeTypeEight(int x, int z){
		Debug.Log("Placed Type 8");
		float zAdjPos = 3.5f + (z*10);
		float zAdjNeg = -3.5f + (z*10);
		float xAdjPos = 3.5f + (x*10);
		float xAdjNeg = -3.5f + (x*10);
		Vector3 wallPosN = new Vector3(xAdjPos, 2.5f, z);
		Vector3 pillarPosSW = new Vector3(xAdjNeg, 2.5f, zAdjPos);
		Vector3 wallPosE = new Vector3((x*10), 2.5f, zAdjNeg);
		Vector3 tilePos = new Vector3((x*10), 0, (z*10));
		Instantiate(floorTile, tilePos, Quaternion.identity);
		Instantiate(sideWallV, wallPosE, Quaternion.identity);
		Instantiate(sideWallH, wallPosN, sideWallH.transform.rotation);
		Instantiate(cornerWall, pillarPosSW, Quaternion.identity);
	}
	
	//Type 9: A 90 degree tile going south and east.
	public void placeTypeNine(int x, int z){
		Debug.Log("Placed Type 9");
		float zAdjPos = 3.5f + (z*10);
		float zAdjNeg = -3.5f + (z*10);
		float xAdjPos = 3.5f + (x*10);
		float xAdjNeg = -3.5f + (x*10);
		Vector3 wallPosN = new Vector3(xAdjPos, 2.5f, z);
		Vector3 wallPosW = new Vector3((x*10), 2.5f, zAdjPos);
		Vector3 pillarPosSE = new Vector3(xAdjNeg, 2.5f, zAdjNeg);
		Vector3 tilePos = new Vector3((x*10), 0, (z*10));
		Instantiate(floorTile, tilePos, Quaternion.identity);
		Instantiate(sideWallH, wallPosN, sideWallH.transform.rotation);
		Instantiate(sideWallV, wallPosW, Quaternion.identity);
		Instantiate(cornerWall, pillarPosSE, Quaternion.identity);
	}
	
	//Type 10: A 90 degree tile going north and west.
	public void placeTypeTen(int x, int z){
		Debug.Log("Placed Type 10");
		float zAdjPos = 3.5f + (z*10);
		float zAdjNeg = -3.5f + (z*10);
		float xAdjPos = 3.5f + (x*10);
		float xAdjNeg = -3.5f + (x*10);
		Vector3 pillarPosNW = new Vector3(xAdjPos, 2.5f, zAdjPos);
		Vector3 wallPosE = new Vector3((x*10), 2.5f, zAdjNeg);
		Vector3 wallPosS = new Vector3(xAdjNeg, 2.5f, (z*10));
		Vector3 tilePos = new Vector3((x*10), 0, (z*10));
		Instantiate(floorTile, tilePos, Quaternion.identity);
		Instantiate(cornerWall, pillarPosNW, Quaternion.identity);
		Instantiate(sideWallV, wallPosE, Quaternion.identity);
		Instantiate(sideWallH, wallPosS, sideWallH.transform.rotation);
	}
	
	//Type 11: A 90 degree tile going north and east.
	public void placeTypeEleven(int x, int z){
		Debug.Log("Placed Type 11");
		float zAdjPos = 3.5f + (z*10);
		float zAdjNeg = -3.5f + (z*10);
		float xAdjPos = 3.5f + (x*10);
		float xAdjNeg = -3.5f + (x*10);
		Vector3 wallPosS = new Vector3(xAdjNeg, 2.5f, (z*10));
		Vector3 wallPosW = new Vector3((x*10), 2.5f, zAdjPos);
		Vector3 pillarPosNE = new Vector3(xAdjPos, 2.5f, zAdjNeg);
		Vector3 tilePos = new Vector3((x*10), 0, (z*10));
		Instantiate(floorTile, tilePos, Quaternion.identity);
		Instantiate(sideWallH, wallPosS, sideWallH.transform.rotation);
		Instantiate(cornerWall, pillarPosNE, Quaternion.identity);
		Instantiate(sideWallV, wallPosW, Quaternion.identity);
	}
}
