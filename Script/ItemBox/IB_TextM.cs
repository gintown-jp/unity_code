using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class IB_TextM : MonoBehaviour
{
    private GameObject itemBoxObj;//親要素のItemBoxを格納
    private Text textFrame = null;

    // Start is called before the first frame update
    void Start()
    {
        //itemBoxObj = this.transform.parent.gameObject;
        textFrame = this.GetComponent<Text>();
    }

    public void ItemGetSetName(string name)//アイテム名を取得しセットする：ItemBoxMから呼び出し
    {
        this.textFrame.text = name;
    }
    public void ItemNameTOpen()//アイテム名の表示：ItemBoxMから呼び出し。テキスト出現:DotweenAnime
    {
        this.gameObject.GetComponent<Text>().enabled = true;
    }
    public void ItemNameTClose()//アイテム名の非表示:DotweenAnime
    {
        this.gameObject.GetComponent<Text>().enabled = false;
    }

}
