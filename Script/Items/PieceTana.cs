using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PieceTana : ItemP
{
    /*--TVラックの中のピース--*/
    Animator animator;//自身のアニメーターコンポーネントを格納


    void Start()
    {
        ItemParentStart();//デフォルトの画像を変数に取得：親クラスから呼び出す
        ItemInfoSet(5, "ピース");//アイテムの基本情報をセット：親クラスから呼び出す
        //Debug.Log("アイテムの基本情報をセットしました。" + itemID + itemName);
        animator = this.GetComponent<Animator>();


        //this.GetComponent<Image>().sprite = toumeiImg;
        //touchFlag = false;
    }

    public void PiceTanaView()//PiceTanaオブジェクトを表示：HikiMから呼び出し
    {
        //this.GetComponent<Image>().sprite = itemImgDef;
        //touchFlag = true;
        this.gameObject.SetActive(true);

    }

    protected override void AnimeView()//光アニメーションを表示:オーバーライド
    {
        animator.SetBool("toumeiChange", false);
    }
    public void PieceToumei()//透明アニメーションを表示
    {
        animator.SetBool("toumeiChange", true);
    }


}
