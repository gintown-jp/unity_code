using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


public class ItemP : MonoBehaviour
{
    //アイテム親クラス変数
    protected int itemID;//アイテムID
    protected string itemName;//アイテム名
    protected Sprite itemImg;//アイテム画像　※画像系は後でシリアライズフィールドをセット
    [SerializeField] protected Sprite thumImg;//アイテムサムネイル画像
    protected string itemRedName;//アイテムRed名
    protected Sprite itemRedImg;//アイテムRed画像
    protected Sprite thumRedImg;//アイテムRedサムネイル画像

    [SerializeField] protected Sprite toumeiImg;// 透過時の画像
    protected Sprite itemImgDef; // 初期に「Source image」に設定している画像を保存

    public bool touchFlag = true;//タッチできるか判定（画像がアイテムボックスにセットされている時はfalse）
    public bool redFlag = false;//アイテムが赤に変化しているか判定


    protected void ItemParentStart()//子クラスのStart()で最初に実行させる関数
    {
        itemImgDef = this.GetComponent<Image>().sprite;
    }

    protected void ItemInfoSet(int ID, string name)//アイテムの基本情報を設定：子クラスから呼び出し
    {
        this.itemID = ID;
        this.itemName = name;
        //this.itemImg = img;
    }

    /*プレイヤーがアイテム取得時にアイテムボックスから呼び出す関数*/
    public int GetItemID()//取得関数：アイテムID
    {
        return this.itemID;
    }
    public string GetItemName()//取得関数：アイテム名
    {
        return this.itemName;
    }
    public Sprite GetItemImg()//取得関数：アイテム画像
    {
        return this.itemImg;
    }
    public Sprite GetThumImg()//取得関数：アイテムサムネイル画像
    {
        return this.thumImg;
    }
    public string GetRedItemName()//取得関数：アイテム赤名
    {
        return this.itemRedName;
    }
    public Sprite GetRedItemImg()//取得関数：アイテム赤画像
    {
        return this.itemRedImg;
    }
    public Sprite GetRedThumImg()//取得関数：アイテム赤サムネイル画像
    {
        return this.thumRedImg;
    }
    public string GetItemObjName()//取得関数：アイテムオブジェクトの名前
    {
        return this.gameObject.name;
    }

    /*セッター*/
    public void SetViewImg(Sprite img)//表示画像の設定
    {
        this.GetComponent<Image>().sprite = img;
    }
    public void ImgView()//透明状態になっていた画像(アニメ含む)を変更し表示する:ItemBoxMから呼び出し
    {
        if (redFlag)
        {
            SetViewImg(itemRedImg);
        }
        else
        {
            SetViewImg(itemImgDef);
        }
        AnimeView();//アニメを表示
        //Debug.Log("ImgView()を実行しました");

    }
    public void SetTouchFlagT()//touchFlagにtrueを設定
    {
        this.touchFlag = true;
    }


    /*クリック（タッチ）したら実行*/
    public void TouchRun()//Buttonコンポーネント、OnClick()に関数を設定する
    {
        //Debug.Log("TouchRun");
        if (!touchFlag)//タッチ許可判定
        {
            //Debug.Log("このアイテムは現在タッチできません");
            return;
        }
        GameObject itemBoxP = GameObject.FindGameObjectWithTag("ItemBoxP");
        bool boxFree = itemBoxP.GetComponent<ItemBoxPM>().ItemBoxFreeCheck();//アイテムボックスが空かチェック
        if (boxFree)
        {
            //このアイテムの情報を空いているアイテムボックスにセットする
            itemBoxP.GetComponent<ItemBoxPM>().ItemBoxSelect(itemID,this.gameObject);
            //アイテムボックスが空なら情報を渡し、このUIの画像を非表示（透明）にする
            touchFlag = false;
            SetViewImg(toumeiImg);//透過画像に変更


        }
        else
        {
            //アイテムボックスに空きがない事をアニメーションで知らせる
            transform.DOScale(new Vector3(1.15f, 1.15f, 0), 0.15f)
                     .SetEase(Ease.InOutQuart)
                     .SetLoops(2, LoopType.Yoyo);
        }
    }

    /*透明画像をセットする*/
    protected void toumeiSet()
    {
        this.GetComponent<Image>().sprite = toumeiImg;
    }

    /*アイテムを返却したら実行。アニメを表示：ItemBoxMのItemReturn関数から呼び出し*/
    protected virtual void AnimeView()
    {
        //子クラスでオーバーライド
    }

}
