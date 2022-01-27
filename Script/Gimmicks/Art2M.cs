using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Art2M : GimmickP
{
    private Sprite DefaultImg;//デフォルトの画像
    [SerializeField] Sprite correctAnime;
    [SerializeField] Sprite missAnime;
    [SerializeField] Sprite taiyakiThum;
    public float invokeTime;

    [SerializeField] GameObject goBuckBtnObj;
    [SerializeField] GameObject taiObj;
    [SerializeField] GameObject gameMObj;
    [SerializeField] GameObject AudioObjSE;

    void Start()
    {
        GimmickInfoSet(31, "絵画2");//ギミックの基本情報をセット：親クラスから呼び出す
        //Debug.Log("ギミックの基本情報をセットしました。" + gimmickID + gimmickName);
        DefaultImg = this.GetComponent<Image>().sprite;
    }

    public override void SwipeOnEvent(GameObject itemBoxObj, int itemID)//スワイプしてきたアイテムボックスの情報を受け取り実行（スワイプ後のイベント）：オーバーライド
    {
        Debug.Log("SwipeOnEvent()を子クラスで実行しました" + itemID);
        //取得したアイテムが鯛かどうか判定
        if (itemID == 8)
        {
            //鯛の時に実行
            AudioObjSE.GetComponent<SoundSE_M>().BakeSE();

            //戻るボタン一時停止
            goBuckBtnObj.GetComponent<Button>().enabled = false;
            goBuckBtnObj.GetComponent<Image>().enabled = false;

            //正解アニメ
            this.GetComponent<Image>().sprite = correctAnime;
            //スワイプしてきた鯛がセットされているアイテムボックスを一度空にする
            itemBoxObj.GetComponent<ItemBoxM>().ItemReturnHako();

            //ストーリー進行度に+1、全体カオス度に+1
            gameMObj.GetComponent<GManager>().PlusStory();
            gameMObj.GetComponent<GManager>().PlusChaos();

            //オブジェクトをデフォルトに戻す
            Invoke("ObjTaiyaki", invokeTime);
        }
        else
        {
            //鯛以外の時に実行
            AudioObjSE.GetComponent<SoundSE_M>().CatAngerSE();

            goBuckBtnObj.GetComponent<Button>().enabled = false;
            goBuckBtnObj.GetComponent<Image>().enabled = false;

            //全体カオス度に+1
            gameMObj.GetComponent<GManager>().PlusChaos();

            //間違いアニメ
            this.GetComponent<Image>().sprite = missAnime;
            //オブジェクトをデフォルトに戻す
            Invoke("ObjDefault", invokeTime);

        }

    }
    private void ObjDefault()//オブジェクトをデフォルトに戻す
    {
        //戻るボタン一時停止解除
        goBuckBtnObj.GetComponent<Button>().enabled = true;
        goBuckBtnObj.GetComponent<Image>().enabled = true;

        this.GetComponent<Image>().sprite = DefaultImg;
    }
    private void ObjTaiyaki()//たい焼きを渡しオブジェクトをデフォルトに戻す
    {
        //たい焼きを返却
        GameObject itemBoxP = GameObject.FindGameObjectWithTag("ItemBoxP");
        itemBoxP.GetComponent<ItemBoxPM>().ItemBoxSelectHako(9, taiyakiThum, "たい焼き", "Tai");//itemID、itemのサムネイル画像、itemの表示名、アイテムのオブジェクト名
        taiObj.GetComponent<Tai>().TaiyakiImgSet();//Taiオブジェクトにたい焼き画像を準備
        //戻るボタン一時停止解除
        goBuckBtnObj.GetComponent<Button>().enabled = true;
        goBuckBtnObj.GetComponent<Image>().enabled = true;

        this.GetComponent<Image>().sprite = DefaultImg;
    }


}
