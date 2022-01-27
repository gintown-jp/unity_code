using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class OpenPanelM : MonoBehaviour
{
    [SerializeField] GameObject gameMObj;
    [SerializeField] GameObject pieceHachiObj;
    public void TalkBtnOn()//TalkBtnオブジェクトのボタンから呼び出し
    {
        gameMObj.GetComponent<GManager>().PlusChaos();//全体カオス度を+1する

        pieceHachiObj.GetComponent<PieceHachi>().PieceHachiSet();//鉢オブジェクト上にピースアイテムをセット。

        this.transform.GetChild(0).gameObject.transform.DOScale(1.1f, 0.3f);//talkBtnオブジェクト
        this.transform.GetChild(0).gameObject.transform.DOScale(1f, 0.3f).SetDelay(0.3f);//talkBtnオブジェクト
        Invoke("ObjNoView", 0.8f);
    }
    private void ObjNoView()//このオブジェクトを非アクティブにする
    {
        this.gameObject.SetActive(false);
        this.transform.GetChild(0).gameObject.SetActive(false);
    }
}
