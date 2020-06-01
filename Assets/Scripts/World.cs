using UnityEngine;

public class World
{
    private Map _map = null;
    private Snake _snake = null;

    public World()
    {
        _map = Map.Create(100,100, 50, 100, 10);
        _snake = Snake.Create(Snake.Dir.NORTH, 4);
        _map.Set(_snake, 2, 5);
    }

    public bool IsMapOutSnake()
    {
        return _map.IsOut(_snake);
    }

    public void Start()
    {
        _snake.MoveFront(20);
    }

    public void Pause()
    {
        _snake.Stop();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Debug.Log("UpArrow");
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Debug.Log("DownArrow");
        }
    }
}
