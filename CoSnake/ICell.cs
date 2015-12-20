namespace CoSnake
{
    public interface ICell<T> where T: class
    {
        T Content();
    }

    public interface ICell
    {
        object Content();
    }
}
