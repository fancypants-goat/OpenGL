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

        GameObject text = new GameObject("text");
        text.AddComponent<UITransform>(new Vector2(0, 0), new Vector2(10, 10), ModelMode.Static);
        text.AddComponent<Text>(Assets.GetFilePath("Roboto-Black.ttf"), "Hello", 32);

        Matrix4 ortho = Matrix4.CreateOrthographicOffCenter(0, ClientSize.X, ClientSize.Y, 0, -1, 1);
        Vector3 position = new(1, 5, 0);
        Vector3 result = (ortho * new Vector4(position)).Xyz;
        Console.WriteLine(result);
    }
}
