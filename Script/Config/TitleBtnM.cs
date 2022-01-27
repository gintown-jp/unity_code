using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;



public class TitleBtnM : MonoBehaviour
{
    [SerializeField] GameObject fadeSceneObj;
    [SerializeField] GameObject TitlePanelObj;
    private Vector3 TitlePos;

    void Start()
    {
        TitlePos = TitlePanelObj.transform.localPosition;//TitlePanelのローカル位置を取得
    }


    // Start is called before the first frame update
    public void ChangeSceneTitle()//タイトルシーンへ移動
    {
        fadeSceneObj.GetComponent<SceneFadeM>().fadeOutStart(255,255,255,0, "title");

    }

    public void TitlePanelIn()//TitlePanelObj表示
    {
        TitlePanelObj.GetComponent<Transform>().DOScale(1f, 0.1f).
            SetEase(Ease.InOutQuart);
        TitlePanelObj.transform.localPosition = new Vector3(0, 0, 0);
    }

    public void TitlePanelOut()//TitlePanelObj非表示
    {
        TitlePanelObj.GetComponent<Transform>().DOScale(0.9f, 0.1f).
            SetEase(Ease.InOutQuart);
        TitlePanelObj.transform.localPosition = TitlePos;
    }

}
