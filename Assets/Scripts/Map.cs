using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    private static Map _basePrefab = null;

    [SerializeField] private static Sprite _spr = null;

    private ushort _row = 0;
    private ushort _column = 0;
    private ushort _tileSize = 0;

    private List<SpriteRenderer> _mapTiles = new List<SpriteRenderer>();

    public static Map Create(int posX, int posY, ushort row, ushort column, ushort tileSize)
    {
        if (_basePrefab == null)
        {
            _basePrefab = WAPK.Resources.Load<GameObject>("Prefabs/Map").GetComponent<Map>();
        }


        Map mapObj = Instantiate(_basePrefab);
        mapObj.transform.position = new Vector3(posX*0.01f, posY*0.01f, 0);

        mapObj._row = row;
        mapObj._column = column;
        mapObj._tileSize = tileSize;
        mapObj.Init();
        return mapObj;
    }

    private void Init()
    {
        SpriteRenderer tileOriginal = WAPK.Resources.Load<GameObject>("Prefabs/MapTile").GetComponent<SpriteRenderer>();

        for ( int i = 0; i < _column; i++)
        {
            for ( int j = 0; j < _row; j++)
            {
                SpriteRenderer sr = Instantiate(tileOriginal);
                sr.transform.SetParent(this.transform);
                sr.transform.localPosition = new Vector3(j * _tileSize * 0.01f, i * _tileSize * 0.01f, 0);
                sr.size = new Vector2(_tileSize, _tileSize);

                _mapTiles.Add(sr);
            }
        }
    }

    public void Set(Snake snake, uint tilePosX, uint tilePosY)
    {
        snake.transform.SetParent(this.transform);
        snake.SetBodySize(_tileSize);
        snake.Position = new Vector2(tilePosX, tilePosY);//tilePosX * _tileSize * 0.01f, tilePosY * _tileSize * 0.01f);
    }

    //** 중복
    public void Set(Feed feed, uint tilePosX, uint tilePosY)
    {
        feed.transform.SetParent(this.transform);
        feed.SetBodySize(_tileSize);
        feed.Position = new Vector2(tilePosX, tilePosY);//tilePosX * _tileSize * 0.01f, tilePosY * _tileSize * 0.01f);
    }
    //**

    public bool IsOut(Snake snake)
    {
        int x = (int)(snake.transform.localPosition.x * 100.0f) / _tileSize;
        int y = (int)(snake.transform.localPosition.y * 100.0f) / _tileSize;
        if (x < 0) return true;
        if (x >= _row) return true;
        if (y < 0) return true;
        if (y >= _column) return true;

        return false;
    }

}
