using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


public class KagamiUraM : MonoBehaviour
{
    private Sprite DefaultImg;//デフォルトの画像(透明画像)
    public int kagamiChaos = 0;//鏡カオス度(publicにしておく)
    private bool mirrorOne = false;//鏡を一度でもクリックしたか判定

    [SerializeField] GameObject UraBgObj;
    Animator animator;//自身のアニメーターコンポーネントを格納

    [SerializeField] GameObject PieceBedObj;
    [SerializeField] GameObject GManagerObj;
    [SerializeField] GameObject KagamiObakeObj;
    [SerializeField] GameObject KagamiBtnObj;

    void Start()
    {
        DefaultImg = this.GetComponent<Image>().sprite;
        animator = this.GetComponent<Animator>();
        AnimeSwich();
    }

    public void girlView()//女の子を表示（子オブジェクトのヒントも表示）：HakoInMから呼び出し
    {
        this.GetComponent<Image>().enabled = true;
        UraBgObj.GetComponent<UraBgM>().tipsView();
        if (kagamiChaos >= 6)//鏡カオス度が6以上のときは女の子非表示
        {
            this.GetComponent<Image>().enabled = false;
            UraBgObj.GetComponent<UraBgM>().tipsNoView();//ヒント非表示
        }
        KagamiObakeObj.GetComponent<KagamiObakeM>().obakeView(true);//お化け画像を表示
        if (PieceBedObj.activeSelf == true)//PieceBedオブジェクトがアクティブ状態の時のみ実行
        {
            if (PieceBedObj.GetComponent<PieceBed>().PieceAnimeParGet() == true)//ピースベッドのアニメーションが透明（ピースベッド取得状態）
            {
                UraBgObj.GetComponent<UraBgM>().tipsNoView();
            }
        }

    }
    public void girlNoView()//女の子を非表示（子オブジェクトのヒントも非表示）
    {
        this.GetComponent<Image>().enabled = false;
        UraBgObj.GetComponent<UraBgM>().tipsNoView();
        KagamiObakeObj.GetComponent<KagamiObakeM>().obakeView(false);//お化け画像を非表示

    }


    public void kagamiChaosPlass()//鏡カオス度を加算：イベントトリガーから呼び出しKagamiButton
    {
        if (this.GetComponent<Image>().enabled == true)
        {
            kagamiChaos ++;
        }
    }
    public void AnimeChange()//アニメーションを変更:イベントトリガーから呼び出し（戻るボタン）
    {
        Invoke("AnimeSwich",0.2f);
    }
    private void AnimeSwich()//鏡カオス度によるアニメーションの操作
    {
        switch (kagamiChaos)
        {
            case 0:
                animator.SetInteger("girl_Anime", 1);//うつむいている
                break;
            case 1://ここから
                animator.SetInteger("girl_Anime", 2);//驚いて目をパチパチ
                break;
            case 2:
                animator.SetInteger("girl_Anime", 3);//通常の目をパチパチ
                break;
            case 3:
                animator.SetInteger("girl_Anime", 3);//通常の目をパチパチ
                KagamiObakeChange(1);//お化け少し
                break;
            case 4:
                GManagerObj.GetComponent<GManager>().PlusChaos();//全体カオス度加算。うつむいている
                animator.SetInteger("girl_Anime", 1);
                KagamiObakeChange(2);//お化け全身見える
                break;
            case 5:
                animator.SetInteger("girl_Anime", 1);
                KagamiObakeChange(3);//お化け口空ける
                break;
            case 6:
                animator.SetInteger("girl_Anime", 1);
                KagamiObakeChange(4);//血しぶき
                this.GetComponent<Image>().enabled = false;//女の子非表示
                UraBgObj.GetComponent<UraBgM>().tipsNoView();//ヒント非表示
                MirrorEndFlag();
                break;
            default:
                this.GetComponent<Image>().enabled = false;
                break;
        }
    }
    public void JumpAnime()//驚いたアニメーションへ変更
    {
        if (kagamiChaos <= 1) {
            if (mirrorOne) { return; }
            animator.SetInteger("girl_Anime", 4);//驚いてジャンプする
            DOTween.Sequence()
                .Append(this.GetComponent<RectTransform>().DOLocalMoveY(10f, 0.2f)
                    .SetEase(Ease.InOutQuart))
                .Append(this.GetComponent<RectTransform>().DOLocalMoveY(-10f, 0.2f)
                    .SetEase(Ease.OutQuart));
            mirrorOne = true;
            Invoke("JumpAnime2", 0.6f);
        };
    }
    private void JumpAnime2()
    {
        animator.SetInteger("girl_Anime", 5);//驚いて目をパチパチ
    }
    private void KagamiObakeChange(int x)//KagamiObakeオブジェクトの画像を変更
    {
        KagamiObakeObj.GetComponent<KagamiObakeM>().obakeChange(x);
    }
    private void MirrorEndFlag()//鏡エンドのフラグ
    {
        GManagerObj.GetComponent<GManager>().VerandaSE_NON();//猫とカラスのSEを消す


        //ギミック操作を止める☆鏡だけは見れるようにしたい・・・
        GManagerObj.GetComponent<GManager>().tuchNo(false);//raycasttargetを非アクティブ化
        GManagerObj.GetComponent<GManager>().EndVarSet(3);//鏡エンドを設定
        KagamiBtnObj.GetComponent<Image>().raycastTarget = true;//鏡ボタンだけタッチ可能

        //PanelParentMで矢印ボタンと向きを判定しベランダで女の子が血だらけになっている画像に

    }

}
