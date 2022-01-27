using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;



public class GameOverM : MonoBehaviour
{
    private int resultEndVar;//エンド変数取得用
    [SerializeField] Sprite hakonekoImg;
    [SerializeField] Sprite kagamiImg;
    [SerializeField] Sprite syashinImg;
    private string endInfo;//エンド事の説明文

    [SerializeField] GameObject EndImgObj;
    [SerializeField] Text dialogText;
    [SerializeField] GameObject TitleBtnObj;


    // Start is called before the first frame update
    void Start()
    {
        resultEndVar = GManager.GetEndVar();
        //resultEndVar = 3;

        endImgSet();
        endImgFadeIn();
        StartCoroutine(TypeDialog($"{endInfo}"));
        BtnFadeIn();

    }


    private void endImgSet()//エンド判定
    {
        switch (resultEndVar)
        {
            case 2://箱猫エンド
                EndImgObj.gameObject.GetComponent<Image>().sprite = hakonekoImg;
                endInfo = "クロネコEND";
                break;
            case 3://鏡エンド
                EndImgObj.gameObject.GetComponent<Image>().sprite = kagamiImg;
                endInfo = "カガミEND";
                break;
            case 4://写真エンド
                EndImgObj.gameObject.GetComponent<Image>().sprite = syashinImg;
                endInfo = "シャシンEND";
                break;
            default:
                break;
        }
    }

    private void endImgFadeIn()//画像をフェードイン
    {
        Image image = EndImgObj.GetComponent<Image>();
        image.DOFade(1f, 1.5f)
                  .SetDelay(1.8f)
                  .SetEase(Ease.OutSine);
    }

    private IEnumerator TypeDialog(string dialog)//テキストを一文字ずつ表示
    {
        dialogText.text = "";
        yield return new WaitForSeconds(1.8f);
        foreach (char letter in dialog)
        {
            dialogText.text += letter;
            yield return new WaitForSeconds(1f / 20);
        }
    }

    private void BtnFadeIn()//ボタンをフェードイン
    {
        Image image = TitleBtnObj.GetComponent<Image>();
        image.DOFade(1f, 1.5f)
                  .SetDelay(3f)
                  .SetEase(Ease.OutSine);
    }

}
