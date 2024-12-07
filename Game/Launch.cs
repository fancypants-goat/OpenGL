using OpenGL;



namespace Game;

public class Launch
{
    public static void Main(string[] args)
    {
        WindowSettings.SetWindowSize((800, 600));
        WindowSettings.SetWindowState(WindowState.Normal);
        WindowSettings.SetWindowTitle("3D game");
        WindowSettings.SetWindowLocation(1);
        WindowSettings.SetWindowFocus(0);

        Game program = new();
        program.Run();
    }
}
