using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GimmickP : MonoBehaviour
{
    //ギミック親クラス変数
    protected int gimmickID;//ギミックID
    protected string gimmickName;//ギミック名
    protected Sprite gimmickImgDef; // 初期に「Source image」に設定している画像を保存

    private void Start()
    {
        gimmickImgDef = this.GetComponent<Image>().sprite;

    }

    protected void GimmickInfoSet(int ID ,string name)//オブジェクトの基本情報を設定：子クラスから呼び出し
    {
        this.gimmickID = ID;
        this.gimmickName = name;
    }

    public int GetGimmickID()//取得関数：ギミックID
    {
        return this.gimmickID;
    }
    public string GetGimmickName()//取得関数：ギミック名
    {
        return this.gimmickName;
    }
  


    public virtual void SwipeOnEvent(GameObject itemBoxObj,int itemID)//スワイプしてきたアイテムボックスの情報を受け取る：子クラスでオーバーライド：SwipeM3のMoveEndEventFlag()から呼び出し
    {
        Debug.Log("SwipeOnEvent()を実行しました" + itemBoxObj);
        //子クラスでオーバーライド
    }

}
