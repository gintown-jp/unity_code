using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Syashin : ItemP
{
    /*--写真--*/

    void Start()
    {
        ItemParentStart();//デフォルトの画像を取得：親クラスから呼び出す
        ItemInfoSet(1, "写真");//アイテムの基本情報をセット：親クラスから呼び出す
        //Debug.Log("アイテムの基本情報をセットしました。" + itemID + itemName);
    }

  
}
