using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField]//ジャンプ力
    float JumpForce = 0f;
    [SerializeField]//スピード
    float Speed = 1f;
    float xSpeed = 0f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        float HorizontalKey = Input.GetAxis("Horizontal");
        //Dを押したら右に移動する
        if (HorizontalKey > 0)
        {
            xSpeed += Speed;
        }
        //Aを押したら左に移動する
        else if (HorizontalKey < 0)
        {
            xSpeed -= Speed;
        }
        else
        {
            xSpeed = 0;
        }
        rb.velocity = new Vector2(xSpeed, rb.velocity.y);
    }
}
