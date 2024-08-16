using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyController : MonoBehaviour
{
    Transform playerTr;//�v���C���[��Transform
    [SerializeField] float speed = 2f;//�G�̓����X�s�[�h
    void Start()
    {
        playerTr = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void Update()
    {
        //�v���C���[�Ƃ̋�����0.1f�����ɂȂ����炻��ȏ���s���Ȃ�
        if (Vector2.Distance(transform.position, playerTr.position) < 0.1f)
            return;
        //�v���C���[�Ɍ����Đi��
        transform.position = Vector2.MoveTowards(
            transform.position,
            new Vector2(playerTr.position.x, playerTr.position.y),
            speed * Time.deltaTime);
    }
}
