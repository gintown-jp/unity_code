using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorkBoardM : GimmickP
{
    [SerializeField] GameObject syashin5Obj;//真ん中の写真の女の子の写真がセットされるゲームオブジェクト

    void Start()
    {
        GimmickInfoSet(4, "コルクボード");//ギミックの基本情報をセット：親クラスから呼び出す
    }

    public override void SwipeOnEvent(GameObject itemBoxObj, int itemID)//スワイプしてきたアイテムボックスの情報を受け取り実行（スワイプ後のイベント）：オーバーライド：SwipeM3から呼び出し
    {
        syashin5Obj.GetComponent<syashin5M>().jugeImgOn();
        syashin5Obj.GetComponent<syashin5M>().ImgChange();//女の子の写真を切り替え
    }
}
