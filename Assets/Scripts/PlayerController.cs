using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField]//�W�����v��
    float JumpForce = 0f;
    [SerializeField]//�X�s�[�h
    float Speed = 1f;
    float xSpeed = 0f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        float HorizontalKey = Input.GetAxis("Horizontal");
        //D����������E�Ɉړ�����
        if (HorizontalKey > 0)
        {
            xSpeed += Speed;
        }
        //A���������獶�Ɉړ�����
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
