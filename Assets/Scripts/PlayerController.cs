using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    /// <summary>�ړ���</summary>
    [SerializeField] float m_speed = 3f;
    /// <summary>�W�����v���x</summary>
    [SerializeField] float m_jumpSpeed = 5f;
    /// <summary>�W�����v���ɃW�����v�{�^�����������Ƃ��̏㏸���x������</summary>
    [SerializeField] float m_gravityDrag = 8f;
    Rigidbody2D m_rb = default;
    float m_h = 0f;//Horizontal�̕ϐ���
    /// <summary>�ݒu�t���O</summary>
    bool m_isGrounded = false;
    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        m_h = Input.GetAxis("Horizontal");
        Vector2 velocity = m_rb.velocity;
        //�W�����v����
        if (Input.GetButtonDown("Jump") && m_isGrounded)
        {
            m_isGrounded = false;
            velocity.y = m_jumpSpeed;
        }
        else if(!Input.GetButton("Jump") && velocity.y > 0)
        {
            //�㏸���ɃW�����v�{�^���𗣂�����㏸����������
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
            //�����Ƀv���C���[��HP�����炷����������
            //�v���C���[��HP��3�ɂ���i�X�g�b�N���j
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        m_isGrounded = false;
    }
}
