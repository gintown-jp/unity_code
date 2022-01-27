using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tekagami : ItemP
{
    /*--手鏡--*/

    void Start()
    {
        ItemParentStart();//デフォルトの画像を変数に取得：親クラスから呼び出す
        ItemInfoSet(0, "手鏡");//アイテムの基本情報をセット：親クラスから呼び出す
        //Debug.Log("アイテムの基本情報をセットしました。" + itemID + itemName);
    }
}
