namespace Davesson
{
    internal class Program
    {
        static void input( string fileloc)
        {
            string inp;
            Console.WriteLine("Dave's son >> "); inp = Console.ReadLine();
            File.WriteAllText(fileloc, inp);
        }
        static void Main(string[] args)
        {
            string fileloc = @"E:\DaveY\message.txt";
            string inp;
            while (true)
            {
                input(fileloc);
            }
        }
    }
}