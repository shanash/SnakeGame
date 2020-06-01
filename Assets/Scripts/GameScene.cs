using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene : MonoBehaviour
{
    private World _world;
    // Start is called before the first frame update
    private void Start()
    {
        _world = new World();
        _world.Start();
    }

    // Update is called once per frame
    private void Update()
    {
        if (_world.IsMapOutSnake())
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        _world.Pause();
    }
}
