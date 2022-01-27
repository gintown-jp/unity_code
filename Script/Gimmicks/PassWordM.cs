using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PassWordM : MonoBehaviour
{
    bool[] arryBtn = new bool[9];//配列を定義0から8番まで作成
    private bool passJuge = false;//正しいパスワードが入力されたか判定
    private int btnCount = 0;
    [SerializeField] GameObject GameMObj;
    [SerializeField] GameObject LockImgObj;

    void Start()//配列を0で初期化
    {
      for(int i = 0; i < arryBtn.Length; i++)
        {
            arryBtn[i] = false;
        }
    }

    public void PassBtnPush(int btn)//押したボタンから返された数値がbtnCountの値と一致しているか判定：PassBtnMから呼び出し
    {
        if (btnCount >= 9) { return; }
        if (btnCount + 1 == btn)
        {
            arryBtn[btnCount] = true;
        }
        else
        {
            arryBtn[btnCount] = false;
        }
        btnCount++;


        if (btnCount == 9)//9回目を押したタイミングで配列を操作
        {
            for (int i = 0; i < 9; i++)
            {
                if (arryBtn[i] == false)
                {
                    //間違い確定処理から抜ける
                    passJuge = false;
                    //Debug.Log("passNo");
                    BtnRedChange();
                    LockImgObj.GetComponent<PassLockImgM>().ErrorImgSet();
                    return;
                }
            }
            //正しいパスワードが入力されたことを確定
            passJuge = true;
            //Debug.Log("passOk");
            BtnCyanChange();
            PassPanelClose();
            //画面が消えるアニメ!
        }

    }

    private void PassPanelClose()//パスワード画面とボタンの消去
    {
        LockImgObj.GetComponent<PassLockImgM>().ClearImgSet();
        Image image = GetComponent<Image>();
        image.DOFade(0f,0.5f)
                  .SetDelay(1f)
                  .SetEase(Ease.OutSine);
        for (int i = 0; i < arryBtn.Length; i++)
        {
            transform.GetChild(i).gameObject.GetComponent<PassBtnM>().BtnNoView();
        }
        GameMObj.GetComponent<GManager>().PlusStory();//ストーリー進行度に1加算
        Invoke("ObjNoView", 1.5f);
    }
    private void ObjNoView()//このオブジェクトを非アクティブにする
    {
        this.gameObject.SetActive(false);
    }


    public void btnCount0()//PhonePanelを閉じた時に実行。設定を初期化する。//GlPanelMより呼び出し
    {
        if(this.gameObject.activeSelf == false) { return; }//既に非アクティブな状態の時は実行させない
        btnCount = 0;
        for (int i = 0; i < arryBtn.Length; i++)
        {
            arryBtn[i] = false;
            transform.GetChild(i).gameObject.GetComponent<PassBtnM>().PassBtnClear();
        }
        LockImgObj.GetComponent<PassLockImgM>().LockImgSet();
    }

    private void BtnRedChange()//エラーの時にボタンを赤くする
    {
        for(int i = 0; i < this.transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.GetComponent<PassBtnM>().BtnColorRed();
        }
    }
    private void BtnCyanChange()//パス解除の時にボタンを水色する
    {
        for (int i = 0; i < this.transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.GetComponent<PassBtnM>().BtnColorCyan();
        }
    }

}
