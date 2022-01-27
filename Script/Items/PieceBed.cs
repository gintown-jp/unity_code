using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PieceBed : ItemP
{
    /*--ベッド下のピース--*/
    Animator animator;//自身のアニメーターコンポーネントを格納


    private Sprite DefaultImg;//デフォルトの画像
    [SerializeField] GameObject UraBgObj;

    void Start()
    {
        ItemParentStart();//デフォルトの画像を変数に取得：親クラスから呼び出す
        ItemInfoSet(3, "ピース");//アイテムの基本情報をセット：親クラスから呼び出す
        //Debug.Log("アイテムの基本情報をセットしました。" + itemID + itemName);
        DefaultImg = this.GetComponent<Image>().sprite;
        animator = this.GetComponent<Animator>();

    }

    public void PieceBedView()
    {
        gameObject.SetActive(true);
    }

    protected override void AnimeView()//光アニメーションを表示:オーバーライド
    {
        animator.SetBool("toumeiChange", false);
        UraBgObj.GetComponent<UraBgM>().tipsView();//鏡のヒントを表示
    }
    public void PieceToumei()//透明アニメーションを表示
    {
        animator.SetBool("toumeiChange", true);
        UraBgObj.GetComponent<UraBgM>().tipsNoView();//鏡のヒントを消す
    }
    public bool PieceAnimeParGet()//アニメーションコントローラーのパラメーターを返す：KagamiUraMから呼び出し
    {
        bool b = animator.GetBool("toumeiChange");
        return b;
    }
}
