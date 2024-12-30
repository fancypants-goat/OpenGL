using OpenGL;
using OpenGL.Components;
using OpenTK.Mathematics;
using System.Drawing;
using OpenTK.Windowing.GraphicsLibraryFramework;
using OpenTK.Windowing.Common;
using OpenGL.UI;



namespace Game;

public class Game : Program
{
    public Player player;
    bool escape = false;
    Panel escapeMenu;
    Button button;
    GameObject checkPanel;

    public override void Create()
    {
        player = new Player(new Vector3(0, 30, -10), new Vector3(10, 17, 10), new Vector3(0, 0, 0), Color.FromArgb(255, 255, 50, 50), 10, -25, 20, 27);

        Texture boxTexture = Texture.FromFile(Assets.GetFilePath("Textures/container.png"), true);
        GameObject floor = new("floor", new Vector3(0), new Vector3(100, 50, 100), new Vector3(0, 0, 0), Texture.FromFile(Assets.GetFilePath("Textures/wall.jpg"), true));
        floor.AddComponent<BoxCollider>();
        GameObject boxes = new("boxes", false);
        new GameObject("box1", new Vector3(-40, 31, 30), new Vector3(12, 12, 12), new Vector3(90, 30, 0), boxTexture).AddComponent<BoxCollider>().gameObject.SetParent(boxes);
        new GameObject("box2", new Vector3(-40, 32.5f, -30), new Vector3(15, 15, 15), new Vector3(90, 0, 0), boxTexture).AddComponent<BoxCollider>().gameObject.SetParent(boxes);
        new GameObject("box3", new Vector3(-60, 47, -19), new Vector3(10, 10, 10), new Vector3(90, 20, 0), boxTexture).AddComponent<BoxCollider>().gameObject.SetParent(boxes);
        new GameObject("box4", new Vector3(-80, 55, 10), new Vector3(15, 15, 15), new Vector3(90, 50, 0), boxTexture).AddComponent<BoxCollider>().gameObject.SetParent(boxes);
        new GameObject("box5", new Vector3(-85, 50, 35), new Vector3(12, 12, 12), new Vector3(90, 20, 0), boxTexture).AddComponent<BoxCollider>().gameObject.SetParent(boxes);
        GameObject view = new("view_platform", new Vector3(-95, 60, 65), new Vector3(20, 20, 10), new Vector3(90, 0, 0), boxTexture, Color.FromArgb(100, 255, 255, 255));
        view.AddComponent<BoxCollider>().gameObject.SetParent(boxes);
        _ = new Entity("lil_box", new Vector3(20, 33, 10), new Vector3(8, 8, 8), new Vector3(0, -40, 0), Texture.FromFile(Assets.GetFilePath("Textures/awesomeface.png"), true), 5, -15);

        // create some UI BITCHES
        escapeMenu = new("menu", new Vector2(0, 0), new Vector2(100, 100), ModelMode.Stretch, Color.FromArgb(150, Color.Black), isActive:false);
        escapeMenu.GetComponent<UIRenderer>().enabled = true;

        button = new("quit_button", new Vector2(35, 65), new Vector2(30, 5), ModelMode.Stretch, Color.DarkRed, isActive:true, action: () =>
        {
            Console.WriteLine("Closing!");
            Close();
        });
        button.SetParent(escapeMenu);

        Button button2 = new("resume_button", new Vector2(35, 40), new Vector2(30, 10), ModelMode.Stretch, Color.White, action:Pause, isActive:true);
        button2.SetParent(escapeMenu);
        button2.GetComponent<UIRenderer>().enabled = true;
        button2.AddComponent<Text>(Assets.GetFilePath("Fonts/Roboto-Black.ttf"), "Resume", 32, Color.White);

        CursorState = CursorState.Grabbed;
    }

    void Pause()
    {
        escape = !escape;
        if (escape)
        {
            CursorState = CursorState.Normal;
            Time.timeScale = 0;
            
            escapeMenu.isActive = true;
        }
        else
        {
            Time.timeScale = 1;

            escapeMenu.isActive = false;
            CursorState = CursorState.Grabbed;
        }
    }

    public override void Update()
    {
        base.Update();


        if (Input.GetKeyDown(Keys.Escape))
        {
            Pause();
        }
    }
}
