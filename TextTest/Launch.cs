using OpenGL;



namespace TextTest;

public class Launch
{
    public static void Main(string[] args)
    {
        WindowSettings.SetWindowSize((800, 600));
        WindowSettings.SetWindowTitle("Game Window");

        Game program = new();
        program.Run();
    }
}
