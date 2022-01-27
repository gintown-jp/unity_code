using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class NekoArtM : GimmickP
{
    private Sprite DefaultImg; // デフォルトの画像
    [SerializeField] Sprite hitsImg;//連打して怒った画像
    [SerializeField] GameObject audioSEObj;


    private int clickCount; // クリック数
    //private int clickCountRecord; // クリック数の記録
    private bool isCounting; // クリックを数えているかどうか
    private bool isMashing; // 連打しているかどうか
    private float second; // クリック間の秒数

    [SerializeField] int startCount = 3;//何クリック目から連打中に切り替えるか
    [SerializeField] float interval = 0.6f;// 連打中のクリック間隔

    [SerializeField] GameObject gameMObj;
    private bool thisClick = false;//このオブジェクトがクリックされているか判定


    void Start()
    {
        GimmickInfoSet(25, "猫の絵（ビリヤード）");//ギミックの基本情報をセット：親クラスから呼び出す
        //Debug.Log("ギミックの基本情報をセットしました。" + gimmickID + gimmickName);
        DefaultImg = this.GetComponent<Image>().sprite;
    }

    // Update is called once per frame
    void Update()
    {
        // 左クリックされたとき
        if (thisClick == true)
        {
            // 数えている状態にする
            isCounting = true;

            // 秒数をリセット
            second = 0f;

            // クリック数を1増加
            clickCount++;

            //thisClick変数を初期化
            thisClick = false;
        }


        // 数えているとき
        if (isCounting)
        {
            //texts[5].text = "数えている";
            // 秒数をカウント:Time.deltaTimeは直前のフレームと今のフレーム間で経過した時間[秒] 
            second += Time.deltaTime;

            // 時間切れのとき
            if (second > interval)
            {
                // 数えていない状態にする
                isCounting = false;

                // 連打していない状態にする
                isMashing = false;

                // クリック数を記録
                //clickCountRecord = clickCount;

                // クリック数をリセット
                clickCount = 0;
            }
            // 数えていて連打中でないとき
            else if (!isMashing)
            {
                // ゲージを減らす
                //DecreaseGauge();

                // クリック数が指定の数以上になったとき
                if (clickCount >= startCount)
                {
                    // 連打状態にする
                    isMashing = true;
                }
            }
            // 数えていて連打しているとき
            else
            {
                //texts[5].text = "連打している";
                // ゲージを増やす
                // gaugeAmount += 0.2f * Time.deltaTime;
                // if (gaugeAmount >= 1f) gaugeAmount = 1f;
                // gauge.fillAmount = gaugeAmount;
                resetHits();//変数初期化
                audioSEObj.GetComponent<SoundSE_M>().CatAngerSE();
                this.GetComponent<Image>().sprite = hitsImg;//怒った画像に変更
                Invoke("imgDefalt",1f);//数秒後に画像を戻す
                if (gameMObj.GetComponent<GManager>().GetChaos() < 12)//全体カオス度の最大値12未満ならカオス度を加算する
                {
                    gameMObj.GetComponent<GManager>().PlusChaos();
                }
            }

        }
        // 数えていないとき
        else
        {
            //texts[5].text = "数えていない";

            // ゲージを減らす
            // DecreaseGauge();
        }

    }

    public void thisObjClick()//buttunインスペクターから呼び出し
    {
        thisClick = true;
    }

    private void imgDefalt()//画像をデフォルトに戻してカオス度を加算する
    {
        resetHits();//連打の変数初期化
        this.GetComponent<Image>().sprite = DefaultImg;
    }

    private void resetHits()//連打判定の変数を初期化
    {
        clickCount = 0;
        //clickCountRecord = 0;
        isCounting = false;
        isMashing = false;
    }
}

//連打の判定参考：https://www.ame-name.com/archives/11250