using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkImgM : MonoBehaviour
{
    // 変数宣言
    [SerializeField] Camera mainCamera;//カメラを設定
    private bool touchJudg = false;// タッチしているか判定
    private Vector3 defaultPos;//オブジェクトの初期位置
    private Vector3 startPos;//スワイプ前のオブジェクト位置
    private Vector3 clickPos;//マウスをクリックした開始位置


    void Start()
    {
        defaultPos = this.GetComponent<Transform>().position; // 初期のオブジェクト位置を取得

    }

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
            if (pos.y < -22)//引き出しがスライドが止まる範囲
            {
                pos.y = -22f;
            }
            if (pos.y > 35)
            {
                pos.y = 35f;
            }
            //Debug.Log(pos.y);
            this.transform.position = pos;
        }
        if (Input.GetMouseButtonUp(0))
        {
            touchJudg = false;
        }

    }

    public void ReHikiObj()//オブジェクトを元の位置に戻す：TanaButtonオブジェクトのイベントトリガーから呼び出し(今回は使わず)
    {
        this.GetComponent<Transform>().position = defaultPos;
    }

}
