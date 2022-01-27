using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;



public class TipsM : MonoBehaviour
{
    public int SetBtnNo = 10;//クリックしたボタンのNo。10をデフォルトとする

    [SerializeField] GameObject unityAdsObj;
    [SerializeField] GameObject AdPanelObj;//広告YES/NO選択パネル
    [SerializeField] GameObject TipsPanelObj;//ヒント表示パネル
    [SerializeField] Text dialogText;//ヒントの文字を表示させるTextコンポーネント
    [SerializeField] GameObject AllPanelObj;
    [SerializeField] GameObject WaitePanelObj;
    public bool[] tipsArry = {false,false,false,false,false};//広告を正確に見たかどうか（ヒント解放されたか）判定の配列。要素番号0はTipasHako0,AdBtnNo0を連動させる
    private string TipsData;//広告の既読かどうかを格納する一時変数


    private Vector3 AdPanelPos;
    private Vector3 TipsPanelPos;
    private string textInfo;
    private Vector3 WaitePanelPos;


    [SerializeField] GameObject AdSaveM;//広告セーブオブジェクト


    [SerializeField] GameObject Tips0Obj;
    [SerializeField] GameObject Tips1Obj;
    [SerializeField] GameObject Tips2Obj;
    [SerializeField] GameObject Tips3Obj;
    [SerializeField] GameObject Tips4Obj;
    [SerializeField] GameObject Tips5Obj;


    // Start is called before the first frame update
    void Start()
    {
        AdPanelPos = AdPanelObj.transform.localPosition;//AdPanelのローカル位置を取得
        TipsPanelPos = TipsPanelObj.transform.localPosition;//TipsPanelのローカル位置を取得
        WaitePanelPos = WaitePanelObj.transform.localPosition;//WaitePanelのローカル位置を取得
    }

    // Update is called once per frame

    public void PanelIn()//AdPanel表示
    {
        unityAdsObj.GetComponent<UnityAds>().ShowIf();
        AdPanelObj.GetComponent<Transform>().DOScale(1f,0.1f).
            SetEase(Ease.InOutBack);
        AdPanelObj.transform.localPosition = new Vector3(0, 0, 0);
    }
    public void TipsPanelIn()//TipsPanel表示
    {
        TipsPanelObj.GetComponent<Transform>().DOScale(1f, 0.1f).
            SetEase(Ease.InOutBack);
        TipsPanelObj.transform.localPosition = new Vector3(0, 0, 0);
    }
    public void AllPanelIn()//AllPanel表示
    {
        AllPanelObj.GetComponent<Transform>().DOScale(1f, 0.1f).
            SetEase(Ease.InOutBack);
        AllPanelObj.transform.localPosition = new Vector3(0, 0, 0);
    }
    public void PanelOut()//AdPanel非表示
    {
        AdPanelObj.GetComponent<Transform>().DOScale(0.9f, 0.1f).
            SetEase(Ease.InOutQuart);
        AdPanelObj.transform.localPosition = AdPanelPos;
        SetBtnNo = 10;
    }
    public void TipsPanelOut()//TipsPanel非表示
    {
        TipsPanelObj.GetComponent<Transform>().DOScale(0.9f, 0.1f).
            SetEase(Ease.InOutQuart);
        TipsPanelObj.transform.localPosition = TipsPanelPos;
        SetBtnNo = 10;
    }
    public void AllPaneOut()//TipsPanel非表示
    {
        AllPanelObj.GetComponent<Transform>().DOScale(0.9f, 0.1f).
            SetEase(Ease.InOutQuart);
        AllPanelObj.transform.localPosition = TipsPanelPos;
        SetBtnNo = 10;
    }

    public void WaitePanelIn()//WaitePanel表示
    {
        WaitePanelObj.transform.localPosition = new Vector3(0, 0, 0);
    }
    public void WaitePanelOut()//WaitePanel非表示
    {
        PanelOut();//広告選択のパネルを閉じる
        WaitePanelObj.transform.localPosition = WaitePanelPos;
    }

    public void PrintSenderName(Button sender)//クリックするボタンオブジェクトを取得する：イベントトリガーから呼び出し
    {
        if (sender != null)
        {
            SetBtnNo = sender.GetComponent<AdBtn>().AdBtnNo;
            //Debug.Log(sender.name);
            if (SetBtnNo == 5)
            {
                //ALLボタン
                if (AllAdCheck())
                {
                    //5つの広告視聴済み
                    TipsTextSet();
                    TipsPanelIn();
                    Tips5Obj.GetComponent<AdBtn>().ColorChange();

                }
                else
                {
                    //5つの広告視聴未
                    AllPanelIn();
                }
                return;
            }
            if (tipsArry[SetBtnNo] == true)
            {
                //広告視聴済み
                TipsTextSet();
                TipsPanelIn();
            }
            else
            {
                //広告視聴未
                PanelIn();
            }

        }
    }

    public void AdsArryCheck()//正しく広告を見たら配列内の該当要素にチェック：UnityAdsより呼び出し
    {
        if(SetBtnNo != 10 && SetBtnNo < 6)
        {
            tipsArry[SetBtnNo] = true;
        }
        TipsBtnColor();
        PanelOut();
        TipsDataSave();//広告データをセーブ
    }

    public void TipsDataLoad()//広告の既読データをロード
    {
        TipsData = AdSaveM.GetComponent<test>().FileLodeTo();
    }

    public void TipsDataSave()//広告の既読データをセーブ
    {
        int data = 10;
        for (int i = 0; i < tipsArry.Length; i++)
        {
            if (tipsArry[i] == true)
            {
                data = data + 1;  
            }
            else
            {
            }
            if (i < tipsArry.Length - 1)
            {
                data = data * 10;
            }
        }

        TipsData = data.ToString();//string型へ変換
        AdSaveM.GetComponent<test>().FileWrite(TipsData);//セーブデータを上書き
    }

    public void TipsDataCheck()//セーブデータと配列を照合し更新
    {
        TipsDataLoad();
        //Debug.Log(TipsData);
        int ilen = TipsData.Length;//セーブデータの文字列の長さを取得
        //Debug.Log(ilen);
        int data = int.Parse(TipsData);

        if (data == 111111)//data==111111の時の操作
        {
            for (int i = 0; i < tipsArry.Length; i++)//セーブデータの文字列を反映
            {
                tipsArry[i] = true;
            }
            Tips5Obj.GetComponent<AdBtn>().ColorChange();
            //ボタン解放
            TipsBtnColor();
            return;
        }

        int[] dataArry = new int[ilen];
        for (int i = 0;i < dataArry.Length;i++)//セーブデータの文字列を配列として格納
        {
            if (1 == data % 10)
            {
                dataArry[ilen - 1 - i] = 1;
            }
            else
            {
                dataArry[ilen - 1 - i] = 0;
            }
            data = data / 10;
        }
        //for (int i = 0; i < dataArry.Length; i++)
        //{
        //    Debug.Log(dataArry[i]);
        //}

        for (int i = 0;i < tipsArry.Length;i++)//セーブデータの文字列を反映
        {
            if (dataArry[i + 1] == 1)
            {
                tipsArry[i] = true;
            }
        }
        TipsBtnColor();
    }

    private void TipsBtnColor()//広告ボタンの色変更
    {
        for(int i = 0; i < tipsArry.Length; i++)
        {
            if (tipsArry[i] == true)
            {
                switch (i)
                {
                    case 0:
                        Tips0Obj.GetComponent<AdBtn>().ColorChange();
                        break;
                    case 1:
                        Tips1Obj.GetComponent<AdBtn>().ColorChange();
                        break;
                    case 2:
                        Tips2Obj.GetComponent<AdBtn>().ColorChange();
                        break;
                    case 3:
                        Tips3Obj.GetComponent<AdBtn>().ColorChange();
                        break;
                    case 4:
                        Tips4Obj.GetComponent<AdBtn>().ColorChange();
                        break;
                    default:
                        break;
                }
            }
        }
    }

    private void TipsTextSet()
    {
        switch (SetBtnNo)
        {
            case 0:
                Text00();
                break;
            case 1:
                Text01();
                break;
            case 2:
                Text02();
                break;
            case 3:
                Text03();
                break;
            case 4:
                Text04();
                break;
            case 5:
                Text05();
                break;
            default:
                break;
        }
    }
    private void Text00()
    {
        textInfo = "前に来た時はこんな箱なかった。\n" +
            "一応中身も調べておこう。\n" +
            "なんだか部屋の様子が変わった気がするけど、気のせいかな？\n" +
            "もしかして箱の中身で・・・。\n";
        dialogText.text = textInfo;

    }
    private void Text01()
    {
        textInfo = "右の引き出しにはお姉ちゃんの写真が入っていた。\n" +
            "他にも何かあるかな？\n" +
            "この数字が少し気になるけど・・・。\n" +
            "「１」ってなんだろう？ 順番？\n";
        dialogText.text = textInfo;

    }
    private void Text02()
    {
        textInfo = "壁に大きな鏡が掛けてある。\n" +
            "昔読んだ物語で鏡の世界に行く話があったっけ。\n" +
            "もし鏡の中の世界が本当にあったらどんなだろう。\n" +
            "やっぱり左右反対に見えるのかな。\n";
        dialogText.text = textInfo;

    }
    private void Text03()
    {
        textInfo = "あの抜けてるお姉ちゃんが、ちゃんとパスワードをかけてるなんて・・・。\n" +
            "でもきっと忘れないように何か残してるはず。\n" +
            "目に付きやすい場所、写真の辺りとかどうかな・・・。\n";
        dialogText.text = textInfo;

    }
    private void Text04()
    {
        textInfo = "ここはペット禁止のはずなのに！\n" +
            "それと首からぶら下げてるのは何だろう？\n" +
            "この子の気を引けるものがあれば取れそうだけど・・・。\n" +
            "それにしてもこの部屋、やけにネコのグッズが多いような。\n";
        dialogText.text = textInfo;

    }
    private void Text05()
    {
        textInfo = "やっぱりこの箱が怪しいと思う。\n" +
            "箱には４つのくぼみがあるけど、元は何かはまっていたはず。\n" +
            "やっぱり、この部屋だんだん様子がおかしくなってる。\n"+
            "お姉ちゃん無事でいてくれてるといいけど・・・\n";
        dialogText.text = textInfo;

    }
    private bool AllAdCheck()//5つの広告を全て見たか判定
    {
        for (int i = 0;i < tipsArry.Length; i++)
        {
            if (tipsArry[i] == false)
            {
                return false;
            }
        }
        return true;
    }

}
