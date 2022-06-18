namespace ForkJoin;

public class Program
{
    public static void Main()
    {
        CountDownLetch();

        
        //Console.ReadKey();
    }

    public static void SumBinaryTreeTest()
    {
        BinaryTree tree = new BinaryTree();
        var rnd = new Random();
        for (int i = 0; i < 100; i++)
            tree.Add(rnd.Next(100));

        tree.Walk(tree.Root);
        Console.WriteLine();
        tree.Summ(tree.Root);
    }


    public static void CountDownLetch()
    {
        Task[] tasks = new Task[100];
        for(int i = 0; i < tasks.Length; i++)
            tasks[i] = Task.Run(() => Thread.Sleep(1000));
        Task.WaitAll(tasks);
        Console.WriteLine("End!");
    }
}
