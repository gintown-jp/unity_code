using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class Panel4M : MonoBehaviour
{
    Tweener tweener;    //ここにDoTweenの情報を入れる
    public void PanelRotate()
    {
        this.transform.rotation = Quaternion.Euler(0, 0, 1f);
        tweener = transform.DORotate(new Vector3(0, 0, -1f), 2f)
            .SetLoops(-1, LoopType.Yoyo);
    
    }
    public void PanelRStop()
    {
        tweener.Kill();
        this.transform.rotation = Quaternion.Euler(0, 0, 0);

        //Debug.Log("PanelRStop");
    }

}
//tween無限ループの止め方：https://www.hanachiru-blog.com/entry/2018/12/01/163012