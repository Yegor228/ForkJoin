namespace Exchanger;

public class Program
{
    public static void Main()
    {

        Exchange exch = new Exchange
            (() =>
                {
                    using (var sr = new StreamReader("text.txt"))
                        return sr.ReadToEnd();
                });

        exch.ReaderProcessorWriterWorker(() => "ninja");

        exch.ReaderProcessorWriterWorker
            (() =>
            {
                using (var sw = new StreamWriter("text.txt"))
                    sw.Write(exch.GetStr());
                return exch.GetStr();
            });

        exch.Show();
    }
}

public class Exchange
{
    private string? _str {  get; set; }

    public Exchange(Func<string> func)
    {
        ReaderProcessorWriterWorker(func);
    }

    public string GetStr() => _str;

    public void ReaderProcessorWriterWorker(Func<string> func)
    {
        _str = Task.Run(() => func.Invoke()).Result;
        Task.WaitAll();
    }

    public void Show() => Console.WriteLine(_str);
}
