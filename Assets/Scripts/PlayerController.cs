using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PlayerController : MonoBehaviour
{
    /// <summary>プレイヤーのHP</summary>
    [SerializeField] int m_hp = 0;
    /// <summary>移動力</summary>
    [SerializeField] public float m_speed = 3f;
    /// <summary>ジャンプ速度</summary>
    [SerializeField] float m_jumpSpeed = 5f;
    /// <summary>ジャンプ中にジャンプボタンを押したときの上昇速度減少率</summary>
    [SerializeField] float m_gravityDrag = 8f;
    /// <summary>オーディオソース</summary>
    [SerializeField] AudioSource audioSource;
    /// <summary>音の素材</summary>
    [SerializeField] AudioClip footstepSound;
    /// <summary>変化させる秒数</summary>
    [SerializeField] float changeInterval = 1.0f;
    /// <summary>敵に与えられるダメージ</summary>
    [SerializeField] float damege = 0;
    Rigidbody2D m_rb = default;
    public Slider slider = default;//スライダーの変数
    SpriteRenderer m_sprite;//スプライトレンダラーの変数
    Animator anim;//アニメーターの変数名
    float m_h = 0f;//Horizontalの変数名
    /// <summary>設置フラグ</summary>
    bool m_isGrounded = false;
    //int maxhp = 3;
    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
        m_sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        //slider.value = maxhp;
        //m_hp = maxhp;
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
            //m_hp -= 1;
            //slider.value = m_hp;
            Change(damege);
            m_sprite.color = Color.red;
            Debug.LogWarning("敵に当たっている");
            Invoke("back", 0.2f);
            if (slider.value == 1f)
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
        if(anim)
        {
            anim.SetFloat("SpeedX", Mathf.Abs(m_rb.velocity.x));
            anim.SetFloat("SpeedY", m_rb.velocity.y);
            anim.SetBool("isGuronded", m_isGrounded);
        }
    }
    public void PlayFootstepSound()
    {
        audioSource.PlayOneShot(footstepSound);
    }
    void back()
    {
        m_sprite.color = Color.white;
    }
    /// <summary>
    /// ゲージを減らす
    /// </summary>
    /// <param name="value"></param>
    public void Change(float value)
    {
        ValueChange(slider.value + value);
    }
    public void Fill()//ゲージを満タン
    {
        ValueChange(m_hp);
    }
    void ValueChange(float value)
    {
        DOTween.To(() => slider.value,x => slider.value = x,value, changeInterval);
    }
}
