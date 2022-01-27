using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReButtonM : MonoBehaviour
{
    private GameObject ItemBoxObj;//親要素のアイテムボックスオブジェクトを格納

    // Start is called before the first frame update
    void Start()
    {
        ItemBoxObj = this.transform.parent.gameObject;
    }

    public void ItemReturn()//アイテムを元の位置に返却する：イベントトリガーから呼び出し
    {
        ItemBoxObj.GetComponent<ItemBoxM>().ItemReturn();//アイテムボックスオブジェクトと、その親オブジェクトの情報を「空」の設定にする
    }

    public void ReButtonClose()//アイテム返却ボタンを非表示にする:ItemBoxMとSwipeM3から呼び出し
    {
        this.gameObject.GetComponent<Image>().enabled = false;
    }
    public void ReButtonOpen()//アイテム返却ボタンを表示する:ItemBoxMとSwipeM3から呼び出し
    {
        this.gameObject.GetComponent<Image>().enabled = true;
    }
}
