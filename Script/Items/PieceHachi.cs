using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceHachi : ItemP
{
    /*--鉢の中にあるピース--*/
    Animator animator;//自身のアニメーターコンポーネントを格納


    void Start()
    {
        ItemParentStart();//デフォルトの画像を変数に取得：親クラスから呼び出す
        ItemInfoSet(6, "ピース");//アイテムの基本情報をセット：親クラスから呼び出す
        //Debug.Log("アイテムの基本情報をセットしました。" + itemID + itemName);
        animator = this.GetComponent<Animator>();

    }

    public void PieceHachiSet()
    {
        this.gameObject.SetActive(true);
    }

    protected override void AnimeView()//光アニメーションを表示:オーバーライド
    {
        animator.SetBool("toumeiChange", false);
    }
    public void PieceToumei()//透明アニメーションを表示
    {
        //Debug.Log("aaa");
        animator.SetBool("toumeiChange", true);
    }

}
