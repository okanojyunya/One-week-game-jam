using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class InGameManager : MonoBehaviour
{
    [SerializeField] UnityEvent m_actions;
    void Update()
    {
        GameObject playerObj = GameObject.Find("Player");
        if (playerObj == null)
        {
            //�v���C���[���f�X�g���C������Q�[���I�[�o�[�̉�ʂɈړ�����
            m_actions.Invoke();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(GameObject.FindGameObjectWithTag("Player"));
        GetComponent<AudioSource>().Play();
    }
}
