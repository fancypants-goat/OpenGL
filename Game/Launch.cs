using OpenGL;



namespace Game;

public class Launch
{
    public static void Main(string[] args)
    {
        WindowSettings.SetWindowState(WindowState.Maximized);
        WindowSettings.SetWindowTitle("3D game");
        WindowSettings.SetWindowLocation(1);
        WindowSettings.SetWindowFocus(0);

        Game program = new();
        program.Run();
    }
}
