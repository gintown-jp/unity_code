using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;



public class PassLockImgM : MonoBehaviour
{
    [SerializeField] Sprite errorImg;
    [SerializeField] Sprite clearImg;
    private Sprite lockImg;

    private void Start()
    {
        lockImg = this.GetComponent<Image>().sprite;
    }

    public void LockImgSet()//鍵の画像（初期画像）をセット
    {
        this.GetComponent<Image>().sprite = lockImg;
    }

   public void ErrorImgSet()//エラー画像をセット
    {
        this.GetComponent<Image>().sprite = errorImg;
        this.transform.DOScale(1.1f, 0.1f)
            .SetLoops(2, LoopType.Yoyo);
    }

    public void ClearImgSet()//ロック解除画像をセット
    {
        this.GetComponent<Image>().sprite = clearImg;
        DOTween.Sequence()
            .Append(transform.DOScale(1.1f, 0.1f))
            .Append(transform.DOScale(1f, 0.1f))
            .Append(this.GetComponent<Image>().DOFade(0f, 0.5f)
                                              .SetDelay(1f));
        //this.transform.DOScale(1.1f, 0.1f)
        //   .SetLoops(2, LoopType.Yoyo);
        Invoke("ObjNoView", 2f);
    }
    private void ObjNoView()//このオブジェクトを非アクティブにする
    {
        this.gameObject.SetActive(false);
    }
}
