using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SyokubutsuM : GimmickP
{
    void Start()
    {
        GimmickInfoSet(24, "植物");//ギミックの基本情報をセット：親クラスから呼び出す
        //Debug.Log("ギミックの基本情報をセットしました。" + gimmickID + gimmickName);

    }

    public override void SwipeOnEvent(GameObject itemBoxObj,int itemID)//スワイプしてきたアイテムボックスの情報を受け取り実行（スワイプ後のイベント）：オーバーライド
    {
        Debug.Log("SwipeOnEvent()を子クラスで実行しました" + itemBoxObj + "アイテムID");
        //取得したアイテムによってイベントを実行
        if (itemID == 1)
        {
            EvenRun1();
        }
        else
        {
            Debug.Log("イベントは発生しませんでした");
        }
    }

    private void EvenRun1()
    {
        Debug.Log("イベントを実行します");
    }
}
