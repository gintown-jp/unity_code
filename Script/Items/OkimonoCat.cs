using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OkimonoCat : ItemP
{
    /*--黒猫の置物--*/

    void Start()
    {
        ItemParentStart();//デフォルトの画像を変数に取得：親クラスから呼び出す
        ItemInfoSet(2, "黒猫の置物");//アイテムの基本情報をセット：親クラスから呼び出す
        //Debug.Log("アイテムの基本情報をセットしました。" + itemID + itemName);
        toumeiSet();//初期は箱の中にある設定のため透明画像をセット
    }
}
