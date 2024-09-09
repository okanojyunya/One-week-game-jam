using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// ���Ԋu�œG�𐶐�����R���|�[�l���g
/// </summary>
public class EnemyGenerator : MonoBehaviour
{
    [SerializeField] GameObject m_enemyPrefab;
    [SerializeField] int m_interval;
    float m_time;//�o�ߎ���

    void Update()
    {
        m_time += Time.deltaTime;
        if(m_time > m_interval)
        {
            m_time = 0;
            Instantiate(m_enemyPrefab, gameObject.transform.position, Quaternion.identity);
        }
        if(GameObject.Find("Player") == null)
        {
            Destroy(gameObject);
        }
    }
}
