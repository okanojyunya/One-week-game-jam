using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//(�A�C�e�����g�������ʂɂ���)*���͂��Ȃ�*
//Enemy�^�O�̂����G��S���f�X�g���C������R�[�h������
//R�L�[����������@�\����悤�ɂ���
public class ItemController : MonoBehaviour
{
    
    void Start()
    {
        
    }
    void Update()
    {
        //R�L�[����������f�X�g���C������
        if (Input.GetKey(KeyCode.R))
        {
            Destroy();
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
}
