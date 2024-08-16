using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
//(アイテムを使ったら画面にいる)*今はやらない*
//Enemyタグのついた敵を全員デストロイさせるコードを書く
//Rキーを押したら機能するようにする
public class ItemController : MonoBehaviour
{
    Vector3 pos;
    bool m_get = false;
    void Update()
    {
        //Rキーを押したらデストロイさせる
        if (m_get == true)
        {
            if (Input.GetKey(KeyCode.R))
            {
                Destroy();
                GameObject.Destroy(gameObject);
            }
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
            var ipos = ItemManage.instance.ItemSlot.transform.position;
            pos.x = ipos.x;
            pos.y = ipos.y;
            pos.z = 0;
            m_get = true;
            transform.position = pos;
        }
        
    }
}
