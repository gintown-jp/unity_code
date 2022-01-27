using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;



public class PassBtnM : MonoBehaviour
{
    [SerializeField] GameObject passPanelObj;
    private Image image;
    private bool btnJuge = true;//ボタンを押していたらfalse
    public int passOrder;//このスクリプトをアタッチしているボタンのパスワードの順番を入力（0～8）
    private void Start()
    {
        image = GetComponent<Image>();

    }
    public void PassBtnOn()//ボタンインスペクターから呼び出し
    {
        if(btnJuge == false) { return; }
        btnJuge = false;
        //Debug.Log(passOrder);
        //ボタンの変化アニメ
        passPanelObj.GetComponent<PassWordM>().PassBtnPush(passOrder);
        image.DOColor(new Color(0.78f, 0.70f, 0.83f), 0f);
    }

    public void PassBtnClear()//PassWordMより呼び出し
    {
        image.DOColor(Color.white, 0.1f);
        btnJuge = true;
    }
    public void BtnNoView()//オブジェクトを透過：PassWordMより呼び出し
    {
        Image image = GetComponent<Image>();
        image.DOFade(0f, 0.5f)
                  .SetDelay(1f)
                  .SetEase(Ease.OutSine);
    }

    public void BtnColorRed()//ボタンのカラーを赤に変更:PassWordMから呼び出し
    {
        //image.DOComplete();
        //ボタンの変化アニメ
        image.DOColor(new Color(0.94f, 0.35f, 0.33f), 0.1f);
    }
    public void BtnColorCyan()//ボタンのカラーを水色に変更:PassWordMから呼び出し
    {
        //ボタンの変化アニメ
        image.DOColor(new Color(0.39f, 0.73f, 0.91f), 0.1f);
    }

}
