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
    private float _velocity = 0.0f;
    private Vector2 _pos = Vector2.zero;
    private Vector3 _dir = Vector3.up;
    private List<Body> _bodies = new List<Body>();

    public static Snake Create(Dir dir, uint length, uint bodySize = 1)
    {
        GameObject go = new GameObject("Snake");
        Snake result = go.AddComponent<Snake>();
        result._dir = Vector3.up;
        result._velocity = 1.0f;
        result.Init(length, bodySize);

        return result;
    }

    private void Init(uint length, uint bodySize)
    {
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
        for (int i = 0; i < _bodies.Count; i++)
        {
            _bodies[i].SetSize(bodySize, bodySize);
            _bodies[i].transform.localPosition = -_dir * i * 0.01f * bodySize;
        }
    }
}
