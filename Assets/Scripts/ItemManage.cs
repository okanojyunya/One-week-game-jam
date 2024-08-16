using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManage : MonoBehaviour
{
    public GameObject ItemSlot;//アイテムスロットの変数名
    public static ItemManage instance { get; private set; }

    private void Awake()
    {
        instance = this;
    }
}
