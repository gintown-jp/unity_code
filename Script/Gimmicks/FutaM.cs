using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FutaM : GimmickP
{//ゲームクリア

    private Vector3 closetPos;//蓋が閉まっている時の位置
    private Vector3 openPos;//蓋が開いている時の位置
    [SerializeField] Sprite pieceRedImg;//ピースが埋まった画像
    [SerializeField] GameObject GameManagerObj;
    private bool FutaOn = true;//蓋にピースをはめられるか判定(蓋が閉まっている時はtrue)

    [SerializeField] GameObject fadeSceneObj;//フェードアウト用のオブジェクト
    [SerializeField] GameObject audioObjSE;

    // Start is called before the first frame update
    void Start()
    {
        GimmickInfoSet(1, "箱の蓋");//ギミックの基本情報をセット：親クラスから呼び出す
        closetPos = new Vector3(-52, 45, 0);
        openPos = new Vector3(-468, 130, 0);
    }

    public override void SwipeOnEvent(GameObject itemBoxObj, int itemID)//スワイプしてきたアイテムボックスの情報を受け取り実行（スワイプ後のイベント）：オーバーライド
    {
        if(FutaOn == false) { FutaTap(); }//蓋が開いている時実行。
        Debug.Log("SwipeOnEvent()を子クラスで実行しました" + itemBoxObj + "アイテムID");
        //取得したアイテムによってイベントを実行
        if (itemID >= 3 && itemID <= 6)//ピース時のイベント
        {
            EvenRun1();
        }
        else
        {
            Debug.Log("イベントは発生しませんでした");
        }
    }
    private void EvenRun1()//赤いピースをはめる
    {
        audioObjSE.GetComponent<SoundSE_M>().KachiSE();
        var pieceCount = GameManagerObj.GetComponent<GManager>().pieceCount;
        if(pieceCount >= 3)
        {
            //ゲームクリア☆

            transform.GetChild(pieceCount).gameObject.GetComponent<Image>().sprite = pieceRedImg;
            GameManagerObj.GetComponent<GManager>().pieceCount = pieceCount + 1;
            GameManagerObj.GetComponent<GManager>().SetStory(6);


            //Invoke("GameClearTo",3f);
            //GameClearTo();
            return;
        }
        transform.GetChild(pieceCount).gameObject.GetComponent<Image>().sprite = pieceRedImg;
        GameManagerObj.GetComponent<GManager>().pieceCount = pieceCount + 1;
    }
    public void FutaTap()//蓋をタップした時の開閉：イベントトリガーから呼び出し
    {
        if (this.transform.localPosition == openPos)
        {
            this.transform.localPosition = closetPos;
            FutaOn = true;
        }
        else
        {
            this.transform.localPosition = openPos;
            FutaOn = false;
        }
    }
    public void FutaClose()//蓋を閉める
    {
        this.transform.localPosition = closetPos;
    }

    private void GameClearTo()//ゲームクリアシーンへの移動と演出
    {
        GameManagerObj.GetComponent<GManager>().EndVarSet(1);//クリアを代入
        fadeSceneObj.GetComponent<SceneFadeM>().fadeOutStart(255, 255, 255, 0, "gameClear");
    }

}
