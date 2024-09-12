using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PlayerController : MonoBehaviour
{
    /// <summary>�v���C���[��HP</summary>
    [SerializeField] int m_hp = 0;
    /// <summary>�ړ���</summary>
    [SerializeField] public float m_speed = 3f;
    /// <summary>�W�����v���x</summary>
    [SerializeField] float m_jumpSpeed = 5f;
    /// <summary>�W�����v���ɃW�����v�{�^�����������Ƃ��̏㏸���x������</summary>
    [SerializeField] float m_gravityDrag = 8f;
    /// <summary>�I�[�f�B�I�\�[�X</summary>
    [SerializeField] AudioSource audioSource;
    /// <summary>���̑f��</summary>
    [SerializeField] AudioClip footstepSound;
    /// <summary>�ω�������b��</summary>
    [SerializeField] float changeInterval = 1.0f;
    /// <summary>�G�ɗ^������_���[�W</summary>
    [SerializeField] float damege = 0;
    Rigidbody2D m_rb = default;
    public Slider slider = default;//�X���C�_�[�̕ϐ�
    SpriteRenderer m_sprite;//�X�v���C�g�����_���[�̕ϐ�
    Animator anim;//�A�j���[�^�[�̕ϐ���
    float m_h = 0f;//Horizontal�̕ϐ���
    /// <summary>�ݒu�t���O</summary>
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
        if (collision.gameObject.tag == "Enemy")
        {
            //m_hp -= 1;
            //slider.value = m_hp;
            Change(damege);
            m_sprite.color = Color.red;
            Debug.LogWarning("�G�ɓ������Ă���");
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
        //�L�����N�^�[�̍��E�̌�������
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
    /// �Q�[�W�����炷
    /// </summary>
    /// <param name="value"></param>
    public void Change(float value)
    {
        ValueChange(slider.value + value);
    }
    public void Fill()//�Q�[�W�𖞃^��
    {
        ValueChange(m_hp);
    }
    void ValueChange(float value)
    {
        DOTween.To(() => slider.value,x => slider.value = x,value, changeInterval);
    }
}
