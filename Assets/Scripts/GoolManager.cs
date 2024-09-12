using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GoolManager : MonoBehaviour
{
    /// <summary>プレイヤーがゴールしたときにゲームクリア画面に移動する</summary>
    [SerializeField] UnityEvent m_actions;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        m_actions.Invoke();
    }
}
