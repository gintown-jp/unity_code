using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;



public class ItemBoxM : MonoBehaviour
{
    private Sprite ViewthumImg = null; //表示中のサムネイル画像
    private Image itemImgC; // Imageコンポーネント(表示中のサムネイル画像) 00
    private string itemObjName; //設定しているIDに該当するアイテムオブジェクトの名前（ヒエラルキー上のアイテムのオブジェクト名） 00


    public int setItemID = 10; //セットしているアイテムのID 00
    private string setItemName; //アイテム名 00
    private Sprite setItemImg; //アイテム画像
    private Sprite setThumImg; //アイテムサムネイル画像
    private string setItemRedName; //アイテムRed名　いらないか・・・
    private Sprite setItemRedImg; //アイテムRed画像
    private Sprite setThumRedImg; //アイテムRedサムネイル画像
    private GameObject Ib_TextObj; //アイテム名を表示する孫要素のオブジェクト
    private GameObject Ib_ImgObj; //アイテム名を表示する子要素のオブジェクト

    private Vector3 defaultPos;//このオブジェクトの初期位置
    [SerializeField] Sprite toumeiImg;//　透明の画像



    // Start is called before the first frame update
    void Start()
    {
        defaultPos = this.transform.position;

        itemImgC = this.GetComponent<Image>();
        Ib_ImgObj = this.transform.GetChild(0).gameObject;//順番で子要素を指定(Img)
        //Debug.Log("Ib_ImgObj " + Ib_TextObj);

        Ib_TextObj = Ib_ImgObj.transform.GetChild(0).gameObject;//順番で子要素を指定(Text)
        //Debug.Log("Ib_TextObj " + Ib_TextObj);

    }




    public void SetItemBox(GameObject obj)//セットするアイテムの情報を受け取る：ItemBoxPMから呼び出し(objはアイテム)
    {
        //Debug.Log("SetItemBox()が実行されました");
        setItemID = obj.GetComponent<ItemP>().GetItemID();
        itemObjName = obj.GetComponent<ItemP>().GetItemObjName();
        this.transform.GetChild(1).gameObject.GetComponent<ReButtonM>().ReButtonOpen();//子要素のRwButtonオブジェクトのImageコンポーネントをOnにする
        if (obj.GetComponent<ItemP>().redFlag)//赤アイテムになっているか判定
        {
            //赤
            itemImgC.sprite = obj.GetComponent<ItemP>().GetRedThumImg();
            //アニメーション+
            setItemName = obj.GetComponent<ItemP>().GetRedItemName();
        }
        else
        {
            //Debug.Log("ノーマル");
            //ノーマル
            itemImgC.sprite = obj.GetComponent<ItemP>().GetThumImg();
            //アニメーション+
            setItemName = obj.GetComponent<ItemP>().GetItemName();

        }
        IB_TextSet();
    }
    public void SetItemBoxHako(int itemId, Sprite thumImg, string itemName, string itemObjNameR)//セットするアイテムの情報を受け取る：ItemBoxPMから呼び出し
    {
        //Debug.Log("SetItemBoxHako()が実行されました");
        setItemID = itemId;
        itemObjName = itemObjNameR;
        this.transform.GetChild(1).gameObject.GetComponent<ReButtonM>().ReButtonOpen();//子要素のRwButtonオブジェクトのImageコンポーネントをOnにする
        itemImgC.sprite = thumImg;
        setItemName = itemName;
        IB_TextSet();
    }

    private void IB_TextSet()//アイテム名を子要素のTextオブジェクトに渡しセットする
    {
        Ib_TextObj.GetComponent<IB_TextM>().ItemGetSetName(setItemName);
    }

    public void TouchNameView()//タッチした瞬間アイテム名を表示し、2秒後又はスワイプに移行した時に非表示にする：イベントトリガーから呼び出し
    {
        if (setItemID == 10)
        {
            return;
        }
        Ib_ImgObj.GetComponent<IB_ImgM>().ItemNameOpen();
        Ib_TextObj.GetComponent<IB_TextM>().ItemNameTOpen();
        Invoke("TouchNameClose", 1.5f);
    }
    private void TouchNameClose()//アイテム名を閉じる：TouchNameView()のInvokeから呼び出し
    {
        Ib_ImgObj.GetComponent<IB_ImgM>().ItemNameClose();
        Ib_TextObj.GetComponent<IB_TextM>().ItemNameTClose();
    }

    public string GetItemObjName()//所持しているアイテムのヒエラルキー上のオブジェクト名：取得関数
    {
        return itemObjName;
    }

    public void ItemReturn()//設定されているアイテムを返却する（空の状態にする）:ReButtonMから呼び出し
    {
        this.transform.GetChild(1).gameObject.GetComponent<ReButtonM>().ReButtonClose();//子要素のRwButtonオブジェクトのImageコンポーネントをOffにする
        //ItemBoxParentオブジェクトを「空」に設定
        GameObject parentObj = this.transform.parent.gameObject;
        parentObj.GetComponent<ItemBoxPM>().KaraSet(this.gameObject);
        //アイテムオブジェクトを表示する
        GameObject itemObj = GameObject.Find(itemObjName);
        itemObj.GetComponent<ItemP>().ImgView();
        itemObj.GetComponent<ItemP>().SetTouchFlagT();
        //このスクリプト内の変数を「空」に設定
        setItemID = 10;
        itemImgC.sprite = toumeiImg;
        setItemName = null;
        itemObjName = null;
    }

    public void ItemReturnHako()//設定されているアイテムを空の状態にする(箱に入れた演出):SwipeM3から呼び出し
    {
        TouchNameClose();
        this.transform.GetChild(1).gameObject.GetComponent<ReButtonM>().ReButtonClose();//子要素のRwButtonオブジェクトのImageコンポーネントをOffにする
        //ItemBoxParentオブジェクトを「空」に設定
        GameObject parentObj = this.transform.parent.gameObject;
        parentObj.GetComponent<ItemBoxPM>().KaraSet(this.gameObject);
        //このスクリプト内の変数を「空」に設定
        setItemID = 10;
        itemImgC.sprite = toumeiImg;
        setItemName = null;
        itemObjName = null;
    }

    public void ItemBoxFullAnime()//全てのItemBoxに空がないときに実行するアニメーション：ItemBoxPMのItemBoxFreeCheck()から呼び出し
    {
        //ItemPのTouchRun()と同じ設定にする
        transform.DOScale(new Vector3(1.15f, 1.15f, 0), 0.15f)
                 .SetEase(Ease.InOutQuart)
                 .SetLoops(2, LoopType.Yoyo);
    }
}
