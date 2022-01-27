using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UraBgM : MonoBehaviour
{
    Animator animator;//自身のアニメーターコンポーネントを格納



    void Start()
    {
        animator = this.GetComponent<Animator>();
    }

    public void tipsView()//ヒント画像を表示：KagamiUraMから呼び出し。PieceBedからも呼び出し
    {
        animator.SetBool("tipsOn", true);
    }
    public void tipsNoView()
    {
        animator.SetBool("tipsOn", false);
    }

}
