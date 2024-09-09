using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GoolManager : MonoBehaviour
{
    /// <summary>プレイヤーがゴールしたときにゲームクリア画面に移動する</summary>
    [SerializeField] UnityEvent m_actions;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        m_actions.Invoke();
    }
}
