using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GoolManager : MonoBehaviour
{
    /// <summary>�v���C���[���S�[�������Ƃ��ɃQ�[���N���A��ʂɈړ�����</summary>
    [SerializeField] UnityEvent m_actions;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        m_actions.Invoke();
    }
}
