using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;




public class UnityAds : MonoBehaviour
{
    private string gameId = "4399633"; //"GameID"を入力
    private string bannerId = "Banner_Android";
    private bool testMode = false;//テストはtrue。本番はfalse

    private string rewardedId = "Rewarded_Android";

    [SerializeField] GameObject TipsMObj;


    [SerializeField] GameObject testObj;//☆

    // Start is called before the first frame update
    void Start()
    {
        Advertisement.Initialize(gameId, testMode);
        Advertisement.Load(bannerId);
    }


    /*バナー広告*/
    public void ShowBannerAd()
    {
        if (Advertisement.IsReady())
        {
            showBanner();
        }
    }
    public void HideBannerAd()
    {
        Advertisement.Banner.Hide();
    }
    private void showBanner()
    {
        Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_RIGHT); //バナーを下部中央にセット
        Advertisement.Banner.Show(bannerId);
    }

    /*リワード広告*/
    public void ShowIf()//はい・いいえの選択中に動画をロード:TipsMから呼び出し
    {
        Advertisement.Load(rewardedId);
    }

    public void ShowReward()
    {
        // Unity Adsを表示する準備ができているか確認する(広告全体の準備が出来ているかチェック)
        if (Advertisement.IsReady())
        {

            //表示したい広告の準備が出来ているかチェック
            var state = Advertisement.GetPlacementState(rewardedId);
            if (state != PlacementState.Ready)
            {
                //testObj.GetComponent<Image>().color = new Color(0, 0, 1);//☆

                Debug.LogWarning($"{rewardedId}の準備が出来ていません。現在の状態 : {state}");
                return;
            }

            //Debug.Log("ShowAds");
            //Advertisement.Show(rewardedId);

            Advertisement.Show(rewardedId, new ShowOptions()//この文法どういう方法か☆
            {
                //pause = true,
                resultCallback = result =>
                {
                    switch (result)
                    {
                        case ShowResult.Finished://広告を正しく再生
                            Debug.Log("The ad was successfully shown.");
                            TipsMObj.GetComponent<TipsM>().AdsArryCheck();//配列をチェックしてパネルを戻す


                            //testObj.GetComponent<Image>().color = new Color(1, 1, 1);//☆

                            //Application.Quit();        //終了処理
                            break;
                        case ShowResult.Skipped://広告を途中で終了
                            Debug.Log("The ad was skipped before reaching the end.");

                            //Application.Quit();        //終了処理
                            break;
                        case ShowResult.Failed://広告表示失敗
                            Debug.LogError("The ad failed to be shown.");
                            //testObj.GetComponent<Image>().color = new Color(1, 0, 0);//☆

                            //Application.Quit();        //終了処理
                            break;
                        default:
                            break;
                    }
                }
            });
        }
        else
        {
            //testObj.GetComponent<Image>().color = new Color(0, 0, 0);//☆
            Debug.LogWarning("動画広告の準備が出来ていません");
            TipsMObj.GetComponent<TipsM>().WaitePanelIn();
            return;
        }

    }

}
//https://youdoyou-motto.com/unity_banner_ad2
//https://docs.unity3d.com/Packages/com.unity.ads@3.1/api/UnityEngine.Advertisements.Advertisement.html?q=Advertisement
//https://kan-kikuchi.hatenablog.com/entry/Unity_Monetization_SDK