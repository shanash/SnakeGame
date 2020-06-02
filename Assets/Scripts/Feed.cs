using System.Collections.Generic;
using UnityEngine;

public class Feed : MonoBehaviour
{
    private static Feed _basePrefab = null;

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

    private uint _bodySize = 1;

    private Vector2 _position = Vector2.zero;
    private Vector2 _dir = Vector2.up;
    private List<Body> _bodies = new List<Body>();
    public static Feed Create()
    {
        GameObject go = new GameObject("Feed");
        Feed result = go.AddComponent<Feed>();
        result._dir = Vector2.up;
        result.Init(1, 1);
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
}
