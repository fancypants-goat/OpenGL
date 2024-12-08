using System.Drawing;
using OpenGL;
using OpenGL.Components;
using OpenTK.Mathematics;



namespace TextTest;

public class Game : Program
{
    public override void Create()
    {
        new Camera(new Vector3(0, 0, -10), new Vector3(0), 100, 0, 1000, true);

        GameObject text = new("text");
        text.AddComponent<UITransform>(new Vector2(500, 500), new Vector2(0, 0), ModelMode.Static);
        text.AddComponent<Text>(Assets.GetFilePath("Roboto-Black.ttf"), "Hello, World!", 50);
    }
}
