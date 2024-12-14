using System.Drawing;
using OpenGL;
using OpenGL.Components;
using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;
using OpenTK.Windowing.GraphicsLibraryFramework;



namespace TextTest;

public class Game : Program
{
    float time = 0;
    float cycletime = 20;
    public override void Create()
    {
        new Camera(new Vector3(0, 0, -10), new Vector3(0), 100, 0, 1000, true);

        //new GameObject("object", new Vector3(0), new Vector3(10, 10, 0), new Vector3(0), Texture.FromFile(Assets.GetFilePath("OpenGL-Logo.png")));


        GameObject text = new("text");
        text.AddComponent<UITransform>(new Vector2(500, 500), new Vector2(0, 0), ModelMode.Static);
        text.AddComponent<Text>(Assets.GetFilePath("Roboto-Black.ttf"), 
        "abcdefghijklmnopqrstuvwxyz\nABCDEFGHIJKLMNOPQRSTUVWXYZ\n0123456789\n!@#$%^&*()-_=+[{}];:`~'\",<.>/?\néëèáäàúüùíïìóöò\nThe quick brown fox jumps over the lazy dog\nHello, world!",
        32, Color.White);
    }

    public override void Update()
    {
        time += Time.deltaTime;
        if (time > cycletime) 
        {
            time -= cycletime;
        }
        // Calculate the color interpolation factor based on time
        float t = (float)Math.Sin(time / cycletime * 2 * Math.PI); // Use sine wave for smooth lerping

        // Lerp between blue, green, and red
        float r = Math.Max(0, Math.Min(1, t)) * 255; // Red goes up as t increases
        float g = Math.Max(0, Math.Min(1, -t)) * 255; // Green goes down as t increases
        float b = (1 - Math.Abs(t)) * 255; // Blue fades out as t goes from 0 to 1

        Text text = GameObject.Find("text").GetComponent<Text>();

        text.color = Color.FromArgb(255, (int)r, (int)g, (int)b);
    }
}
