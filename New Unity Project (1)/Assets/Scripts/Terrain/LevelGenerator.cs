using System;
using System.Collections.Specialized;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] public Transform hexPrefab;
    public float gap = 0.0f;
    public int numLevels;
    public int levelRadius;
    public int levelHeight;

    public float hexWidth = 2.0f;
    public float hexHeight = 2.0f;

    Vector3 startPos;

    void Start() 
    {
        AddGap();
        CalcStartPos();
        CreateArena();
        MoveDeathBox();
    }

    void AddGap() 
    {
        hexWidth += hexWidth * gap;
        hexHeight += hexHeight * gap;
    }
    void CalcStartPos() 
    {
        int gridWidth = (levelRadius * 2) + 1;
        int gridHeight = gridWidth;
        float offset = 0;
        if (gridHeight / 2 % 2 != 0) 
        {
            offset = hexWidth / 2;
        }

        float x = -hexWidth * (gridWidth / 2) - offset;
        float z = hexHeight * .75f * (gridHeight / 2);

        startPos = new Vector3(x, 0, z);
    }
    Vector3 CalcWorldPos(Vector2 gridPos, int level, int additionalOffset) 
    {
        float offset = 0;
        if (gridPos.y % 2 != 0) 
        {
            offset = hexWidth / 2; 
        }

        float x = startPos.x + gridPos.x * hexWidth + offset + ((hexWidth) * additionalOffset);
        float z = startPos.z - gridPos.y * hexHeight * 0.75f;

        return new Vector3(x, level * -levelHeight, z);
    }

    void CreateArena() 
    {
        for (int i = 0; i < numLevels; i++) 
        {
            CreateHexGrid(i);
        }
    }

    void CreateHexGrid(int level)
    {
        int numRows = (levelRadius * 2) + 1;
        for (int y = -levelRadius; y <= levelRadius; y++) 
        {
            int numHexes = numRows - Math.Abs(y);
            int offset = (int)Math.Floor((double)Math.Abs(y) / 2);
            for (int x = 0; x < numHexes; x++) 
            {
                {
                    Transform hex = Instantiate(hexPrefab) as Transform;
                    Vector2 gridPos = new Vector2(x, y);
                    hex.position = CalcWorldPos(gridPos, level, offset); ;
                    hex.parent = this.transform;
                    hex.name = "Hex" + x + "|" + y;
                }
            } 
        }
    }
    void MoveDeathBox() 
    {
        Vector3 pos = new Vector3(0, -((numLevels + 1) * levelHeight), 0);
        GameObject.FindWithTag("Deathbox").transform.position=pos;     
    }
}
