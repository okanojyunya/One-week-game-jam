using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyController : MonoBehaviour
{
    Transform playerTr;//プレイヤーのTransform
    [SerializeField] float speed = 2f;//敵の動くスピード
    void Start()
    {
        playerTr = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void Update()
    {
        //プレイヤーとの距離が0.1f未満になったらそれ以上実行しない
        if (Vector2.Distance(transform.position, playerTr.position) < 0.1f)
            return;
        //プレイヤーに向けて進む
        transform.position = Vector2.MoveTowards(
            transform.position,
            new Vector2(playerTr.position.x, playerTr.position.y),
            speed * Time.deltaTime);
    }
}
