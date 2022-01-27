using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class AdBunner : MonoBehaviour
{
    //googleAd

    //自作
    BannerView bannerView;

    // Use this for initialization
    void Start()
    {
        // アプリID
        string appId = "ca-app-pub-3940256099942544~3347511713";

        // Initialize the Google Mobile Ads SDK.
        MobileAds.Initialize(appId);

        RequestBanner();

    }
    public void RequestBanner()//バナー生成：OnClick()より呼び出し
    {

        // 広告ユニットID これはテスト用
        string adUnitId = "ca-app-pub-3940256099942544/6300978111";//これはテスト用の広告ユニットID

        // Create a 320x50 banner at the top of the screen.
        bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Bottom);

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();

        // Load the banner with the request.
        bannerView.LoadAd(request);

    }


    public void NotViewBunner()//バナー削除：OnClick()より呼び出し
    {
        bannerView.Destroy();
    }

}

//https://developers.google.com/admob/unity/banner?hl=ja
//https://freesworder.net/unity-admob-banner/