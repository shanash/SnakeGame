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

        _map.Set(Feed.Create(), 10, 10);
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

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            _snake.Turn(Vector2.up);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            _snake.Turn(Vector2.down);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            _snake.Turn(Vector2.left);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            _snake.Turn(Vector2.right);
        }
    }
}
