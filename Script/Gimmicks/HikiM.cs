using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HikiM : MonoBehaviour
{
    // 変数宣言
    [SerializeField] Camera mainCamera;//カメラを設定
    private bool touchJudg = false;// タッチしているか判定
    private Vector3 defaultPos;//オブジェクトの初期位置
    private Vector3 startPos;//スワイプ前のオブジェクト位置
    private Vector3 clickPos;//マウスをクリックした開始位置
    public static int hikiOrder = 0;//引き出しを引いた順番
    public static bool[] hikiOk = new bool[3];//引き出しを引いた順番が正しいか判定:未定義部分はnull
    private bool hikiOn = false;//引き出しを一度でも開けたかどうか判定
    private bool hikiJugeT = false;//HikiJuge()を一度でもTrueで返したか判定（PisceTanaアイテムが発生したか）


    [SerializeField] GameObject GameMObj;



    // Start is called before the first frame update
    void Start()
    {
        defaultPos = this.GetComponent<Transform>().position; // 初期のオブジェクト位置を取得
        HikiOkInitial();
    }

    // スワイプした後をついてくるような動き※
    void Update()
    {
        if (touchJudg == true)
        {
            // メソッドを呼び出す
            HikiMove2();
        }
    }

    public void HikiTouch()//アタッチしているオブジェクトのイベントトリガーから呼び出し
    {
        startPos = this.GetComponent<Transform>().position; // 初期のオブジェクト位置を取得
        Vector3 mousePos = Input.mousePosition;
        clickPos = mainCamera.ScreenToWorldPoint(mousePos + mainCamera.transform.forward * 100);//最初のクリックした位置

        touchJudg = true;
    }


    private void HikiMove2()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 mousePos = Input.mousePosition;
            //↓クリック位置を反映：マウスのスクリーン座標を指定のカメラから見たワールド座標（3D空間の座標）に変換 + そのまま座標を指定すると「カメラの原点」を取ってしまうので、奥に調整した位置を取得
            var pos = mainCamera.ScreenToWorldPoint(mousePos + mainCamera.transform.forward * 100);
            pos.y = pos.y + (startPos.y - clickPos.y);//奇跡!(これがないとクリックした時にオブジェクトの中心を基準にスワイプしてしまう)
            pos.x = startPos.x;
            if (pos.y < 17)//引き出しがスライドが止まる範囲
            {
                pos.y = 17;
            }
            if (pos.y > 53)
            {
                pos.y = 52.5f;
            }
            if (hikiOn == false)
            {
                if (pos.y > 40)
                {
                    CountHiki();
                    hikiOn = true;
                }
            }
            //Debug.Log(pos.y);
            this.transform.position = pos;
        }
        if (Input.GetMouseButtonUp(0))
        {
            touchJudg = false;
        }

    }

    private void CountHiki()
    {
        hikiOrder++;
        if (hikiOrder == 1 && this.gameObject.name == "Hiki1")
        {
            hikiOk[0] = true;
        }
        if (hikiOrder == 2 && this.gameObject.name == "Hiki3")
        {
            hikiOk[1] = true;

        }
        if (hikiOrder == 3 && this.gameObject.name == "Hiki2")
        {
            hikiOk[2] = true;
            if (HikiJuge())
            {
                this.transform.Find("pieceTana").GetComponent<PieceTana>().PiceTanaView();//PieceTanaオブジェクトを表示〇もどり過ぎる
            }
        }
    }
    public void HikiOkInitial()//配列初期化：TanaButtonオブジェクトのイベントトリガーから呼び出し
    {
        ReHikiObj();

        for (int i = 0; i < hikiOk.Length; i++)
        {
            hikiOk[i] = false;
        }
        hikiOrder = 0;
    }
    public void ReHikiObj()//オブジェクトを元の位置に戻す：TanaButtonオブジェクトのイベントトリガーから呼び出し
    {
        this.GetComponent<Transform>().position = defaultPos;
        hikiOn = false;
    }
    
    private bool HikiJuge()//引き出しイベントを条件満たしピース発生フラグを立てる
    {
        if (hikiJugeT == true) { return false; }//既にPieceTanaオブジェクトが発生している場合は関数終了
        for(int i = 0; i < hikiOk.Length; i++)//配列内が全てTrueなら関数続行
        {
            if(hikiOk[i] == false)
            {
                return false;
            }
        }
        GameMObj.GetComponent<GManager>().PlusChaos();//全体のカオス度に+1
        GameMObj.GetComponent<GManager>().PlusStory();//全体の進行度に+1
        hikiJugeT = true;
        return true;
    }
}