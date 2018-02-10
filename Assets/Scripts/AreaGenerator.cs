﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class AreaGenerator : MonoBehaviour {

    public GameObject[] TilePrefabs;
    public Transform TileContainer;
    public GameObject BaseTile;
    public int GridSize;
    public int HillSize;

    private List<GameObject> tiles = new List<GameObject>();
    private List<GameObject> hills = new List<GameObject>();
//    private int lastIndex;

    // Use this for initialization
    void Start () {
		SpawnGround();
        SetGroundPosition();
        SpawnHills();
        SetHillPosition();
        SetBase();
    }

    private void SpawnGround() {
        for (int i = 0; i < GridSize * GridSize; i++) {
            GameObject tile = Instantiate(TilePrefabs[GetRandom(TilePrefabs.Length)], new Vector3(), new Quaternion(), TileContainer);
            tiles.Add(tile);
        }
    }

    private void SetGroundPosition() {
        int currentX = 0;
        int currentZ = 0;
        float widthBetween = 2.8f;
        foreach (var tile in tiles) {
            tile.transform.position = new Vector3(widthBetween * currentX, 0, widthBetween * currentZ);
            currentX++;
            if (currentX == GridSize) {
                currentX = 0;
                currentZ++;
            }
        }
    }

    private void SpawnHills() {
        for (int i = 0; i < HillSize; i++) {
            GameObject lev = Instantiate(TilePrefabs[GetRandom(TilePrefabs.Length)], new Vector3(), new Quaternion(), TileContainer);
            hills.Add(lev);
        }
    }

    private void SetHillPosition() {
        float heightBetween = 0.75f;
        for (int i = 0; i < HillSize; i++) {
            int pos = Random.Range(0, tiles.Count);
            Vector3 tilePos = tiles[pos].transform.position;
            hills[i].transform.position = new Vector3(tilePos.x, tilePos.y + heightBetween, tilePos.z);
            tiles.Add(hills[i]);
        }
    }

    private void SetBase() {
        Vector3 tilePos = tiles[tiles.Count-1].transform.position;
        tiles.Add(Instantiate(BaseTile, tilePos, new Quaternion(), TileContainer));
    }

    //BaseTile is last tile added.
    public GameObject GetBaseTile() {
        return tiles[tiles.Count - 1];
    }

    int GetRandom(int length) {
        return Random.Range(0, length);
        /*
        if (length <= 1) { return 0; }
        int randomIndex = lastIndex;
        while (randomIndex == lastIndex) { randomIndex = Random.Range(0, length); }
        lastIndex = randomIndex;
        return randomIndex;
        */
    }
}