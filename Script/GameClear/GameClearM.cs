using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.IO;
using System;




public class GameClearM : MonoBehaviour
{
    private int resultEndVar;//エンド変数取得用
    [SerializeField] Text dialogText;
    [SerializeField] GameObject TitleBtnObj;
    [SerializeField] GameObject girlImgObj;
    [SerializeField] GameObject kagamiImgObj;
    [SerializeField] GameObject GameClearObj;

    private string endInfo;//エンド事の説明文
    private string endInfo2;//エンド事の説明文
    [SerializeField] Sprite end_nekoImg;



    //クリア後のタイトル画面変化
    string folderPathC;//対象ディレクトリを格納
    string filePathC;//対象ファイルを格納
    FileStream fsC = null;




    // Start is called before the first frame update
    void Start()
    {
        resultEndVar = GManager.GetEndVar();

        TextSet();
        StartCoroutine(TypeDialog($"{endInfo}"));
        GirlFadeIn(girlImgObj);




        /*--取得したパスにオリジナルのパスを結合--*/
        //folderPath1 = Path.Combine(Application.dataPath, @"Script\Save\SubFolder1");(andoroidはApplication.dataPathだと結果が得られない、windows ios は大丈夫):https://techblog.kayac.com/unity_advent_calendar_2018_14
        folderPathC = Path.Combine(Application.persistentDataPath, @"Script\Save\SubFolderC");
        filePathC = Path.Combine(folderPathC, "dataC.txt");



        FileCheckCreate();//ディレクトとファイルがあるか確認しなければ作成

        FileStream fs = new FileStream(//インスタンス化？:https://programming.pc-note.net/csharp/filestream.html
        filePathC, FileMode.OpenOrCreate, FileAccess.ReadWrite);

        fsC = fs;
        fsC.Dispose();//リソース解放


    }


    private void TextSet()
    {
        endInfo = "振り返ると、そこにはお姉ちゃんがいた。\n" +
            "はじめはボーっとしていたけど、\n" +
            "駆け寄って抱きしめると わんわん泣き出した。\n" +
            "私もたくさん泣いた。\n" +
            "無事に見つかって本当に良かった。\n"
            ;


        endInfo2 = "あの箱の正体について聞いてみたけれど、\n" +
            "お姉ちゃんもよくわからないみたいだった。\n" +
            "気付いたら部屋の隅にあったらしい。\n" +
            "もう誰の元にも現れなければいいけど・・・。\n"
            ;
        ;

    }
    private IEnumerator TypeDialog(string dialog)//テキストを一文字ずつ表示
    {
        char s = '\n';//改行
        int count = 0;
        dialogText.text = "";
        yield return new WaitForSeconds(3.5f);
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
            StartCoroutine(TypeDialog2(endInfo2));
        }
    }
    private IEnumerator TypeDialog2(string dialog2)//テキストを一文字ずつ表示
    {
        char s = '\n';//改行
        int count = 0;
        yield return new WaitForSeconds(2.5f);
        GirlFadeOut(girlImgObj);
        GirlFadeOut(kagamiImgObj);
        dialogText.text = "";
        yield return new WaitForSeconds(1.8f);
        girlImgObj.GetComponent<Image>().sprite = end_nekoImg;//女の子から箱と猫の画像に変更
        GirlFadeIn2(girlImgObj);
        yield return new WaitForSeconds(2.5f);
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
                TitleBtnObj.GetComponent<Image>().raycastTarget = true;
                yield return new WaitForSeconds(1.2f);
                GirlFadeIn2(GameClearObj);
                yield return new WaitForSeconds(1.7f);
                GirlFadeIn2(TitleBtnObj);
            }
        }
    }

    private void BtnFadeIn(GameObject obj)//ボタンをフェードイン
    {
        Image image = obj.GetComponent<Image>();
        image.DOFade(1f, 2f)
                  .SetDelay(3f)
                  .SetEase(Ease.OutSine);
    }
    private void GirlFadeIn(GameObject obj)//女の子画像をフェードイン
    {
        Image image = obj.GetComponent<Image>();
        image.DOFade(1f, 2f)
                  .SetDelay(2.5f)
                  .SetEase(Ease.OutSine);
    }
    private void GirlFadeOut(GameObject obj)//女の子画像をフェードアウト
    {
        Image image = obj.GetComponent<Image>();
        image.DOFade(0f, 1.5f)
                  .SetEase(Ease.OutSine);
    }
    private void GirlFadeIn2(GameObject obj)//女の子画像をフェードイン2
    {
        Image image = obj.GetComponent<Image>();
        image.DOFade(1f, 2f)
                  .SetEase(Ease.OutSine);
    }


    /*--ゲームクリアセーブ関連--*/
    public void FileCheckCreate()//ディレクトとファイルがあるか確認しなければ作成
    {
        if (!Directory.Exists(folderPathC))
        {
            //Debug.Log(folderPath1 + "は存在しません。");
            Directory.CreateDirectory(folderPathC);
        }
        else
        {
            //Debug.Log("該当ディレクトあり");
        }
        if (!File.Exists(filePathC))
        {
            //Debug.Log(filePath1 + "は存在しません。");
            File.WriteAllText(filePathC, "1");
        }
        else
        {
            //Debug.Log("該当ファイルあり");
        }
        //fs1.Dispose();
    }

}

