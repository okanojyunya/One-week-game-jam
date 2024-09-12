using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    Transform playerTr;//プレイヤーのTransform
    [SerializeField] float speed = 2f;//敵の動くスピード
    public EnemyDestroy enemyDestroyPrefab;
    SpriteRenderer spr;
    private static bool isQuitting = false;
    void Start()
    {
        playerTr = GameObject.FindGameObjectWithTag("Player").transform;
        spr = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
            
        //プレイヤーに向けて進む
        if(playerTr != null)
        {
            transform.position = Vector2.MoveTowards(
            transform.position,
            new Vector2(playerTr.position.x, playerTr.position.y),
            speed * Time.deltaTime);
            if(playerTr.position.x > transform.position.x)
            {
                spr.flipX = true;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Instantiate(enemyDestroyPrefab, this.transform.position, Quaternion.identity);
        if (GameObject.FindGameObjectWithTag("Player"))
        {
            GameObject.Destroy(gameObject);
        }
    }
    private void OnApplicationQuit()
    {
        isQuitting = true;
    }
    private void OnDestroy()
    {
        if(!isQuitting)
        {
            Instantiate(enemyDestroyPrefab, this.transform.position, Quaternion.identity);
        }
    }
}
