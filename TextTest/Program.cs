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

        Graphics.BackColor(110, 61, 22);

        GameObject text = new GameObject("text");
        text.AddComponent<UITransform>(new Vector2(0, 0), new Vector2(10, 10), ModelMode.Static);
        text.AddComponent<Text>(Assets.GetFilePath("Roboto-Black.ttf"), "Hello", 32);
    }
}
