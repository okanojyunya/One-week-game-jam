using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//(アイテムを使ったら画面にいる)*今はやらない*
//Enemyタグのついた敵を全員デストロイさせるコードを書く
//Rキーを押したら機能するようにする
public class ItemController : MonoBehaviour
{
    Vector3 pos;
    void Update()
    {
        //Rキーを押したらデストロイさせる
        if (Input.GetKey(KeyCode.R))
        {
            Destroy();
            GameObject.Destroy(gameObject);
        }
    }
    public void Destroy()
    {
        GameObject[] destroys = GameObject.FindGameObjectsWithTag("Enemy");
        foreach(GameObject enemy_destroys in destroys)
        {
            Destroy(enemy_destroys);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //プレイヤーが触れたらアイテムスロットに移動する
        if (collision.CompareTag("Player"))
        {
            pos.x = ItemManage.instance.ItemSlot.transform.position.x;
            pos.y = ItemManage.instance.ItemSlot.transform.position.y;
            pos.z = 0;
            transform.position = pos;
        }
        
    }
}
