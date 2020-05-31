public class World
{
    private Map _map = null;
    private Snake _snake = null;

    public World()
    {
        _map = Map.Create(100,100, 50, 100, 10);
        _map.Set(Snake.Create(Snake.Dir.NORTH, 2), 2, 5);
    }

}
