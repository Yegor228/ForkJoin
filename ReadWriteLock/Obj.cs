namespace ReadWriteLock;
public class Obj
{
    private readonly Object _locker = new();

    private int _num { get; set; }

    public Obj(int num)
    {
        _num = num;
    }
    public void ChangeNum()
    {
        Console.WriteLine("Ветка 1");
        lock (_locker)
            _num++;
    }
    public void GetNum()
    {
        Console.WriteLine("Ветка 2");
        lock(_locker)
            Console.WriteLine(_num);
    }
}

