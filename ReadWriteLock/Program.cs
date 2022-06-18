namespace ReadWriteLock;

public static class Program
{
    public static void Main()
    {
        Qqq();

    }

    public static void Qqq()
    {
        Obj obj = new Obj(0);

        Task[] tasks = new Task[10];
        Random rand = new Random();
        for (int i = 0; i < tasks.Length; i++)
        {
            if (rand.Next(2) == 1)
                tasks[i] = Task.Run(() =>
                {
                    obj.ChangeNum();
                });
            else
                tasks[i] = Task.Run(() =>
                {
                    obj.GetNum();
                });
        }
        Task.WhenAll(tasks);

        obj.GetNum();

    }

}