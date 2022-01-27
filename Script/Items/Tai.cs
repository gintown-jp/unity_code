using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Tai : ItemP
{
    /*--鯛--*/

    void Start()
    {
        ItemParentStart();//デフォルトの画像を変数に取得：親クラスから呼び出す
        ItemInfoSet(8, "鯛");//アイテムの基本情報をセット：親クラスから呼び出す
        //Debug.Log("アイテムの基本情報をセットしました。" + itemID + itemName);
        gameObject.SetActive(false);
    }

    private bool fishOn = false;//魚オブジェクトを動かすか判定
    private int moveNum = 1;//左右に移動する魚の方向を判定
    private RectTransform rectTransform;//Dotween用
    public float moveX;//移動距離
    public float sTime;//秒
    [SerializeField] Sprite taiyakiImg;
    [SerializeField] Sprite taiyakiThum;

    void Update()
    {
        if (fishOn == true)
        {
            if (moveNum == 2 || moveNum == 4)//魚の方向転換判定
            {
                return;
            }
            else if (moveNum == 1)//1方向に移動
            {
                FishMove(moveX, sTime);
            }
            else if (moveNum == 3)//3方向に移動
            {
                FishMove(moveX * -1, sTime);
            }
        }
    }
    public void FishGenerate()//魚オブジェクトを生成:GManagerから呼び出し
    {
        this.gameObject.SetActive(true);
        rectTransform = this.gameObject.GetComponent<RectTransform>();
        fishOn = true;
    }
    private void FishMove(float x, float time)//魚を移動
    {
        rectTransform.DOAnchorPos(new Vector2(x, 0), time)
             .SetRelative(true)
             .OnComplete(FishMoveEnd);
        if (moveNum == 1)
        {
            moveNum = 2;
        }
        else if (moveNum == 3)
        {
            moveNum = 4;
        }
    }
    private void FishMoveEnd()//魚の方向転換(1：移動判定、2：1の方向に移動中。3：移動判定、4：3の方向に移動中。):FishMove関数から呼び出し
    {
        if (moveNum == 4)
        {
            moveNum = 1;
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (moveNum == 2)
        {
            moveNum = 3;
            transform.localScale = new Vector3(-1, 1, 1);//画像の向きを反転
        }
    }

    public void TaiyakiImgSet()//表示する際の画像をたい焼き画像に設定しておく：Art2Mから呼び出し
    {
        itemImgDef = taiyakiImg;
        thumImg = taiyakiThum;//サムネをたい焼きに変更
        ItemInfoSet(9, "たい焼き");
    }



}
