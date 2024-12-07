using OpenGL;



namespace TextTest;

public class Launch
{
    public static void Main(string[] args)
    {
        WindowSettings.SetWindowSize((800, 600));
        WindowSettings.SetWindowTitle("Game Window");
        WindowSettings.SetWindowLocation(0);

        Game program = new();
        program.Run();
    }
}