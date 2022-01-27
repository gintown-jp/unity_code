using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;



public class IB_ImgM : MonoBehaviour
{

    public void ItemNameOpen()//アイテム名の背景表示：ItemBoxMから呼び出し。:DotweenAnime
    {

        this.GetComponent<RectTransform>().DOScale(new Vector3(1, 1, 1), 0.1f);
        //this.gameObject.GetComponent<Image>().enabled = true;//enabledコンポーネントの表示・非表示
    }
    public void ItemNameClose()//アイテム名の背景非表示:DotweenAnime
    {
        this.GetComponent<RectTransform>().DOScale(new Vector3(0, 0, 0), 0.1f);
        //this.gameObject.GetComponent<Image>().enabled = false;
    }


}
