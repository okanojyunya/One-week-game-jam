using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    /// <summary>移動力</summary>
    [SerializeField] float m_speed = 3f;
    /// <summary>ジャンプ速度</summary>
    [SerializeField] float m_jumpSpeed = 5f;
    /// <summary>ジャンプ中にジャンプボタンを押したときの上昇速度減少率</summary>
    [SerializeField] float m_gravityDrag = 8f;
    Rigidbody2D m_rb = default;
    float m_h = 0f;//Horizontalの変数名
    /// <summary>設置フラグ</summary>
    bool m_isGrounded = false;
    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        m_h = Input.GetAxis("Horizontal");
        Vector2 velocity = m_rb.velocity;
        //ジャンプ処理
        if (Input.GetButtonDown("Jump") && m_isGrounded)
        {
            m_isGrounded = false;
            velocity.y = m_jumpSpeed;
        }
        else if(!Input.GetButton("Jump") && velocity.y > 0)
        {
            //上昇中にジャンプボタンを離したら上昇を減速する
            velocity.y *= m_gravityDrag;
        }
        m_rb.velocity = velocity;
    }

    private void FixedUpdate()
    {
        m_rb.AddForce(m_h * m_speed * Vector2.right);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        m_isGrounded = true;
        if (GameObject.FindGameObjectWithTag("Enemy"))
        {
            //ここにプレイヤーのHPを減らす処理を書く
            //プレイヤーのHPは3にする（ストック性）
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        m_isGrounded = false;
    }
}
