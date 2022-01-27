using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CatM : GimmickP
{
    Animator animator;//自身のアニメーターコンポーネントを格納
    public bool taiyakiEat = false;//たい焼きを食べたか判定

    private Vector2 NormalPiecePos;//通常のpieceCatオブジェクトの位置

    [SerializeField] GameObject AudioObjSE;//オーディオオブジェクトSE

    // Start is called before the first frame update
    void Start()
    {
        GimmickInfoSet(21, "黒猫");//ギミックの基本情報をセット：親クラスから呼び出す
        //Debug.Log("ギミックの基本情報をセットしました。" + gimmickID + gimmickName);
        animator = this.GetComponent<Animator>();
        NormalPiecePos = this.transform.GetChild(0).gameObject.transform.localPosition;//pieceCatオブジェクトの位置を取得
    }


    public void CatView()//猫を表示：HakoInMから呼び出し
    {
        CatNomalAnime();//猫表示アニメ
        gameObject.GetComponent<Image>().raycastTarget = true;

        if (taiyakiEat == true)//たい焼き食べたか判定する）
        {
            if (this.transform.GetChild(0).gameObject.GetComponent<PieceCat>().touchFlag == false)//ピースキャット回収中の場合
            {
                this.transform.GetChild(0).gameObject.GetComponent<Image>().raycastTarget = true;
                return; 
            }
            //たい焼きは食べたがピースキャットは手元にない
            this.transform.GetChild(0).gameObject.GetComponent<PieceCat>().PieceFlash();//pieceCatのアニメを表示
            this.transform.GetChild(0).gameObject.GetComponent<Image>().raycastTarget = true;
            return;
        }else{
            this.transform.GetChild(0).gameObject.GetComponent<PieceCat>().PieceFlash();//pieceCatのアニメを表示。raycastはonにしない。
        }
    }

    public void CatNoView()//猫を非表示：HakoInMから呼び出し
    {
        animator.SetInteger("catAnimeCh", 0);//猫非表示アニメ
        gameObject.GetComponent<Image>().raycastTarget = false;

        if (this.transform.GetChild(0).gameObject.GetComponent<PieceCat>().collected == false)//一度でも回収したら猫が消えてもピースキャットを残す
        {
            this.transform.GetChild(0).gameObject.GetComponent<PieceCat>().PieceToumei();//pieceCatのアニメを非表示
        }

        this.transform.GetChild(0).gameObject.GetComponent<Image>().raycastTarget = false;

        if (this.transform.GetChild(0).gameObject.GetComponent<PieceCat>().collected == true)//一度でも回収した場合は猫が消えてもraycastはonのままにする
        {
            this.transform.GetChild(0).gameObject.GetComponent<Image>().raycastTarget = true;
        }
    }

    public void CatTuch()//猫をタッチ：自身のインスペクターから呼び出し
    {
        if (this.transform.GetChild(0).gameObject.GetComponent<PieceCat>().collected == true) { return;}//１度でも猫ピースを回収済みならタッチをうけつけない

        animator.SetInteger("catAnimeCh", 2);//怒った猫
        CatAngerSE();
        if (taiyakiEat == false)
        {
            this.transform.GetChild(0).gameObject.transform.localPosition = new Vector2(NormalPiecePos.x - 10, NormalPiecePos.y - 30);
        }
        Invoke("CatNomalAnime", 1.5f);
    }
    private void CatNomalAnime()//猫アニメを通常に戻す
    {
        if (taiyakiEat == true && this.transform.GetChild(0).gameObject.GetComponent<PieceCat>().collected == true)//たい焼きを食べていて、一度ピースを取得している
        {
            //普通の猫
            animator.SetInteger("catAnimeCh", 1);
        }
        else if (taiyakiEat == true && this.transform.GetChild(0).gameObject.GetComponent<PieceCat>().collected == false)//たい焼きを食べていて、ピースは取得していない
        {
            //たい焼きを食べる猫
            animator.SetInteger("catAnimeCh", 4);

        }
        if(taiyakiEat == false)//たい焼きを食べていない
        {
            this.transform.GetChild(0).gameObject.transform.localPosition = NormalPiecePos;
            animator.SetInteger("catAnimeCh", 1);//普通の猫
        }
    }

    public override void SwipeOnEvent(GameObject itemBoxObj, int itemID)//スワイプしてきたアイテムボックスの情報を受け取り実行（スワイプ後のイベント）：オーバーライド：SwipeM3から呼び出し
    {
        if(itemID == 9)
        {
            //Debug.Log("たいやき");
            //エサを食べてるアニメ
            transform.GetChild(0).gameObject.GetComponent<PieceCat>().PieceCatOn();//首にかかったピースをクリックできるようにする
            //エサを食べている猫
            animator.SetInteger("catAnimeCh", 4);
            this.transform.GetChild(0).gameObject.transform.localPosition = new Vector2(NormalPiecePos.x - 30, NormalPiecePos.y - 50);
            taiyakiEat = true;

        }
        else
        {
            //そっぽむくアニメ
            animator.SetInteger("catAnimeCh", 3);
            this.transform.GetChild(0).gameObject.transform.localPosition = new Vector2(NormalPiecePos.x + 10, NormalPiecePos.y + 10);
            //Debug.Log("たい");
            Invoke("CatNomalAnime", 1.5f);
        }
    }

    private void CatAngerSE()
    {
        AudioObjSE.GetComponent<SoundSE_M>().CatAngerSE();
    }

}
