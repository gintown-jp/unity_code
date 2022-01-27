using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MoniterM : MonoBehaviour
{

    [SerializeField] GameObject GameManagerObj;
    [SerializeField] GameObject MonitorButtonObj;
    [SerializeField] GameObject MoniterPanelObj;

    [SerializeField] Sprite MoniBtnOnImg;//モニターボタンの画像
    [SerializeField] Sprite MoniBtnOffImg;//モニターボタンの画像
    [SerializeField] Sprite MoniterOnImg;//このオブジェクトのモニター点灯画像
    private Sprite DeffultImg;//最初に表示されている画像

    public int moniterLevel = 0;//モニターの状態
    private bool moniterSwich = false;//モニターがON：true。モニターがOFF：false。
    public int beforeCLevel = 0;//ひとつ前のカオスレベル（比較用）

    [SerializeField] GameObject audioObj;
    [SerializeField] GameObject audioObjSE;


    private void Start()
    {
        DeffultImg = this.GetComponent<Image>().sprite;
        MoniterPanelObj.GetComponent<Animator>().SetInteger("monitorCh", 3);
    }

    private void Update()
    {
        if (moniterLevel == 0) return;
        MoniterRun();

    }

    public void MoniterBtnClick()//モニター表示中にモニターボタンがクリックされた時に実行:ボタンコンポーネントから実行
    {
        if (moniterSwich == false) return;//モニターがOFFなら抜ける。
        audioObj.GetComponent<VolumeM>().SetBGM(1);//ノイズ音
        if (moniterLevel == 4 || moniterLevel == 8)//モニターレベルが4か8の時にカオス度を加算（←カラスの後にすぐ誰もいない映像になる原因）
        {
            Invoke("ChaosPlus",0.2f);//カオス度を加算
        }
        beforeCLevel = GetChoasLevel();//現在の全体カオスレベルを取得
    }
    private void ChaosPlus()
    {
        GameManagerObj.GetComponent<GManager>().PlusChaos();//カオス度を加算
    }
    public void ReturnBtnClick()//GoBuckBtnを押したときに実行：GoBuckBtnから呼び出し
    {
        if (moniterSwich == false) return;//モニターがOFFなら抜ける。
        MoniterOff();
        MoniterBtnOff();
        audioObj.GetComponent<VolumeM>().StopBGM();//ノイズ音
        moniterSwich = false;
        moniterLevel ++;
        if (moniterLevel > 9) moniterLevel = 9;
    }

    private void MoniterRun()//モニターレベルと全体カオス度からイベントを制御（モニターの状態がfalseの時に実行）
    {
        if (moniterSwich) return;//モニターがONなら抜ける。
        //モニターを制御
        switch (moniterLevel)
        {
            case 1:
                //モニターが点く（誰もいない）
                StartCoroutine("PinPon");
                MoniterOn();
                MoniterBtnOn();
                moniterSwich = true;
                MoniterPanelObj.GetComponent<Animator>().SetInteger("monitorCh", 0);
                break;
            case 2:
                //消灯
                ChoasLevelJudge();
                MoniterPanelObj.GetComponent<Animator>().SetInteger("monitorCh", 3);
                break;
            case 3:
                //モニターが点く（カラス）
                StartCoroutine("PinPon");
                MoniterOn();
                MoniterBtnOn();
                moniterSwich = true;
                MoniterPanelObj.GetComponent<Animator>().SetInteger("monitorCh", 1);
                break;
            case 4:
                //消灯
                ChoasLevelJudge();
                MoniterPanelObj.GetComponent<Animator>().SetInteger("monitorCh", 3);
                break;
            case 5:
                //モニターが点く（誰もいない）
                StartCoroutine("PinPon");
                MoniterOn();
                MoniterBtnOn();
                moniterSwich = true;
                MoniterPanelObj.GetComponent<Animator>().SetInteger("monitorCh", 0);
                break;
            case 6:
                //消灯
                ChoasLevelJudge();
                MoniterPanelObj.GetComponent<Animator>().SetInteger("monitorCh", 3);
                break;
            case 7:
                //モニターが点く（お化け）
                StartCoroutine("PinPon");
                MoniterOn();
                MoniterBtnOn();
                moniterSwich = true;
                MoniterPanelObj.GetComponent<Animator>().SetInteger("monitorCh", 2);
                break;
            case 8:
                //ドアの外にいる
                MoniterPanelObj.GetComponent<Animator>().SetInteger("monitorCh", 3);
                break;
            case 9:
                //消灯
                MoniterPanelObj.GetComponent<Animator>().SetInteger("monitorCh", 3);
                break;
            default:
                break;

        }


    }

    private void MoniterOn()//モニターの画像を点灯する
    {
        this.GetComponent<Image>().sprite = MoniterOnImg;
    }
    private void MoniterOff()//モニターの画像を消灯する
    {
        this.GetComponent<Image>().sprite = DeffultImg;
    }

    private void MoniterPanelOn()//モニターパネルを表示する
    {
        GameObject MonitorPanel = transform.Find("MonitorPanel").gameObject;
        //アニメーション表示・非表示
        //アニメーショントリガー変更
        //全体カオス度加算
    }

    private void MoniterBtnOn()//ギミックのモニターボタンを点灯する
    {
        MonitorButtonObj.GetComponent<Image>().sprite = MoniBtnOnImg;
    }
    private void MoniterBtnOff()//ギミックのモニターボタンを消灯する
    {
        MonitorButtonObj.GetComponent<Image>().sprite = MoniBtnOffImg;
    }
    private int GetChoasLevel()//カオスレベルを取得
    {
        int i = GameManagerObj.GetComponent<GManager>().GetChaos();
        return i;
    }
    private void ChoasLevelJudge()//イベント実行後にカオスレベルが変化しているか判定
    {
        int c = GetChoasLevel();

        if (c > beforeCLevel)//全体カオスレベルが高くなった時はモニターレベルを加算
        {
            moniterLevel++;
            if (moniterLevel > 9) moniterLevel = 9;
        }
    }

    IEnumerator PinPon()//ピンポン
    {
        yield return new WaitForSeconds(1.8f);
        audioObjSE.GetComponent<SoundSE_M>().PinPonSE();
    }

}
