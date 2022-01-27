using System;
using UnityEngine;
using GoogleMobileAds;
using GoogleMobileAds.Api;
using UnityEngine.UI;

public class AdReward : MonoBehaviour
{
    //googleAd

    private RewardedAd rewardedAd;
    //しまづさんの自作↓
    public Text messageText;
    int count = 0;
    bool isRewarded;

    // Start is called before the first frame update
    void Start()
    {
        string appId = "ca-app-pub-2171520732224576~1101782737";

        MobileAds.Initialize(appId);//広告を初期化

        RequestRewardAd();
    }
    private void Update()
    {
        if (isRewarded)//報酬を受け取った時にこの中の処理を実行する：リワード広告実行時の処理を書く
        {
            isRewarded = false;
            ShowRewardResult();
        }
    }

    public void UserChoseToWatchAd()//ユーザーが広告を押した時に呼び出されるように設定する
    {
        if (this.rewardedAd.IsLoaded())
        {
            this.rewardedAd.Show();
        }
    }

    void RequestRewardAd()
    {
        string adUnitId = "ca-app-pub-3940256099942544/5224354917";//テスト用

        this.rewardedAd = new RewardedAd(adUnitId);

        // Load成功時に実行する関数の登録
        this.rewardedAd.OnAdLoaded += HandleRewardedAdLoaded;
        // Load失敗時に実行する関数の登録
        this.rewardedAd.OnAdFailedToLoad += HandleRewardedAdFailedToLoad;
        // 表示時に実行する関数の登録
        this.rewardedAd.OnAdOpening += HandleRewardedAdOpening;
        // 表示失敗時に実行する関数の登録
        this.rewardedAd.OnAdFailedToShow += HandleRewardedAdFailedToShow;
        // 報酬受け取り時に実行する関数の登録
        this.rewardedAd.OnUserEarnedReward += HandleUserEarnedReward;
        // 広告を閉じる時に実行する関数の登録
        this.rewardedAd.OnAdClosed += HandleRewardedAdClosed;

        AdRequest request = new AdRequest.Builder().Build();
        this.rewardedAd.LoadAd(request);
    }


    public void ShowRewardResult()
    {
        count++;
        messageText.text = count.ToString();
    }


    public void CreateAndLoadRewardedAd()
    {
        string adUnitId = "ca-app-pub-3940256099942544/5224354917";//テスト用

        this.rewardedAd = new RewardedAd(adUnitId);

        this.rewardedAd.OnAdLoaded += HandleRewardedAdLoaded;
        this.rewardedAd.OnUserEarnedReward += HandleUserEarnedReward;
        this.rewardedAd.OnAdClosed += HandleRewardedAdClosed;

        AdRequest request = new AdRequest.Builder().Build();
        this.rewardedAd.LoadAd(request);
    }


    public void HandleRewardedAdLoaded(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardedAdLoaded event received");
    }

    public void HandleRewardedAdFailedToLoad(object sender, AdErrorEventArgs args)
    {
        MonoBehaviour.print(
            "HandleRewardedAdFailedToLoad event received with message: "
                             + args.Message);

    }

    public void HandleRewardedAdOpening(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardedAdOpening event received");
    }

    public void HandleRewardedAdFailedToShow(object sender, AdErrorEventArgs args)
    {
        MonoBehaviour.print(
            "HandleRewardedAdFailedToShow event received with message: "
                             + args.Message);
    }

    public void HandleRewardedAdClosed(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardedAdClosed event received");
        CreateAndLoadRewardedAd();
    }

    public void HandleUserEarnedReward(object sender, Reward args)//報酬を受け取った時に実行する処理
    {
        string type = args.Type;
        double amount = args.Amount;
        MonoBehaviour.print(
            "HandleRewardedAdRewarded event received for "
                        + amount.ToString() + " " + type);

        isRewarded = true;//報酬を受け取ったらtrue
    }


}
