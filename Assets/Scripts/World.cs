public class World
{
    private Map _map = null;
    private Snake _snake = null;

    public World()
    {
        _map = Map.Create(100,100, 50, 100, 10);
        _snake = Snake.Create(Snake.Dir.NORTH, 2);
        _map.Set(_snake, 2, 5);
        _snake.MoveFront(1);
    }

    public bool IsMapOutSnake()
    {
        return _map.IsOut(_snake);
    }

}
