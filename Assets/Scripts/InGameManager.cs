using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameManager : MonoBehaviour
{
    [SerializeField] Text m_gameOverText = null;
    void Start()
    {
        if (m_gameOverText)
        {
            m_gameOverText.enabled = false;
        }
    }

    void Update()
    {
        GameObject playerObj = GameObject.Find("Player");
        if (playerObj == null)
        {
            //プレイヤーがデストロイしたらゲームオーバーのテキストを表示する
            m_gameOverText.enabled = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(GameObject.FindGameObjectWithTag("Player"));
    }
}
