using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;




public class skipBtnM : MonoBehaviour
{
    [SerializeField] GameObject PrologeMObj;

    // Start is called before the first frame update
    void Start()
    {
        BtnFadeIn();
    }

    private void BtnFadeIn()//ボタンをフェードイン
    {
        Image image = this.GetComponent<Image>();
        image.DOFade(1f, 1.5f)
                  .SetDelay(1.8f)
                  .SetEase(Ease.OutSine);
    }

    public void SceanMove()
    {
        PrologeMObj.GetComponent<PrologueM>().DoorClickSet();
    }

}
