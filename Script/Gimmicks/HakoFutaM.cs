using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


public class HakoFutaM : MonoBehaviour
{//ゲームオーバー箱猫
    [SerializeField] GameObject GameManagerObj;
    [SerializeField] GameObject fadeSceneObj;//フェードアウトしてのシーン移動用オブジェクト
    [SerializeField] GameObject audioObj;//オーディオオブジェクト


    public void FutaClose()//蓋を閉める：PanelParentMから呼び出し（☆ゲームオーバー）
    {

        this.GetComponent<Image>().transform.DOLocalMoveY(-144f, 8f)
            .SetDelay(1.2f);

        Invoke("BGMout", 6.4f);
        //ゲームオーバーシーンへ移動
        Invoke("GameOverTo", 7.9f);
    }
    private void BGMout()//BGMをフェードアウトするFadeOutSecondsの時間を考慮
    {
        audioObj.GetComponent<VolumeM>().IsFadeOut = true;
    }

    private void GameOverTo()//ゲームオーバーシーンへ移動
    {
        //SceneManager.LoadScene("gameOver");
        GameManagerObj.GetComponent<GManager>().EndVarSet(2);//箱猫エンドを代入
        fadeSceneObj.GetComponent<SceneFadeM>().fadeOutStart(255, 255, 255, 0, "gameOver");
    }


}
