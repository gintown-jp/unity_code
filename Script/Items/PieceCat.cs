using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PieceCat : ItemP
{
    /*--猫についているピース--*/
    Animator animator;//自身のアニメーターコンポーネントを格納

    public bool collected = false;//回収されていないfalse。一度でも回収true。

    void Start()
    {
        ItemParentStart();//デフォルトの画像を変数に取得：親クラスから呼び出す
        ItemInfoSet(4, "ピース");//アイテムの基本情報をセット：親クラスから呼び出す
        //Debug.Log("アイテムの基本情報をセットしました。" + itemID + itemName);
        animator = this.GetComponent<Animator>();
    }

    public void PieceCatOn()//クリックできるようにする：CatMから呼び出し
    {
        GetComponent<Image>().raycastTarget = true;
    }

    protected override void AnimeView()//光アニメーションを表示:オーバーライド
    {
        animator.SetBool("toumeiChange", false);
    }
    public void PieceToumei()//透明アニメーションを表示
    {
        animator.SetBool("toumeiChange", true);
    }
    public void PieceFlash()//光のアニメーションを表示
    {
        animator.SetBool("toumeiChange", false);
    }

    public void collectedOn()//クリックされたら実行：インスペクターから呼び出し
    {
        if (this.transform.parent.gameObject.GetComponent<CatM>().taiyakiEat == true)//既に猫がたい焼きを食べているか判定
        {
            collected = true;
            this.transform.localPosition = new Vector2(-150f,-40f);
        }
    }
}
