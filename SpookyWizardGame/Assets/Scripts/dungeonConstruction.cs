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
		if(compass[0] == false && x != (this.maxX-1))
			this.dungeon[x+1][z].setSouthExit(false);
		if(compass[1] == false && x != 0)
			this.dungeon[x-1][z].setNorthExit(false);
		if(compass[2] == false && z != 0)
			this.dungeon[x][z-1].setWestExit(false);
		if(compass[3] == false && z != (this.maxZ-1))
			this.dungeon[x][z+1].setEastExit(false);
	}
	
	public int getSetNeighbors(int x, int z){
		int setNeighbors = 0;
		if(x != (this.maxX-1))
			if(this.dungeon[x+1][z].getTileType() > 0)
				setNeighbors+=1;
		if(x != 0)
			if(this.dungeon[x-1][z].getTileType() > 0)
				setNeighbors+=1;
		if(z != 0)
			if(this.dungeon[x][z-1].getTileType() > 0)
				setNeighbors+=1;
		if(z != (this.maxZ-1))
			if(this.dungeon[x][z+1].getTileType() > 0)
				setNeighbors+=1;
        if (z != (this.maxZ - 1) && x != (this.maxX - 1))
            if (this.dungeon[x + 1][z + 1].getTileType() > 0)
                setNeighbors += 1;
        if (z != (this.maxZ - 1) && x != 0)
            if (this.dungeon[x - 1][z + 1].getTileType() > 0)
                setNeighbors += 1;
        if (z != 0 && x != (this.maxX - 1))
            if (this.dungeon[x + 1][z - 1].getTileType() > 0)
                setNeighbors += 1;
        if (z != 0 && x != 0)
            if (this.dungeon[x - 1][z - 1].getTileType() > 0)
                setNeighbors += 1;

        return setNeighbors;
	}

    public int getCornerNeighbors(int x, int z)
    {
        int cornerNeighbors = 0;

        if (z != (this.maxZ - 1) && x != (this.maxX - 1))
            if (this.dungeon[x + 1][z + 1].getTileType() > 0)
                cornerNeighbors += 1;
        if (z != (this.maxZ - 1) && x != 0)
            if (this.dungeon[x - 1][z + 1].getTileType() > 0)
                cornerNeighbors += 1;
        if (z != 0 && x != (this.maxX - 1))
            if (this.dungeon[x + 1][z - 1].getTileType() > 0)
                cornerNeighbors += 1;
        if (z != 0 && x != 0)
            if (this.dungeon[x - 1][z - 1].getTileType() > 0)
                cornerNeighbors += 1;

        return cornerNeighbors;
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
		bool[] compass = {false, false, false, false};
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
		}else if(type == 0){
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
    public GameObject[] artifacts = new GameObject[3];
    public GameObject floorTile;
    public GameObject bossRoomColliderTile;
    public GameObject ceilingTile;
	public GameObject cornerWall;
	public GameObject sideWallV;
	public GameObject sideWallH;
    public GameObject waterTrap;
    public GameObject slime;
    public GameObject boss;
    public GameObject bossDoor;
    public GameObject instantBossDoor;
    public GameObject healhPotion;
    public GameObject manaPotion;
    public GameObject bossNode;
    public GameObject finalBoss;
    public mapGrid dungeon;
	private int xGridSize;
	private int zGridSize;
    public GameObject[] nodeLayout = new GameObject[18];

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start Construction");
        xGridSize = difficultyOptions.xGrid;
        zGridSize = difficultyOptions.zGrid;
		dungeon = new mapGrid(xGridSize, zGridSize);
        setStartTiles();
        constructPerimeter();
        randomizeDungeon();
        generateDungeon();
        generateBossRoom();
        generateTraps();
        spawnArtifacts();
        //Uncomment this when the slimes are ready to go, guys
        spawnMonsters();
		nmSurface.BuildNavMesh();
    }

    // Update is called once per frame
    void Update()
    {  

    }

    public void closeDoor()
    {
        instantBossDoor.GetComponent<bDoorScript>().stopDoor();
        instantBossDoor.GetComponent<bDoorScript>().sealDoor();
        Destroy(GameObject.FindGameObjectWithTag("Boss"));
        Vector3 fbPos = new Vector3(((xGridSize + 1) * 10), 1, ((zGridSize - 1) * 10));
        Instantiate(finalBoss, fbPos, finalBoss.transform.rotation);
        Destroy(GameObject.FindGameObjectWithTag("killme"));
    }

    public void moveDoor()
    {
        Debug.Log("In Move Door");
        instantBossDoor.GetComponent<bDoorScript>().openDoor();
    }

    public void printDoorways(bool[] doorways)
    {
        Debug.Log("Printing Doorways:");
        Debug.Log("North: " + doorways[0]);
        Debug.Log("South: " + doorways[1]);
        Debug.Log("East: " + doorways[2]);
        Debug.Log("West: " + doorways[3]);
    }

    public void setStartTiles()
    {
        int[] typeChoices;
        int typeSet;
        typeChoices = new int[] { 3, 7, 8 };
        typeSet = setTile(typeChoices, 0, 0);
        dungeon.getTile(0, 0).setTileType(typeSet);
        typeChoices = new int[] { 1, 2, 3, 4, 11 };
        typeSet = setTile(typeChoices, xGridSize - 1, zGridSize - 1);
        dungeon.getTile(xGridSize - 1, zGridSize - 1).setTileType(typeSet);
        Debug.Log("Start Tiles Set");
    }

    public void spawnArtifacts()
    {
        Debug.Log("Spawning Items");
        int[] locs = {0, 0, 0};
        for(int spawner = 0; spawner < 3; spawner++)
        {
            int rX = Random.Range(0, xGridSize);
            while (rX == locs[0] || rX == locs[1] || rX == locs[2])
            {
                Debug.Log("Testing Locs");
                rX = Random.Range(0, xGridSize);
            }
            int rZ = Random.Range(0, zGridSize);
            Vector3 artifactPos = new Vector3((rX * 10), 1, (rZ * 10));
            switch (spawner)
            {
                case 0:
                    artifactPos = new Vector3((rX * 10), 2, (rZ * 10));
                    Instantiate(artifacts[0], artifactPos, artifacts[0].transform.rotation);
                    locs[0] = rX;
                    break;
                case 1:
                    Instantiate(artifacts[1], artifactPos, artifacts[1].transform.rotation);
                    locs[1] = rX;
                    break;
                case 2:
                    Instantiate(artifacts[2], artifactPos, artifacts[2].transform.rotation);
                    locs[2] = rX;
                    break;
                default:
                    break;
            }
        }
        
        int hpCount = (int)(xGridSize * .3f);
        int mpCount = (int)(xGridSize * .3f);
        while ((hpCount > 0) || (mpCount > 0))
        {
            int rX = Random.Range(0, xGridSize);
            int rZ = Random.Range(0, zGridSize);
            Vector3 potionPos = new Vector3((rX * 10), 1, (rZ * 10));
            int type = Random.Range(0, 2);
            if (hpCount > 0 && type == 0)
            {
                Instantiate(healhPotion, potionPos, healhPotion.transform.rotation);
                hpCount--;
            }
            if (mpCount > 0 && type == 1)
            {
                Instantiate(manaPotion, potionPos, manaPotion.transform.rotation);
                mpCount--;
            }
        }
    }
	
	public void generateDungeon(){
		int[] typeChoices;
		bool[] doorways;
		int typeSet;
		Debug.Log("Completed Randomizing. Generating...");
		for(int x = 0; x <= xGridSize-1; x+=1){
			for(int z = 0; z <= zGridSize-1; z+=1){
				if(dungeon.getTile(x, z).getTileType() == 0){
                    Debug.Log("Generator: Placing tile at: " + x + ", " + z);
                    doorways = dungeon.getTile(x, z).getCompass();
                    printDoorways(doorways);
                    typeChoices = getTypes(doorways);
                    typeSet = setTile(typeChoices, x, z);
                    dungeon.getTile(x, z).setTileType(typeSet);
                    dungeon.setDoorways(dungeon.getTile(x, z).getCompass(), x, z);
                }
                else
                {
                    Debug.Log("Generator: Tile already placed at: " + x + ", " + z);
                }
			}
		}
	}

    public void generateTraps() 
    {
        Debug.Log("Setting traps");
        int trapCount = (int)((xGridSize*zGridSize)*0.1);
        int trapsPlaced = 0;
        for (int x = 0; x <= xGridSize - 1; x += 1){
            for (int z = 0; z <= zGridSize - 1; z += 1){
                if(trapsPlaced < trapCount && Random.Range(1, 4) == 2)
                {
                    Vector3 trapPos = new Vector3((x * 10), 0, (z * 10));
                    Instantiate(waterTrap, trapPos, Quaternion.identity);
                    z += 2;
                    if (Random.Range(1, 4) == 1)
                        x += 1;
                }
            }
        }
    }

    public void generateBossRoom()
    {
        Debug.Log("Building Boss Room");
        int x = xGridSize;
        int z = zGridSize-1;

        Vector3 doorPos = new Vector3(((x - .77f) * 10), 2.5f, (z * 10));
        instantBossDoor = Instantiate(bossDoor, doorPos, bossDoor.transform.rotation);

        //Floor Tiles
        Vector3 tilePos = new Vector3((x * 10), 0, (z * 10));
        Instantiate(floorTile, tilePos, Quaternion.identity);
        Instantiate(bossRoomColliderTile, tilePos, Quaternion.identity);
        tilePos = new Vector3(((x + 1) * 10), 0, (z * 10));
        Instantiate(floorTile, tilePos, Quaternion.identity);
        tilePos = new Vector3(((x + 2) * 10), 0, (z * 10));
        Instantiate(floorTile, tilePos, Quaternion.identity);
        tilePos = new Vector3((x * 10), 0, ((z - 1) * 10));
        Instantiate(floorTile, tilePos, Quaternion.identity);
        tilePos = new Vector3((x * 10), 0, ((z - 2) * 10));
        Instantiate(floorTile, tilePos, Quaternion.identity);
        tilePos = new Vector3(((x + 1) * 10), 0, ((z - 1) * 10));
        Instantiate(floorTile, tilePos, Quaternion.identity);
        tilePos = new Vector3(((x + 2) * 10), 0, ((z - 1) * 10));
        Instantiate(floorTile, tilePos, Quaternion.identity);
        tilePos = new Vector3(((x + 1) * 10), 0, ((z - 2) * 10));
        Instantiate(floorTile, tilePos, Quaternion.identity);
        tilePos = new Vector3(((x + 2) * 10), 0, ((z - 2) * 10));
        Instantiate(floorTile, tilePos, Quaternion.identity);

        //Ceiling Tiles
        tilePos = new Vector3((x * 10), 5, (z * 10));
        Instantiate(ceilingTile, tilePos, Quaternion.identity);
        tilePos = new Vector3(((x + 1) * 10), 5, (z * 10));
        Instantiate(ceilingTile, tilePos, Quaternion.identity);
        tilePos = new Vector3(((x + 2) * 10), 5, (z * 10));
        Instantiate(ceilingTile, tilePos, Quaternion.identity);
        tilePos = new Vector3((x * 10), 5, ((z - 1) * 10));
        Instantiate(ceilingTile, tilePos, Quaternion.identity);
        tilePos = new Vector3((x * 10), 5, ((z - 2) * 10));
        Instantiate(ceilingTile, tilePos, Quaternion.identity);
        tilePos = new Vector3(((x + 1) * 10), 5, ((z - 1) * 10));
        Instantiate(ceilingTile, tilePos, Quaternion.identity);
        tilePos = new Vector3(((x + 2) * 10), 5, ((z - 1) * 10));
        Instantiate(ceilingTile, tilePos, Quaternion.identity);
        tilePos = new Vector3(((x + 1) * 10), 5, ((z - 2) * 10));
        Instantiate(ceilingTile, tilePos, Quaternion.identity);
        tilePos = new Vector3(((x + 2) * 10), 5, ((z - 2) * 10));
        Instantiate(ceilingTile, tilePos, Quaternion.identity);

        //Boss Nodes
        tilePos = new Vector3((x * 10), 1, (z * 10));
        nodeLayout[0] = (Instantiate(bossNode, tilePos, Quaternion.identity));
        tilePos = new Vector3(((x + 1) * 10), 1, (z * 10));
        nodeLayout[1] = (Instantiate(bossNode, tilePos, Quaternion.identity));
        tilePos = new Vector3(((x + 2) * 10), 1, (z * 10));
        nodeLayout[2] = (Instantiate(bossNode, tilePos, Quaternion.identity));
        tilePos = new Vector3((x * 10), 1, ((z - 1) * 10));
        nodeLayout[3] = (Instantiate(bossNode, tilePos, Quaternion.identity));
        tilePos = new Vector3((x * 10), 1, ((z - 2) * 10));
        nodeLayout[4] = (Instantiate(bossNode, tilePos, Quaternion.identity));
        tilePos = new Vector3(((x + 1) * 10), 1, ((z - 1) * 10));
        nodeLayout[5] = (Instantiate(bossNode, tilePos, Quaternion.identity));
        tilePos = new Vector3(((x + 2) * 10), 1, ((z - 1) * 10));
        nodeLayout[6] = (Instantiate(bossNode, tilePos, Quaternion.identity));
        tilePos = new Vector3(((x + 1) * 10), 1, ((z - 2) * 10));
        nodeLayout[7] = (Instantiate(bossNode, tilePos, Quaternion.identity));
        tilePos = new Vector3(((x + 2) * 10), 1, ((z - 2) * 10));
        nodeLayout[8] = (Instantiate(bossNode, tilePos, Quaternion.identity));
        tilePos = new Vector3((x * 10), 1, (z * 10));
        nodeLayout[9] = (Instantiate(bossNode, tilePos, Quaternion.identity));
        tilePos = new Vector3(((x + 1) * 10), 3, (z * 10));
        nodeLayout[10] = (Instantiate(bossNode, tilePos, Quaternion.identity));
        tilePos = new Vector3(((x + 2) * 10), 3, (z * 10));
        nodeLayout[11] = (Instantiate(bossNode, tilePos, Quaternion.identity));
        tilePos = new Vector3((x * 10), 3, ((z - 1) * 10));
        nodeLayout[12] = (Instantiate(bossNode, tilePos, Quaternion.identity));
        tilePos = new Vector3((x * 10), 3, ((z - 2) * 10));
        nodeLayout[13] = (Instantiate(bossNode, tilePos, Quaternion.identity));
        tilePos = new Vector3(((x + 1) * 10), 3, ((z - 1) * 10));
        nodeLayout[14] = (Instantiate(bossNode, tilePos, Quaternion.identity));
        tilePos = new Vector3(((x + 2) * 10), 3, ((z - 1) * 10));
        nodeLayout[15] = (Instantiate(bossNode, tilePos, Quaternion.identity));
        tilePos = new Vector3(((x + 1) * 10), 3, ((z - 2) * 10));
        nodeLayout[16] = (Instantiate(bossNode, tilePos, Quaternion.identity));
        tilePos = new Vector3(((x + 2) * 10), 3, ((z - 2) * 10));
        nodeLayout[17] = (Instantiate(bossNode, tilePos, Quaternion.identity));

        //Perimeter Walls
        float zNorthAdj = -3.5f + ((xGridSize + 3) * 10);
        float xWestAdj = -3.5f + (zGridSize * 10);
        for(int wallX = 0; wallX < 3; wallX++)
        {
            Vector3 posEastWall = new Vector3(((wallX + x) * 10), 2.5f, ((zGridSize*10 -30) - 6f));
            Vector3 posWestWall = new Vector3(((wallX + x) * 10), 2.5f, xWestAdj);
            Instantiate(sideWallV, posEastWall, sideWallV.transform.rotation);
            Instantiate(sideWallV, posWestWall, sideWallV.transform.rotation);
        }
        for(int wallZ = -2; wallZ < 1; wallZ++)
        {
            Vector3 posNorthWall = new Vector3(zNorthAdj, 2.5f, ((wallZ + z) * 10));
            Instantiate(sideWallH, posNorthWall, sideWallH.transform.rotation);
        }

    }

    /* Once the dungeon is finished generating, this function is run.
     * Takes no parameters, but does rely on the public slime GameObject.
     * Make sure the slime is correctly assigned to this script in the 
     * 'DungeonConstructor' script, attached to the 'DungeonMaster' object.
     */
    public void spawnMonsters()
    {
        int slimeCount = (int)(xGridSize*0.5);
        for(int sc = 0; sc < slimeCount; sc++)
        {
            int rX = Random.Range(0, xGridSize);
            int rZ = Random.Range(0, zGridSize);
            Vector3 slimePos = new Vector3((rX * 10), 0, (rZ * 10));
            Instantiate(slime, slimePos, slime.transform.rotation);
        }

        Vector3 bossPos = new Vector3(((xGridSize/2) * 10), 0, ((zGridSize/2) * 10));
        Instantiate(boss, bossPos, boss.transform.rotation);

    }
	
	public void constructPerimeter(){
        Debug.Log("Constructing Perimeter");
		for(int z = 0; z <= zGridSize-1; z++){
			float zNorthAdj = -3.5f + (xGridSize*10);
			Vector3 posSouthWall = new Vector3(-6f, 2.5f, (z*10));
			Vector3 posNorthWall = new Vector3(zNorthAdj, 2.5f, (z*10));
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
		bool[] doorways;
		int neighborSet;
        int typeSet;
        int rCount = (int)(((xGridSize*zGridSize)/2)) + (int)(zGridSize);
		if((xGridSize*zGridSize) <= 25)
			rCount = (int)(((xGridSize*zGridSize)/2) - ((int)(xGridSize)));
        Debug.Log("--------------************---------------");
		Debug.Log("Randomizing: " + rCount + " tiles.");
		int count = 0;
		int loopShield = rCount;
		while(count <= rCount){
			int randX = Random.Range(0, xGridSize);
			int randZ = Random.Range(0, zGridSize);
			if(dungeon.getTile(randX, randZ).getTileType() == 0){
				neighborSet = dungeon.getSetNeighbors(randX, randZ);
                if (neighborSet == 0){
                    Debug.Log("Random tile has 0 neighbors at: " + randX + ", " + randZ);
					loopShield = rCount;
					doorways = dungeon.getTile(randX, randZ).getCompass();
                    if(doorways[0] == true)
					    typeChoices = new int[] {2,3,4};
                    else if(doorways[1] == true)
                        typeChoices = new int[] {2,3,5};
                    else if(doorways[2] == true)
                        typeChoices = new int[] {2,4,5};
                    else if(doorways[3] == true)
                        typeChoices = new int[] {3,4,5};
                    else
                        typeChoices = new int[] {2,3,4,5};
                    typeSet = setTile(typeChoices, randX, randZ);
					dungeon.getTile(randX, randZ).setTileType(typeSet);
                    dungeon.setDoorways(dungeon.getTile(randX, randZ).getCompass(), randX, randZ);
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
        if (compass[0] == true){
			if(compass[1] == true){
				if(compass[2] == true){
					if(compass[3] == true){
						// All doorways available
						Debug.Log("All Doorways available on this tile");
						return avlTypes = new int[] {1};
					}else{
						//West doorway closed
						Debug.Log("West doorway closed on this tile.");
						return avlTypes = new int[] {2};
					}
				}else{
					if(compass[3] == true){
						//East doorway closed
						Debug.Log("East doorway closed on this tile.");
						return avlTypes = new int[] {3};
					}else{
						//East and West doorways closed
						Debug.Log("East and West doorways closed on this tile.");
						return avlTypes = new int[] {2,3,7};
					}				
				}
			}else{
				if(compass[2] == true){
					if(compass[3] == true){
						//South doorway closed
						Debug.Log("South doorway closed on this tile.");
						return avlTypes = new int[] {4};
					}else{
						//South and West doorway closed
						Debug.Log("South and West doorways closed on this tile.");
						return avlTypes = new int[] {2,4,11};
					}					
				}else{
					if(compass[3] == true){
						//South and East doorway closed
						Debug.Log("South and East doorways closed on this tile.");
						return avlTypes = new int[] {3,4,10};
					}else{
						//South, East, and West doorway closed
						Debug.Log("South, East, and West doorways closed on this tile.");
						return avlTypes = new int[] {2,3,4,7};
					}						
				}	
			}
		}else{
			if(compass[1] == true){
				if(compass[2] == true){
					if(compass[3] == true){
						//North doorway closed
						Debug.Log("North doorway closed on this tile.");
						return avlTypes = new int[] {5};
					}else{
						//North and West doorways closed
						Debug.Log("North and West doorways closed on this tile.");
						return avlTypes = new int[] {2,5,9};
					}
				}else{
					if(compass[3] == true){
						//North and East doorways closed
						Debug.Log("North and East doorways closed on this tile.");
						return avlTypes = new int[] {3,5,8};
					}else{
						//North, East, and West doorways closed
						Debug.Log("North, East, and West doorways closed on this tile.");
						return avlTypes = new int[] {2,3,5,7};
					}				
				}				
			}else{
				if(compass[2] == true){
					if(compass[3] == true){
						//North and South doorways closed
						Debug.Log("North and South doorways closed on this tile.");
						return avlTypes = new int[] {4,5,6};
					}else{
						//North, South, and West doorways closed
						Debug.Log("North, South, and West doorways closed on this tile.");
						return avlTypes = new int[] {2,4,5,6};
					}
				}else{
					if(compass[3] == true){
						//North, South, and East doorways closed
						Debug.Log("North, South, and East doorways closed on this tile.");
						return avlTypes = new int[] {3,4,5,6};
					}else{
						//All doorways closed
						Debug.Log("All doorways are closed on this tile.");
						return avlTypes = new int[] {0};
					}				
				}				
			}
		}
	}
	
	//Type 1: A tile going all 4 directions (intersection).
	public void placeTypeOne(int x, int z){
		Debug.Log("Placed Type 1 at: " + x + ", " + z);
		float zAdjPos = 3.5f + (z*10);
		float zAdjNeg = -3.5f + (z*10);
		float xAdjPos = 3.5f + (x*10);
		float xAdjNeg = -3.5f + (x*10);
		Vector3 pillarPosNE = new Vector3(xAdjPos, 2.5f, zAdjNeg);
		Vector3 pillarPosNW = new Vector3(xAdjPos, 2.5f, zAdjPos);
		Vector3 pillarPosSW = new Vector3(xAdjNeg, 2.5f, zAdjPos);
		Vector3 pillarPosSE = new Vector3(xAdjNeg, 2.5f, zAdjNeg);
		Vector3 tilePos = new Vector3((x*10), 0, (z*10));
        Vector3 ceilingPos = new Vector3((x * 10), 5, (z * 10));
        Instantiate(ceilingTile, ceilingPos, Quaternion.identity);
        Instantiate(floorTile, tilePos, Quaternion.identity);
		Instantiate(cornerWall, pillarPosNE, Quaternion.identity);
		Instantiate(cornerWall, pillarPosNW, Quaternion.identity);
		Instantiate(cornerWall, pillarPosSE, Quaternion.identity);
		Instantiate(cornerWall, pillarPosSW, Quaternion.identity);
	}
	
	//Type 2: A tile going south/north and east.
	public void placeTypeTwo(int x, int z){
		Debug.Log("Placed Type 2 at: " + x + ", " + z);
		float zAdjPos = 3.5f + (z*10);
		float zAdjNeg = -3.5f + (z*10);
		float xAdjPos = 3.5f + (x*10);
		float xAdjNeg = -3.5f + (x*10);
		Vector3 pillarPosNE = new Vector3(xAdjPos, 2.5f, zAdjNeg);
		Vector3 pillarPosSE = new Vector3(xAdjNeg, 2.5f, zAdjNeg);
		Vector3 wallPosW = new Vector3((x*10), 2.5f, zAdjPos);
		Vector3 tilePos = new Vector3((x*10), 0, (z*10));
        Vector3 ceilingPos = new Vector3((x * 10), 5, (z * 10));
        Instantiate(ceilingTile, ceilingPos, Quaternion.identity);
        Instantiate(floorTile, tilePos, Quaternion.identity);
		Instantiate(sideWallV, wallPosW, Quaternion.identity);
		Instantiate(cornerWall, pillarPosSE, Quaternion.identity);
		Instantiate(cornerWall, pillarPosNE, Quaternion.identity);
	}
	
	//Type 3: A tile going south/north and west.
	public void placeTypeThree(int x, int z){
		Debug.Log("Placed Type 3 at: " + x + ", " + z);
		float zAdjPos = 3.5f + (z*10);
		float zAdjNeg = -3.5f + (z*10);
		float xAdjPos = 3.5f + (x*10);
		float xAdjNeg = -3.5f + (x*10);
		Vector3 pillarPosNW = new Vector3(xAdjPos, 2.5f, zAdjPos);
		Vector3 pillarPosSW = new Vector3(xAdjNeg, 2.5f, zAdjPos);
		Vector3 wallPosE = new Vector3((x*10), 2.5f, zAdjNeg);
		Vector3 tilePos = new Vector3((x*10), 0, (z*10));
        Vector3 ceilingPos = new Vector3((x * 10), 5, (z * 10));
        Instantiate(ceilingTile, ceilingPos, Quaternion.identity);
        Instantiate(floorTile, tilePos, Quaternion.identity);
		Instantiate(sideWallV, wallPosE, Quaternion.identity);
		Instantiate(cornerWall, pillarPosSW, Quaternion.identity);
		Instantiate(cornerWall, pillarPosNW, Quaternion.identity);
	}
	
	//Type 4: A tile going east/west and north.
	public void placeTypeFour(int x, int z){
		Debug.Log("Placed Type 4 at: " + x + ", " + z);
		float zAdjPos = 3.5f + (z*10);
		float zAdjNeg = -3.5f + (z*10);
		float xAdjPos = 3.5f + (x*10);
		float xAdjNeg = -3.5f + (x*10);
		Vector3 pillarPosNE = new Vector3(xAdjPos, 2.5f, zAdjNeg);
		Vector3 pillarPosNW = new Vector3(xAdjPos, 2.5f, zAdjPos);
		Vector3 wallPosS = new Vector3(xAdjNeg, 2.5f, (z*10));
		Vector3 tilePos = new Vector3((x*10), 0, (z*10));
        Vector3 ceilingPos = new Vector3((x * 10), 5, (z * 10));
        Instantiate(ceilingTile, ceilingPos, Quaternion.identity);
        Instantiate(floorTile, tilePos, Quaternion.identity);
		Instantiate(sideWallH, wallPosS, sideWallH.transform.rotation);
		Instantiate(cornerWall, pillarPosNE, Quaternion.identity);
		Instantiate(cornerWall, pillarPosNW, Quaternion.identity);
	}

	//Type 5: A tile going east/west and south.
	public void placeTypeFive(int x, int z){
		Debug.Log("Placed Type 5 at: " + x + ", " + z);
		float zAdjPos = 3.5f + (z*10);
		float zAdjNeg = -3.5f + (z*10);
		float xAdjPos = 3.5f + (x*10);
		float xAdjNeg = -3.5f + (x*10);
		Vector3 pillarPosSW = new Vector3(xAdjNeg, 2.5f, zAdjPos);
		Vector3 pillarPosSE = new Vector3(xAdjNeg, 2.5f, zAdjNeg);
		Vector3 wallPosN = new Vector3(xAdjPos, 2.5f, (z*10));
		Vector3 tilePos = new Vector3((x*10), 0, (z*10));
        Vector3 ceilingPos = new Vector3((x * 10), 5, (z * 10));
        Instantiate(ceilingTile, ceilingPos, Quaternion.identity);
        Instantiate(floorTile, tilePos, Quaternion.identity);
		Instantiate(sideWallH, wallPosN, sideWallH.transform.rotation);
		Instantiate(cornerWall, pillarPosSE, Quaternion.identity);
		Instantiate(cornerWall, pillarPosSW, Quaternion.identity);
	}
	
	//Type 6: A tile going east/west.
	public void placeTypeSix(int x, int z){
		Debug.Log("Placed Type 6 at: " + x + ", " + z);
		float xAdjPos = 3.5f + (x*10);
		float xAdjNeg = -3.5f + (x*10);
		Vector3 wallPosN = new Vector3(xAdjPos, 2.5f, (z*10));
		Vector3 wallPosS = new Vector3(xAdjNeg, 2.5f, (z*10));
		Vector3 tilePos = new Vector3((x*10), 0, (z*10));
        Vector3 ceilingPos = new Vector3((x * 10), 5, (z * 10));
        Instantiate(ceilingTile, ceilingPos, Quaternion.identity);
        Instantiate(floorTile, tilePos, Quaternion.identity);
		Instantiate(sideWallH, wallPosN, sideWallH.transform.rotation);
		Instantiate(sideWallH, wallPosS, sideWallH.transform.rotation);
	}
	
	//Type 7: A tile going north/south.
	public void placeTypeSeven(int x, int z){
		Debug.Log("Placed Type 7 at: " + x + ", " + z);
		float zAdjPos = 3.5f + (z*10);
		float zAdjNeg = -3.5f + (z*10);
		Vector3 wallPosW = new Vector3((x*10), 2.5f, zAdjPos);
		Vector3 wallPosE = new Vector3((x*10), 2.5f, zAdjNeg);
		Vector3 tilePos = new Vector3((x*10), 0, (z*10));
        Vector3 ceilingPos = new Vector3((x * 10), 5, (z * 10));
        Instantiate(ceilingTile, ceilingPos, Quaternion.identity);
        Instantiate(floorTile, tilePos, Quaternion.identity);
		Instantiate(sideWallV, wallPosE, Quaternion.identity);
		Instantiate(sideWallV, wallPosW, Quaternion.identity);
	}
	
	//Type 8: A 90 degree tile going south and west.`
	public void placeTypeEight(int x, int z){
		Debug.Log("Placed Type 8 at: " + x + ", " + z);
		float zAdjPos = 3.5f + (z*10);
		float zAdjNeg = -3.5f + (z*10);
		float xAdjPos = 3.5f + (x*10);
		float xAdjNeg = -3.5f + (x*10);
		Vector3 wallPosN = new Vector3(xAdjPos, 2.5f, (z*10));
		Vector3 pillarPosSW = new Vector3(xAdjNeg, 2.5f, zAdjPos);
		Vector3 wallPosE = new Vector3((x*10), 2.5f, zAdjNeg);
		Vector3 tilePos = new Vector3((x*10), 0, (z*10));
        Vector3 ceilingPos = new Vector3((x * 10), 5, (z * 10));
        Instantiate(ceilingTile, ceilingPos, Quaternion.identity);
        Instantiate(floorTile, tilePos, Quaternion.identity);
		Instantiate(sideWallV, wallPosE, Quaternion.identity);
		Instantiate(sideWallH, wallPosN, sideWallH.transform.rotation);
		Instantiate(cornerWall, pillarPosSW, Quaternion.identity);
	}
	
	//Type 9: A 90 degree tile going south and east.
	public void placeTypeNine(int x, int z){
		Debug.Log("Placed Type 9 at: " + x + ", " + z);
		float zAdjPos = 3.5f + (z*10);
		float zAdjNeg = -3.5f + (z*10);
		float xAdjPos = 3.5f + (x*10);
		float xAdjNeg = -3.5f + (x*10);
		Vector3 wallPosN = new Vector3(xAdjPos, 2.5f, (z*10));
		Vector3 wallPosW = new Vector3((x*10), 2.5f, zAdjPos);
		Vector3 pillarPosSE = new Vector3(xAdjNeg, 2.5f, zAdjNeg);
		Vector3 tilePos = new Vector3((x*10), 0, (z*10));
        Vector3 ceilingPos = new Vector3((x * 10), 5, (z * 10));
        Instantiate(ceilingTile, ceilingPos, Quaternion.identity);
        Instantiate(floorTile, tilePos, Quaternion.identity);
		Instantiate(sideWallH, wallPosN, sideWallH.transform.rotation);
		Instantiate(sideWallV, wallPosW, Quaternion.identity);
		Instantiate(cornerWall, pillarPosSE, Quaternion.identity);
	}
	
	//Type 10: A 90 degree tile going north and west.
	public void placeTypeTen(int x, int z){
		Debug.Log("Placed Type 10 at: " + x + ", " + z);
		float zAdjPos = 3.5f + (z*10);
		float zAdjNeg = -3.5f + (z*10);
		float xAdjPos = 3.5f + (x*10);
		float xAdjNeg = -3.5f + (x*10);
		Vector3 pillarPosNW = new Vector3(xAdjPos, 2.5f, zAdjPos);
		Vector3 wallPosE = new Vector3((x*10), 2.5f, zAdjNeg);
		Vector3 wallPosS = new Vector3(xAdjNeg, 2.5f, (z*10));
		Vector3 tilePos = new Vector3((x*10), 0, (z*10));
        Vector3 ceilingPos = new Vector3((x * 10), 5, (z * 10));
        Instantiate(ceilingTile, ceilingPos, Quaternion.identity);
        Instantiate(floorTile, tilePos, Quaternion.identity);
		Instantiate(cornerWall, pillarPosNW, Quaternion.identity);
		Instantiate(sideWallV, wallPosE, Quaternion.identity);
		Instantiate(sideWallH, wallPosS, sideWallH.transform.rotation);
	}
	
	//Type 11: A 90 degree tile going north and east.
	public void placeTypeEleven(int x, int z){
		Debug.Log("Placed Type 11 at: " + x + ", " + z);
		float zAdjPos = 3.5f + (z*10);
		float zAdjNeg = -3.5f + (z*10);
		float xAdjPos = 3.5f + (x*10);
		float xAdjNeg = -3.5f + (x*10);
		Vector3 wallPosS = new Vector3(xAdjNeg, 2.5f, (z*10));
		Vector3 wallPosW = new Vector3((x*10), 2.5f, zAdjPos);
		Vector3 pillarPosNE = new Vector3(xAdjPos, 2.5f, zAdjNeg);
		Vector3 tilePos = new Vector3((x*10), 0, (z*10));
        Vector3 ceilingPos = new Vector3((x * 10), 5, (z * 10));
        Instantiate(ceilingTile, ceilingPos, Quaternion.identity);
        Instantiate(floorTile, tilePos, Quaternion.identity);
		Instantiate(sideWallH, wallPosS, sideWallH.transform.rotation);
		Instantiate(cornerWall, pillarPosNE, Quaternion.identity);
		Instantiate(sideWallV, wallPosW, Quaternion.identity);
	}
}
