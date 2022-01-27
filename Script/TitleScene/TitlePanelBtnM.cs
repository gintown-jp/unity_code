using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TitlePanelBtnM : MonoBehaviour
{
    [SerializeField] GameObject fadeSceneObj;

    public void EscBtnMRun()//ゲーム終了:EscBtnのイベントトリガーから実行
    {
        Application.Quit();
        //UnityEditor.EditorApplication.isPlaying = false;//エディターが再生モードかどうか※build時にはコメントにしないとエラーになる
    }

    public void StartBtnRun()//ゲーム開始：StartBtnのイベントトリガーから実行（mainシーンへ移動）
    {
        fadeSceneObj.GetComponent<SceneFadeM>().fadeOutStart(255, 255, 255, 0, "prologue");
    }

    public void ConfigPanelView()//コンフィグパネルを表示する：ConfigBtnのイベントトリガーから実行（PanelParentObjを動かしている）
    {
        this.transform.parent.parent.gameObject.GetComponent<Transform>().localPosition = new Vector3(-1900, 0, 0);
    }

    public void WebBtnRun()//webサイトを表示する：webBtnのイベントトリガーから実行
    {
        Application.OpenURL("https://gintown.work/");
    }

    public void ReBtnRun()//titlePanelに戻る（表示する）：ReBtnのイベントトリガーから実行
    {
        this.transform.parent.parent.gameObject.GetComponent<Transform>().localPosition = new Vector3(0, 0, 0);
    }

    public void WebKishiiBtnRun()//webサイトを表示する：webBtnのイベントトリガーから実行
    {
        Application.OpenURL("https://gintown.work/index.php/works/boardgame/kishii");
    }

}
