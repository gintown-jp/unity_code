using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class tvImgM : MonoBehaviour
{
    Animator animator;//自身のアニメーターコンポーネントを格納


    void Start()
    {
        animator = this.GetComponent<Animator>();
    }

    public void tvImgAnimeChange(int x)//アニメショーンの切り替え：CManagerから呼び出し
    {
        //Debug.Log("aa");
        animeChange(x);
    }

    private void animeChange(int x)
    {
        switch (x)
        {
            case 0:
                animator.SetInteger("tvImgAnime", 0);//消える
                break;
            case 1:
                animator.SetInteger("tvImgAnime", 1);//天気1
                break;
            case 2:
                animator.SetInteger("tvImgAnime", 2);//天気2
                break;
            case 3:
                animator.SetInteger("tvImgAnime", 3);//目
                break;
            default:
                break;

        }
    }

}
