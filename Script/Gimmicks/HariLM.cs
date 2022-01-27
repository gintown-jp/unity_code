using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HariLM : GimmickP
{
    private Vector3 hariLEuler;//HariLの角度（針の初期位置）

    private bool touchJudg = false;// タッチしているか判定
    [SerializeField] Camera mainCamera;//カメラを設定
    [SerializeField] GameObject HariSObj;//短針のゲームオブジェクト

    [SerializeField] GameObject GameMObj;
    [SerializeField] GameObject PieceBedObj;

    [SerializeField] GameObject RbtnObj;//Rボタン
    [SerializeField] GameObject LbtnObj;//Lボタン
    private bool RbtnOn = false;//Rボタンが押されている
    private bool LbtnOn = false;//Lボタンが押されている

    private int angle = 2;
    private bool eventJuge = false;//針を回転させてピースを発生させるイベントについて実行するか判定

    void Start()
    {
        GimmickInfoSet(27, "長針");//ギミックの基本情報をセット：親クラスから呼び出す
        hariLEuler = this.transform.localEulerAngles;//オイラー角を取得
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (touchJudg == true)
        {
            // メソッドを呼び出す
            HariLMove();

        }
    }

    void Update()//FixedUpdate内だけだとGetMoueButtonUpが起こらないことがある
    {
        if (touchJudg == true)
        {
            if (Input.GetMouseButtonUp(0))
            {
                HariLJuge();
                touchJudg = false;
                return;
            }
        }
    }

    public void HariLTouch()//アタッチしているオブジェクトのイベントトリガーから呼び出し
    {
        touchJudg = true;
    }
    public void EventOn()//針を回転させてピースを取得するイベントを実行可能にする：GkPanelMから呼び出し
    {
        eventJuge = true;
    }

    //private void HariLMove()//画像の回転
    //{
    //    if (Input.GetMouseButtonUp(0))
    //    {
    //        HariLJuge();
    //        touchJudg = false;
    //        return;
    //    }
    //    if (Input.GetMouseButton(0))
    //    {
    //        Vector3 mousePos = Input.mousePosition;
    //        //↓クリック位置を反映：マウスのスクリーン座標を指定のカメラから見たワールド座標（3D空間の座標）に変換 + そのまま座標を指定すると「カメラの原点」を取ってしまうので、奥に調整した位置を取得
    //        var pos = mainCamera.ScreenToWorldPoint(mousePos + mainCamera.transform.forward * 100);

    //        if(pos.x > 0)//画面の中央
    //        {
    //            this.transform.rotation *= Quaternion.AngleAxis(angle, Vector3.back);
    //            HariSObj.GetComponent<HariSM>().HariSMoveR();
    //        }
    //        else
    //        {
    //            this.transform.rotation *= Quaternion.AngleAxis(angle, Vector3.forward);
    //            HariSObj.GetComponent<HariSM>().HariSMoveL();
    //        }
    //    }

    //}

    private void HariLMove()//画像の回転
    {
        if (Input.GetMouseButtonUp(0))
        {
            HariLJuge();
            touchJudg = false;
            return;
        }
        if (RbtnOn == true || LbtnOn == true)
        {
            if (RbtnOn == true)//画面の中央
            {
                this.transform.rotation *= Quaternion.AngleAxis(angle, Vector3.back);
                HariSObj.GetComponent<HariSM>().HariSMoveR();
            }
            else
            {
                this.transform.rotation *= Quaternion.AngleAxis(angle, Vector3.forward);
                HariSObj.GetComponent<HariSM>().HariSMoveL();
            }
        }

    }

    private void HariLJuge()//針の角度をチェック
    {
        if (eventJuge == false) { return; }//女の子を見ていないとピースのイベントは発生させない

        Debug.Log("Event");


        Quaternion quaternion = this.transform.rotation;//オブジェクトの回転量を表す値にQuaternion（四元数）
        var rotz = quaternion.eulerAngles.z;//オイラー角を取得：参考：https://qiita.com/keito_takaishi/items/60d6be6de69edc504f39
        Debug.Log("l" + rotz);

        if (rotz > 347 || 18 > rotz)
        {
            //短針の位置をチェック
            if (HariSObj.GetComponent<HariSM>().HariSJuge())
            {
                Debug.Log("時計ok");
                //ピースの発生とストーリー進行度・全体カオス度に1加算
                PieceBedObj.GetComponent<PieceBed>().PieceBedView();
                GameMObj.GetComponent<GManager>().PlusStory();
                GameMObj.GetComponent<GManager>().PlusChaos();

                eventJuge = false;
                return;
            }
            Debug.Log("時計no");

        }
    }

    public void HariLRe()//針を初期位置へ戻す
    {
        this.transform.rotation = Quaternion.Euler(hariLEuler);//オイラー角をクォータニオンへ変換し代入
    }

    public void RbtnDown()
    {
        RbtnOn = true;
        touchJudg = true;
    }
    public void RbtnUp()
    {
        RbtnOn = false;
    }
    public void LbtnDown()
    {
        LbtnOn = true;
        touchJudg = true;
    }
    public void LbtnUp()
    {
        LbtnOn = false;
    }

}

