using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Assets.Scripts.Unit;
using DefaultNamespace;
using Tiles;
using UnityEngine;
using Random = UnityEngine.Random;

public class AreaGenerator : MonoBehaviour {
    public TurnManager TurnManager;
    public GameObject[] TilePrefabs;
    public GameObject BaseTilePrefab;
    public int GridSize;
    public int HillSize;

    private List<GameObject> _tiles = new List<GameObject>();
//    private List<GameObject> _hills = new List<GameObject>();
//
//    private Dictionary<int, int> _heightLevel = new Dictionary<int, int>();

    private GameObject _redBase;
    private GameObject _blueBase;
    float heightBetween = 1f;

    float widthBetween = 4f;

    //UI
    private UIManager _uiManager;

    void Start() {
        _uiManager = GameObject.FindWithTag("UIManager").GetComponent<UIManager>();
    }

    public bool InRange(Tile origin, Tile target, float range, MovementType movementType) {
        switch (movementType) {
            case MovementType.Straight:
                return ((target.X == origin.X && Mathf.Abs(target.Y - origin.Y) <= range) ||
                        (target.Y == origin.Y && Mathf.Abs(target.X - origin.X) <= range));
            case MovementType.Radial:
                return ((Mathf.Sqrt(Mathf.Pow((target.X - origin.X), 2) + Mathf.Pow((target.Y - origin.Y), 2))) 
                        <= range);
            case MovementType.Diagonal:
                return (((Mathf.Abs(target.X - origin.X)) == (Mathf.Abs(target.Y - origin.Y))) &&
                        ((Mathf.Sqrt(Mathf.Pow((target.X - origin.X), 2) + Mathf.Pow((target.Y - origin.Y), 2)))
                         <= range));
            default:
                return false;
        }
    }

    public List<GameObject> GetTilesInRange(Tile origin, float range, MovementType moveType, bool addUnitTiles = false) {
        var tiles = new List<GameObject>();

        foreach (var tile in _tiles) {
            var t = tile.GetComponent<Tile>();
            if (InRange(origin, t, range, moveType)) {
                if (addUnitTiles) {
                    tiles.Add(t.gameObject);                    
                }
                else {
                    if (t.GetUnit() == null) {
                        tiles.Add(t.gameObject);
                    }
                }
            }
        }

        return tiles;
    }

    public Transform GetBase(Player.TeamColor color) {
        switch (color) {
            case Player.TeamColor.Red:
                return _redBase.transform;
            case Player.TeamColor.Blue:
                return _blueBase.transform;
            default:
                throw new ArgumentOutOfRangeException("color", color, null);
        }
    }

    public GameObject GetTileObject(int x, int z) {
        try {
            var childNum = z + x * GridSize;
            if (childNum > (GridSize * GridSize) - 1) return null;
            var tileTransform = transform.GetChild(childNum);
            if (tileTransform.childCount > 1) return null;
            return tileTransform.gameObject;
        }
        catch (UnityException ex) {
            return null;
        }
    }

    public Tile GetTile(int x, int z) {
        return GetTileObject(x, z).GetComponent<Tile>();
    }

    public void Generate() {
        ResetTiles();
        SpawnGrid();
        SetBase();
    }

    private void SpawnGrid() {
        float xoffset = 0;
        int index = 0;
        for (int x = 0; x < GridSize; x++) {
            float yoffset = 0;
            for (int y = 0; y < GridSize; y++) {
                int modulo = (x + y) % 2;

                GameObject newTile = Instantiate(TilePrefabs[modulo]);
                newTile.transform.SetParent(transform);
                newTile.transform.localPosition = new Vector3(xoffset, 0, yoffset);
                newTile.name = string.Format("Tile {0}x{1} [{2}]", x, y, index++);

                newTile.GetComponent<Tile>().Position = newTile.transform.localPosition;
                newTile.GetComponent<Tile>().X = x;
                newTile.GetComponent<Tile>().Y = y;
                _tiles.Add(newTile);
                yoffset += widthBetween;
            }

            xoffset += widthBetween;
        }
    }

    private void ResetTiles() {
        foreach (Transform child in transform) {
            Destroy(child.gameObject);
        }

        _tiles.Clear();
//        _heightLevel.Clear();
//        _hills.Clear();
    }

    private void SetBase() {
        var tile = GetTile(1, 1);
        int height = 0;

        _redBase = Instantiate(BaseTilePrefab, new Vector3(0, height * heightBetween, 0), new Quaternion());
        _redBase.transform.SetParent(tile.transform, false);
        BasePanel redPanel = _redBase.GetComponent<BasePanel>();
        redPanel.TurnManager = TurnManager;
        redPanel.UiManager = _uiManager;
        redPanel.Ownable = _redBase.AddComponent<Ownable>();
        redPanel.Ownable.Initialize(TurnManager.Players[0]);

        tile = GetTile(GridSize - 2, GridSize - 2);
        height = 0;

        _blueBase = Instantiate(BaseTilePrefab, new Vector3(0, height * heightBetween, 0), new Quaternion());
        _blueBase.transform.SetParent(tile.transform, false);
        BasePanel bluePanel = _blueBase.GetComponent<BasePanel>();
        bluePanel.TurnManager = TurnManager;
        bluePanel.UiManager = _uiManager;
        bluePanel.Ownable = _blueBase.AddComponent<Ownable>();
        bluePanel.Ownable.Initialize(TurnManager.Players[1]);
    }
}