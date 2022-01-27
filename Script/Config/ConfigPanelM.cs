using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class ConfigPanelM : MonoBehaviour
{
    private Vector3 defaultPos; // 初期状態のオブジェクト位置
    private CanvasGroup canvasGroup;//自身のキャンバスグループ

    // Start is called before the first frame update
    void Start()
    {
        defaultPos = this.transform.localPosition; // 初期のローカル空間での位置を取得
        canvasGroup = this.GetComponent<CanvasGroup>();
        canvasGroup.alpha = 0;
    }

    public void ConfigView()//設定画面を表示する：ConfigPanelオブジェクトのOnClickイベントから呼び出し
    {
        canvasGroup.DOFade(1, 0.2f)//フェードイン
                   .SetEase(Ease.InOutQuart);
        this.transform.DOLocalMove(new Vector3(defaultPos.x - 1400, 0, 0), 0.2f)
                      .SetEase(Ease.InOutQuart);
        //this.transform.localPosition = new Vector3(defaultPos.x - 1400,0,0);

    }
    public void ConfigNotView()//設定画面を閉じる：ConfigCloseBtnオブジェクトのOnClickイベントから呼び出し
    {
        canvasGroup.DOFade(0, 0.2f)//フェードアウト
                   .SetEase(Ease.InOutQuart);
        this.transform.DOLocalMove(defaultPos, 0.2f)
                      .SetEase(Ease.InOutQuart);

    }

}
