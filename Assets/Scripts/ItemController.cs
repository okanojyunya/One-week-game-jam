using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//(�A�C�e�����g�������ʂɂ���)*���͂��Ȃ�*
//Enemy�^�O�̂����G��S���f�X�g���C������R�[�h������
//R�L�[����������@�\����悤�ɂ���
public class ItemController : MonoBehaviour
{
    Vector3 pos;
    void Update()
    {
        //R�L�[����������f�X�g���C������
        if (Input.GetKey(KeyCode.R))
        {
            Destroy();
            GameObject.Destroy(gameObject);
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
            pos.x = ItemManage.instance.ItemSlot.transform.position.x;
            pos.y = ItemManage.instance.ItemSlot.transform.position.y;
            pos.z = 0;
            transform.position = pos;
        }
        
    }
}
