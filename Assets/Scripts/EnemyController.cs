using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.PackageManager.UI;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyController : MonoBehaviour
{
    Transform playerTr;//�v���C���[��Transform
    [SerializeField] float speed = 2f;//�G�̓����X�s�[�h
    public EnemyDestroy enemyDestroyPrefab;
    void Start()
    {
        playerTr = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void Update()
    {
            
        //�v���C���[�Ɍ����Đi��
        if(playerTr != null)
        {
            transform.position = Vector2.MoveTowards(
            transform.position,
            new Vector2(playerTr.position.x, playerTr.position.y),
            speed * Time.deltaTime);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (GameObject.FindGameObjectWithTag("Player"))
        {
            GameObject.Destroy(gameObject);
        }
    }
    private void OnDestroy()
    {
        Instantiate(enemyDestroyPrefab, this.transform.position, Quaternion.identity);
    }
}
