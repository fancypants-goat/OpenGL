using OpenGL;
using OpenGL.Components;
using OpenTK.Mathematics;
using System.Drawing;
using OpenTK.Windowing.GraphicsLibraryFramework;



namespace Game;

public class Player : Entity
{
    public Camera camera;
    public float speed;
    public float sensitivity = 100;
    public float jumpStrength;
    public BoxCollider feetCollider;
    public GameObject viewingPlatform;
    bool isGrounded = false;

    public Player(Vector3 position, Vector3 size, Vector3 rotation, Color color, float mass, float gravity, float speed, float jumpStrength) : base("player", position, size, rotation, color, mass, gravity)
    {
        camera = new Camera(position + new Vector3(0, size.Y / 2, 0), rotation, 100, 0, 1000, true);
        this.speed = speed;
        this.jumpStrength = jumpStrength;
        feetCollider = AddComponent<BoxCollider>(new Vector3(1, 0.01f, 1), new Vector3(0, -8.51f, 0), true);
    }



    public override void Update()
    {
        base.Update();

        HandleMovement();
        HandleRotating();

        transform.rotation = new Vector3(0f, camera.rotation.Y, 0f);
        camera.position = transform.position + new Vector3(0, transform.size.Y / 2, 0) + camera.GetHorizontalForwardsDirection() * transform.size;
    }


    void HandleRotating()
    {
        // yaw is around the Y axis    pitch is around the (local) x axis
        float yaw = camera.rotation.Y;
        float pitch = camera.rotation.X;

        Vector2 mouseMovement = sensitivity * Time.timeScale / 1000 * Input.MouseMovement;

        // yaw is the rotation along the global y axis.
        yaw += mouseMovement.X;

        pitch += mouseMovement.Y;
        pitch = Math.Clamp(pitch, -90, 90);

        camera.rotation = new Vector3(pitch, yaw, 0f);
    }

    void HandleMovement()
    {
        float speedModifier = 1f;
        if (Input.GetKey(Keys.LeftShift))
        {
            speedModifier += 0.6f;
        }

        float speed = this.speed * speedModifier * Time.deltaTime;
        if (Input.GetKey(Keys.W))
        {
            transform.Translate(speed * camera.GetHorizontalForwardsDirection());
        }
        if (Input.GetKey(Keys.S))
        {
            transform.Translate(speed * -camera.GetHorizontalForwardsDirection());
        }
        if (Input.GetKey(Keys.A))
        {
            transform.Translate(speed * -camera.GetHorizontalRightDirection());
        }
        if (Input.GetKey(Keys.D))
        {
            transform.Translate(speed * camera.GetHorizontalRightDirection());
        }

        isGrounded = feetCollider.CollidesWithAny().Length > 0;
        if (Input.GetKeyDown(Keys.Space))
        {
            Jump();
        }
    }
    

    void Jump()
    {
        if (!isGrounded) return;

        GetComponent<Physicsbody>().velocity.Y = jumpStrength;
    }
}