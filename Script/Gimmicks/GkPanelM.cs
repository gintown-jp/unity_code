using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class GkPanelM : MonoBehaviour
{
    private Vector3 defaultPos; // 初期状態のオブジェクト位置
    private CanvasGroup canvasGroup;//自身のキャンバスグループ

    private bool girlOne = false;//女の子を一度見ているか判定
    private bool girlFlag = false;


    void Start()
    {
        defaultPos = this.transform.localPosition; // 初期のローカル空間での位置を取得
        canvasGroup = this.GetComponent<CanvasGroup>();
        canvasGroup.alpha = 0;
    }

    public void GimmckPanelIn()//パネルを開く
    {
        canvasGroup.DOFade(1, 0.2f)//フェードイン
           .SetEase(Ease.InOutQuart);
        this.transform.DOLocalMove(new Vector3(0, 0, 0), 0)
                      .SetDelay(0.2f);
    }

    public void GimmckPanelOut()//パネルを閉じる
    {
        canvasGroup.DOFade(0, 0.2f)//フェードアウト
           .SetEase(Ease.InOutQuart);
        this.transform.DOLocalMove(defaultPos, 0)
                      .SetDelay(0.2f);
    }

    public void GimmckPanelOutHako()//パネルを閉じる+箱の蓋を閉じる
    {
        canvasGroup.DOFade(0, 0.2f)//フェードアウト
           .SetEase(Ease.InOutQuart);
        this.transform.DOLocalMove(defaultPos, 0)
                      .SetDelay(0.2f);
        GameObject futaObject = this.transform.Find("Futa").gameObject;
        futaObject.GetComponent<FutaM>().FutaClose();
    }

    public void GimmckPanelOutTokei()//パネルを閉じる+時計の針を戻す
    {
        canvasGroup.DOFade(0, 0.2f)//フェードアウト
           .SetEase(Ease.InOutQuart);
        this.transform.DOLocalMove(defaultPos, 0)
                      .SetDelay(0.2f);
        GameObject HariLObj = this.transform.Find("HariL").gameObject;
        GameObject HariSObj = this.transform.Find("HariS").gameObject;
        HariLObj.GetComponent<HariLM>().HariLRe();
        HariSObj.GetComponent<HariSM>().HariSRe();

    }

    public void GimmckPanePhone()//パネルを閉じる+パスワードの初期化
    {
        GimmckPanelOut();
        this.transform.GetChild(0).transform.GetChild(0).transform.Find("PassPanel").GetComponent<PassWordM>().btnCount0();//オブジェクトの順番変更に注意
    }

    public void GimmckPanelInKagami()//パネルを開く+女の子を初めて見た時にカオス度加算
    {
        canvasGroup.DOFade(1, 0.2f)//フェードイン
           .SetEase(Ease.InOutQuart);
        this.transform.DOLocalMove(new Vector3(0, 0, 0), 0)
                      .SetDelay(0.2f);
        if (girlOne == false && girlFlag == true)//女の子を初めて見た時に１度だけ実行
        {
            girlOne = true;
            Invoke("KagamiChaos",0.2f);
            //GameObject GameMObj = GameObject.Find("GameM");
            //GameMObj.GetComponent<GManager>().PlusChaos();//一度だけ全体カオス度を+1
            //GameObject HariLObj = GameObject.Find("HariL");
            //HariLObj.GetComponent<HariLM>().EventOn();//時計の針イベントを実行可能状態にする

        }
    }
    private void KagamiChaos()
    {
        GameObject GameMObj = GameObject.Find("GameM");
        GameMObj.GetComponent<GManager>().PlusChaos();//一度だけ全体カオス度を+1
        GameObject HariLObj = GameObject.Find("HariL");
        HariLObj.GetComponent<HariLM>().EventOn();//時計の針イベントを実行可能状態にする
    }
    public void girlOneOn()//女の子を発生させるか判定：HakoInMから呼び出し
    {
        girlFlag = true;
    }



}
