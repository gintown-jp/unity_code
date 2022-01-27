using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;


public class storyTextM : MonoBehaviour
{
    [SerializeField] GameObject DoorPointOfObj;
    [SerializeField] GameObject PrologueMObj;

    [SerializeField] Text dialogText;
    private string textInfo;
    private string textInfo2;



    // Start is called before the first frame update
    void Start()
    {
        TextSet();
        StartCoroutine(TypeDialog(textInfo));

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void TextSet()
    {
        textInfo = "お姉ちゃんと連絡がとれない・・・。\n" +
            "心配になった私はアパートまで様子を見にきた。\n" +
            "昨日の電話では不思議な事を言っていた。\n" +
            "「ずっとネコの鳴声がする。」\n" +
            "「箱を捨てても戻ってくる。」\n" +
            "私を怖がらせるいつもの冗談だよね。\n";

        textInfo2 = "「４つあったはずなのに見つからない。」って\n" +
            "私に何を伝えたかったんだろう・・・。";
    }

    private IEnumerator TypeDialog(string dialog)//テキストを一文字ずつ表示
    {
        char s = '\n';//改行
        int count = 0;
        dialogText.text = "";
        yield return new WaitForSeconds(1.8f);
        foreach (char letter in dialog)
        {
            count++;
            dialogText.text += letter;
            if (letter == s)
            {
                yield return new WaitForSeconds(0.8f);
            }
            else
            {
                yield return new WaitForSeconds(1f / 15);
            }
        }
        if (count >= dialog.Length)
        {
            StartCoroutine(TypeDialog2(textInfo2));
        }
    }
    private IEnumerator TypeDialog2(string dialog2)//テキストを一文字ずつ表示
    {
        char s = '\n';//改行
        int count = 0;
        yield return new WaitForSeconds(1.5f);
        dialogText.text = "";
        yield return new WaitForSeconds(0.5f);
        foreach (char letter in dialog2)
        {
            count++;
            dialogText.text += letter;
            if (letter == s)
            {
                yield return new WaitForSeconds(0.8f);
            }
            else
            {
                yield return new WaitForSeconds(1f / 15);
            }
            if (count >= dialog2.Length)
            {
                Invoke("ClickOk", 2f);
            }
        }
    }

    public void TextFadeOut()//テキストのフェードアウト
    {
        Text image = this.GetComponent<Text>();
        image.DOFade(0f, 0.5f)
                  .SetEase(Ease.OutSine);
    }


    public void ClickOk()//ドアクリック準備ok
    {
        DoorPointOfObj.GetComponent<DoorM>().DoorColor();
        PrologueMObj.GetComponent<PrologueM>().ClickOn = true;
        TextFadeOut();
    }

}
