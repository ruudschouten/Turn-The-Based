using System;
using System.Collections.Generic;
using System.Linq;
using NaughtyAttributes;
using Tiles;
using Turn;
using UI.Managers;
using Unit;
using UnityEngine;
namespace Generators
{
    public class AreaGenerator : MonoBehaviour 
    {
        [SerializeField] private TurnManager turnManager;
        [SerializeField] private Tile[] tilePrefabs;
        [SerializeField] private BasePanel baseTilePrefab;
        [SerializeField] private int gridSize;
        [SerializeField] private UIManager uiManager;

        public int GridSize => gridSize;
    
        private readonly List<Tile> _tiles = new List<Tile>();
        private BasePanel _redBase;
        private BasePanel _blueBase;
        private const float HeightBetween = 1f;
        private const float WidthBetween = 4f;

        private bool InRange(Tile origin, Tile target, float range, MovementType movementType)
        {
            switch (movementType)
            {
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

        public List<Tile> GetTilesInRange(Tile origin, float range, MovementType moveType, bool addUnitTiles = false)
        {
            var tiles = new List<Tile>();

            foreach (var tile in _tiles.Where(tile => InRange(origin, tile, range, moveType)))
            {
                if (addUnitTiles)
                {
                    tiles.Add(tile);
                }
                else
                {
                    if (tile.GetUnit() == null)
                    {
                        tiles.Add(tile);
                    }
                }
            }

            return tiles;
        }

        public Transform GetBase(Player.TeamColor color)
        {
            switch (color)
            {
                case Player.TeamColor.Red:
                    return _redBase.transform;
                case Player.TeamColor.Blue:
                    return _blueBase.transform;
                default:
                    throw new ArgumentOutOfRangeException(nameof(color), color, null);
            }
        }

        public Tile GetTile(int x, int z)
        {
            var childNum = z + x * gridSize;
            if (childNum > (gridSize * gridSize) - 1)
            {
                return null;
            }
            var tile = _tiles[childNum];

            return tile;
        }
        
        [Button("Generate")]
        public void Generate()
        {
            ResetTiles();
            SpawnGrid();
            SetBase();
        }

        private void SpawnGrid()
        {
            var xOffset = 0f;
            var index = 0;
            for (var x = 0; x < gridSize; x++)
            {
                var yOffset = 0f;
                for (var y = 0; y < gridSize; y++)
                {
                    var modulo = (x + y) % 2;

                    var tile = Instantiate(tilePrefabs[modulo], transform);
                    tile.transform.localPosition = new Vector3(xOffset, 0, yOffset);
                    tile.name = $"Tile {x}x{y} [{index++}]";
                    tile.X = x;
                    tile.Y = y;
                    tile.UiManager = uiManager;
                    
                    _tiles.Add(tile);
                    
                    yOffset += WidthBetween;
                }

                xOffset += WidthBetween;
            }
        }

        private void ResetTiles()
        {
            foreach (Transform child in transform)
            {
                Destroy(child.gameObject);
            }

            _tiles.Clear();
        }

        private void SetBase()
        {
            _redBase = CreateBase(1, 1, turnManager.Players[0]);
            _blueBase = CreateBase(gridSize -2, gridSize -2, turnManager.Players[1]);
        }

        private BasePanel CreateBase(int x, int z, Player player)
        {
            var tile = GetTile(x, z);

            var panel = Instantiate(baseTilePrefab, Vector3.zero, Quaternion.identity);
            panel.transform.SetParent(tile.transform, false);
            panel.TurnManager = turnManager;
            panel.UIManager = uiManager;
            panel.Ownable.Initialize(player);

            return panel;
        }
    }
}