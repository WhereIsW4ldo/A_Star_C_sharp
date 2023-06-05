using A_Star;

internal class Program
{
    private static void Main(string[] args)
    {
        A_star a = new A_star(debug: true);
        a.read_input();

        a.display();

        a.calculate_path();
    }
}