using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManage : MonoBehaviour
{
    public GameObject ItemSlot;//�A�C�e���X���b�g�̕ϐ���
    public static ItemManage instance { get; private set; }

    private void Awake()
    {
        instance = this;
    }
}
