using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene : MonoBehaviour
{
    private World _world;

    private void Start()
    {
        _world = new World();
        _world.Start();
    }

    private void Update()
    {
        _world.Update();
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
