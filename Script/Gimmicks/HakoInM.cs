using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;



public class HakoInM : GimmickP
{
    public int itemId;//箱の中身のアイテムID
    private string itemName;
    private Sprite thumImg;
    private string itemObjName;
    public bool touchFlag = true;//タッチできるか判定（画像が何もセットされていない時はfalse）
    private bool pullHako = false;//箱から一度でもアイテムを取り出したらtrue 


    [SerializeField] GameObject GameMObj;//ゲームマネージャーオブジェクト
    [SerializeField] Sprite toumeiImg;//透明画像
    [SerializeField] Sprite tekagamiImg;//手鏡画像
    [SerializeField] Sprite tekagamiThumImg;//手鏡サムネ画像
    [SerializeField] Sprite syashinImg;//写真画像
    [SerializeField] Sprite syashinThumImg;//写真サムネ画像
    [SerializeField] Sprite taiImg;//鯛の画像
    [SerializeField] Sprite taiThumImg;//鯛の画像
    [SerializeField] Sprite taiyakiImg;//鯛焼きの画像
    [SerializeField] Sprite taiyakiThumImg;//鯛焼きのサムネ画像
    [SerializeField] Sprite pieceImg;//ピース画像
    [SerializeField] Sprite pieceThumImg;//ピースのサムネ画像

    private Sprite catImg;//デフォルトの画像（猫の置物）
    [SerializeField] Sprite catThumImg;//猫の置物サムネ画像

    [SerializeField] GameObject catObj;//猫のオブジェクト
    [SerializeField] GameObject kagamiUraObj;//KagamiUraオブジェクト

    [SerializeField] GameObject KagamiPanelObj;//鏡パネルオブジェクト

    void Start()
    {
        GimmickInfoSet(30, "箱の中");//ギミックの基本情報をセット：親クラスから呼び出す
        catImg = this.GetComponent<Image>().sprite;
        itemId = 2;
        thumImg = catThumImg;
        itemName = "黒猫の置物";
        itemObjName = "OkimonoCat";

    }

    public override void SwipeOnEvent(GameObject itemBoxObj, int itemID)//スワイプしてきたアイテムボックスの情報を受け取り実行（スワイプ後のイベント）：オーバーライド
    {
        //Debug.Log("SwipeOnEvent()を子クラスで実行しました" + itemID);
        //取得したアイテムによってイベントを実行
        switch (itemID)
        {
            case 0:
                TekagamiRun();
                break;
            case 1:
                SyasinRun();
                break;
            case 2:
                CatRun();
                break;
            case 3:
                PieceBedRun();
                break;
            case 4:
                PieceCatRun();
                break;
            case 5:
                PieceTanaRun();
                break;
            case 6:
                PieceHachiRun();
                break;
            case 8:
                TaiRun();
                break;
            case 9:
                TaiyakiRun();
                break;
            default:
                //Debug.Log("イベントは発生しませんでした");
                return;
        }
        touchFlag = true;
    }

    private void TekagamiRun()//手鏡
    {
        //Debug.Log("手鏡のイベントを実行します");
        this.GetComponent<Image>().sprite = tekagamiImg;
        itemId = 0;
        thumImg = tekagamiThumImg;
        itemName = "手鏡";
        itemObjName = "Tekagami";
        GirlView();
        KagamiPanelObj.GetComponent<GkPanelM>().girlOneOn();
    }
    private void SyasinRun()//写真
    {
        //Debug.Log("写真のイベントを実行します");
        this.GetComponent<Image>().sprite = syashinImg;
        itemId = 1;
        thumImg = syashinImg;
        itemName = "写真";
        itemObjName = "Syashin";
        GameMObj.GetComponent<GManager>().PlusChaos();
    }
    private void CatRun()//黒猫の置物
    {
        //Debug.Log("黒猫の置物イベントを実行します");
        itemId = 2;
        this.GetComponent<Image>().sprite = catImg;
        thumImg = catImg;
        itemName = "黒猫の置物";
        itemObjName = "OkimonoCat";
        CatView();
    }
    private void PieceBedRun()//ピースベット
    {
        //Debug.Log("写真のイベントを実行します");
        this.GetComponent<Image>().sprite = pieceImg;
        itemId = 3;
        thumImg = pieceThumImg;
        itemName = "ピース";
        itemObjName = "pieceBed";
        GameMObj.GetComponent<GManager>().PlusChaos();

    }
    private void PieceCatRun()//ピースねこ
    {
        //Debug.Log("写真のイベントを実行します");
        this.GetComponent<Image>().sprite = pieceImg;
        itemId = 4;
        thumImg = pieceThumImg;
        itemName = "ピース";
        itemObjName = "pieceCat";
        GameMObj.GetComponent<GManager>().PlusChaos();

    }
    private void PieceTanaRun()//ピース棚
    {
        //Debug.Log("写真のイベントを実行します");
        this.GetComponent<Image>().sprite = pieceImg;
        itemId = 5;
        thumImg = pieceThumImg;
        itemName = "ピース";
        itemObjName = "pieceTana";
        GameMObj.GetComponent<GManager>().PlusChaos();

    }
    private void PieceHachiRun()//ピース鉢
    {
        //Debug.Log("写真のイベントを実行します");
        this.GetComponent<Image>().sprite = pieceImg;
        itemId = 6;
        thumImg = pieceThumImg;
        itemName = "ピース";
        itemObjName = "pieceHachi";
        GameMObj.GetComponent<GManager>().PlusChaos();
    }
    private void TaiRun()//鯛
    {
        //Debug.Log("写真のイベントを実行します");
        this.GetComponent<Image>().sprite = taiImg;
        itemId = 8;
        thumImg = taiThumImg;
        itemName = "鯛";
        itemObjName = "Tai";
        GameMObj.GetComponent<GManager>().PlusChaos();
    }
    private void TaiyakiRun()//鯛焼き
    {
        //Debug.Log("写真のイベントを実行します");
        this.GetComponent<Image>().sprite = taiyakiImg;
        itemId = 9;
        thumImg = taiyakiThumImg;
        itemName = "たい焼き";
        itemObjName = "Tai";
        GameMObj.GetComponent<GManager>().PlusChaos();
    }


    /*クリック（タッチ）したら実行*/
    public void TouchRun()//Buttonコンポーネント、OnClick()に関数を設定する
    {

        if (!touchFlag)//タッチ許可判定
        {
            //Debug.Log("このアイテムは現在タッチできません");
            return;
        }
        if (!pullHako)//箱からアイテムを取り出す最初の１回目だけ実行
        {
            CatFirstPull();
        }
        GameObject itemBoxP = GameObject.FindGameObjectWithTag("ItemBoxP");
        bool boxFree = itemBoxP.GetComponent<ItemBoxPM>().ItemBoxFreeCheck();//アイテムボックスが空かチェック
        if (boxFree)//ここからが問題
        {
            //このアイテムの情報を空いているアイテムボックスにセットする
            itemBoxP.GetComponent<ItemBoxPM>().ItemBoxSelectHako(itemId, thumImg, itemName, itemObjName);
            //アイテムボックスが空なら情報を渡し、このUIの画像を非表示（透明）にする。※箱の中が空の状態にする
            touchFlag = false;
            this.GetComponent<Image>().sprite = toumeiImg;
            itemId = 10;
            //箱の中身と関係するオブジェクトをリセットする
            SomeNoView();
            GiralNoView();
        }
        else
        {
            //アイテムボックスに空きがない事をアニメーションで知らせる
            transform.DOScale(new Vector3(1.15f, 1.15f, 0), 0.15f)
                     .SetEase(Ease.InOutQuart)
                     .SetLoops(2, LoopType.Yoyo);
        }
    }

    /*◇イベント管理◇*/
    private void CatFirstPull()//箱から初めて黒猫置物を取り出した時に全体カオス度に1を代入する（ストーリー進行の起点）→通常の加算に変更
    {
        GameMObj.GetComponent<GManager>().PlusStory();
        GameMObj.GetComponent<GManager>().PlusChaos();

        //GameMObj.GetComponent<GManager>().SetStory(1);
        //GameMObj.GetComponent<GManager>().SetChaos(1);
        pullHako = true;
    }
    private void CatView()//Catオブジェクトを表示
    {
        catObj.GetComponent<CatM>().CatView();
    }
    private void SomeNoView()//Catオブジェクト他を非表示
    {
        catObj.GetComponent<CatM>().CatNoView();
    }
    private void GirlView()//女の子を表示
    {
        kagamiUraObj.GetComponent<KagamiUraM>().girlView();
    }
    private void GiralNoView()//女の子を非表示
    {
        kagamiUraObj.GetComponent<KagamiUraM>().girlNoView();
    }
}
