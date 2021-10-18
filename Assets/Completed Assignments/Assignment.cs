using UnityEngine;

public class Assignment : ProcessingLite.GP21
{
    Player player;
    Ball[] Balls;
    int Amount = 10;
    void Start()
    {
        player = new Player(Width / 2, Height / 2);
        Balls = new Ball[Amount];
        for (int i = 0; i < Balls.Length; i++)
        {
            Balls[i] = new Ball(3, 3);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Background(0);
        player.Move();
        foreach (Ball ball in Balls)
        {
            player.CircleCollision(ball);
            ball.UpdatePos();
            ball.Draw();
        }
    }
}

public class Player : ProcessingLite.GP21
{
    public float speed = 5f;
    public Vector2 Charpos1;
    float diameter = 2;
    float ballRadius = 0.25f;
    public bool CircleCollision(Ball ball)
    {
        float MaxDistance = (diameter / 2) + ballRadius;

        if (Mathf.Abs(Charpos1.x - ball.position.x) > MaxDistance || Mathf.Abs(Charpos1.y - ball.position.y) > MaxDistance)
        {
            return false;
        }
        else if (Vector2.Distance(Charpos1, ball.position) > MaxDistance)
        {
            return false;
        }
        else
        {
            Debug.Log("Game Over");
            return true;
        }
    }

    public Player(float x, float y)
    {
        Charpos1.x = x;
        Charpos1.y = y;
    }

    public void Move()
    {
        Charpos1.x = Charpos1.x + Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        Charpos1.y = Charpos1.y + Input.GetAxis("Vertical") * Time.deltaTime * speed;

        Circle(Charpos1.x, Charpos1.y, diameter);
    }

}
public class Ball : ProcessingLite.GP21
{
    public Vector2 position;
    public Vector2 velocity;

    public Ball(float x, float y)
    {

        position = new Vector2(x, y);

        velocity = new Vector2();
        velocity.x = Random.Range(0, 11) - 5;
        velocity.y = Random.Range(0, 11) - 5;
    }

    public void Draw()
    {
        Fill(255, 0, 0);
        Circle(position.x, position.y, 0.5f);
    }

    public void UpdatePos()
    {
        position += velocity * Time.deltaTime;

        if (position.x > Width || position.x < 0)
        {
            velocity.x *= -1;
        }
        if (position.y > Height || position.y < 0)
        {
            velocity.y *= -1;
        }
    }
}