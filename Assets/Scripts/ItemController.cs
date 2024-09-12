using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
//(�A�C�e�����g�������ʂɂ���)*���͂��Ȃ�*
//Enemy�^�O�̂����G��S���f�X�g���C������R�[�h������
//R�L�[����������@�\����悤�ɂ���
public class ItemController : MonoBehaviour
{
    Vector3 pos;
    bool m_get = false;
    void Update()
    {
        //R�L�[����������f�X�g���C������
        if (m_get == true)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                Destroy();
                GameObject.Destroy(gameObject);
            }
        }
        
    }
    public void Destroy()
    {
        GameObject[] destroys = GameObject.FindGameObjectsWithTag("Enemy");
        foreach(GameObject enemy_destroys in destroys)
        {
            Destroy(enemy_destroys);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //�v���C���[���G�ꂽ��A�C�e���X���b�g�Ɉړ�����
        if (collision.CompareTag("Player"))
        {
            transform.parent = GameObject.Find("ItemSet").transform;
            var ipos = ItemManage.instance.ItemSlot.transform.position;
            pos.x = ipos.x;
            pos.y = ipos.y;
            pos.z = 10;
            m_get = true;
            transform.position = pos;
            GetComponent<AudioSource>().Play();
        }
        
    }
}
