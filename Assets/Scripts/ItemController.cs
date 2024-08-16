using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//(アイテムを使ったら画面にいる)*今はやらない*
//Enemyタグのついた敵を全員デストロイさせるコードを書く
//Rキーを押したら機能するようにする
public class ItemController : MonoBehaviour
{
    
    void Start()
    {
        
    }
    void Update()
    {
        //Rキーを押したらデストロイさせる
        if (Input.GetKey(KeyCode.R))
        {
            Destroy();
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
}
