using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    private static Snake _basePrefab = null;

    public enum Dir
    {
        NORTH = 0,
        EAST,
        SOUTH,
        WEST,
    }

    public Vector2 Position
    {
        get
        {
            return _position;
        }
        set
        {
            transform.localPosition = new Vector3(value.x * _bodySize * 0.01f, value.y * _bodySize * 0.01f, 0);
            _position = value;
        }
    }

    private uint _velocity = 0;
    private uint _bodySize = 1;
    private float _moveTime = 0;

    private Vector2 _position = Vector2.zero;
    private Vector2 _dir = Vector2.up;
    private List<Body> _bodies = new List<Body>();

    public static Snake Create(Dir dir, uint length, uint bodySize = 1)
    {
        GameObject go = new GameObject("Snake");
        Snake result = go.AddComponent<Snake>();
        result._dir = Vector2.up;
        result.Init(length, bodySize);

        return result;
    }

    private void Init(uint length, uint bodySize)
    {
        _bodySize = bodySize;
        Body bodyOriginal = WAPK.Resources.Load<GameObject>("Prefabs/Body").GetComponent<Body>();

        for (int i = 0; i < length; i++)
        {
            Body body = Instantiate(bodyOriginal);
            body.transform.SetParent(this.transform);
            body.transform.localPosition = -_dir * i * 0.01f * bodySize;
            body.SetSize(bodySize, bodySize);

            _bodies.Add(body);
        }
    }

    public void SetBodySize(uint bodySize)
    {
        _bodySize = bodySize;
        for (int i = 0; i < _bodies.Count; i++)
        {
            _bodies[i].SetSize(bodySize, bodySize);
            _bodies[i].transform.localPosition = -_dir * i * 0.01f * bodySize;
        }
    }

    public void MoveFront(uint velocity)
    {
        _velocity = velocity;
        _moveTime = 0.0f;
    }

    public void Stop()
    {
        _velocity = 0;
    }

    public void Update()
    {
        if (_velocity.Equals(0.0f)) return;

        float before = _moveTime % (1.0f/_velocity);

        _moveTime += Time.deltaTime;

        if (before > _moveTime % (1.0f / _velocity))
        {
            Position = Position + _dir;
        }
    }
}
