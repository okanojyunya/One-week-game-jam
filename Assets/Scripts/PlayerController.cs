using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    /// <summary>プレイヤーのHP</summary>
    [SerializeField] int m_hp = 0;
    /// <summary>移動力</summary>
    [SerializeField] float m_speed = 3f;
    /// <summary>ジャンプ速度</summary>
    [SerializeField] float m_jumpSpeed = 5f;
    /// <summary>ジャンプ中にジャンプボタンを押したときの上昇速度減少率</summary>
    [SerializeField] float m_gravityDrag = 8f;
    Rigidbody2D m_rb = default;
    SpriteRenderer m_sprite;//スプライトレンダラーの変数
    float m_h = 0f;//Horizontalの変数名
    /// <summary>設置フラグ</summary>
    bool m_isGrounded = false;
    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
        m_sprite = GetComponent<SpriteRenderer>();
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
        if (collision.gameObject.tag == "Enemy")
        {
            m_hp -= 1;
            Debug.LogWarning("敵に当たっている");
            if (m_hp == 0)
            {
                GameObject.Destroy(gameObject);
            }
        }
        if (collision.gameObject.tag == "Ground")
        {
            m_isGrounded = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            m_isGrounded = false;
        }
    }
    private void LateUpdate()
    {
        //キャラクターの左右の向き制御
        if(m_h != 0)
        {
            m_sprite.flipX = (m_h < 0);
        }
    }
}
