using Grow.Integrations.Extensions;
using UnityEngine;

namespace Grow.Integrations
{
	public class AppodealGrowIntegration : DelegateGrowIntegration {

		private const string TAG = "GROW AppodealIntegration";

		// Integration instance

		private static AppodealGrowIntegration instance;

		private AppodealGrowIntegration() {}

		private static AppodealGrowIntegration Instance
		{
			get
			{
				if (instance == null)
				{
					instance = new AppodealGrowIntegration();
				}
				return instance;
			}
		}

		// Integration specific implementation

		public override string GetIntegrationName() {
			return "appodeal";
		}

		public override string GetIntegrationDisplayName() {
			return "Appodeal";
		}

		public override string GetIntegrationVersion() {
			return "1.0.0";
		}

		public override string[] GetDependencies() {
			return new string[]{ };
		}

		public override void bindEvents() {
			var appodealInterstitialManager = GetType("com.appodeal.ads.InterstitialCallbacks");
			if (appodealInterstitialManager != null) {
				this.bindEvents(appodealInterstitialManager, typeof(AppodealInterstitialEvents));
			}
			var appodealVideoManager = GetType("com.appodeal.ads.SkippableVideoCallbacks");
			if (appodealVideoManager != null) {
				this.bindEvents(appodealVideoManager, typeof(AppodealVideoEvents));
			}
			var appodealRewardedVideoManager = GetType("com.appodeal.ads.RewardedVideoCallbacks");
			if (appodealRewardedVideoManager != null) {
				this.bindEvents(appodealRewardedVideoManager, typeof(AppodealRewardedVideoEvents));
			}
			var appodealBannerManager = GetType("com.appodeal.ads.BannerCallbacks");
			if (appodealBannerManager != null) {
				this.bindEvents(appodealBannerManager, typeof(AppodealBannerEvents));
			}
		}

		private class AppodealInterstitialEvents {
			public void onInterstitialLoaded(bool isPrecache) {
				AppodealGrowIntegration.Instance.OnAdLoaded(AdType.INTERSTITIAL);
			}
			public void onInterstitialFailedToLoad() {
				AppodealGrowIntegration.Instance.OnAdFailedToLoad(AdType.INTERSTITIAL);
			}
			public void onInterstitialShown() {
				AppodealGrowIntegration.Instance.OnAdDisplayed(AdType.INTERSTITIAL);
			}
			public void onInterstitialClicked() {
				AppodealGrowIntegration.Instance.OnAdClicked(AdType.INTERSTITIAL);
			}
			public void onInterstitialClosed() {
				AppodealGrowIntegration.Instance.OnAdLoaded(AdType.INTERSTITIAL);
			}
		}

		private class AppodealVideoEvents {
			public void onSkippableVideoLoaded() {
				AppodealGrowIntegration.Instance.OnAdLoaded(AdType.VIDEO);
			}
			public void onSkippableVideoFailedToLoad() {
				AppodealGrowIntegration.Instance.OnAdFailedToLoad(AdType.VIDEO);
			}
			public void onSkippableVideoShown() {
				AppodealGrowIntegration.Instance.OnAdDisplayed(AdType.VIDEO);
			}
			public void onSkippableVideoFinished() {
				AppodealGrowIntegration.Instance.OnRewardedVideoCompleted(AdType.VIDEO);
			}
			public void onSkippableVideoClosed() {
				AppodealGrowIntegration.Instance.OnAdClosed(AdType.VIDEO);
			}
		}

		private class AppodealRewardedVideoEvents {
			public void onRewardedVideoLoaded() {
				AppodealGrowIntegration.Instance.OnAdLoaded(AdType.REWARDED_VIDEO);
			}
			public void onRewardedVideoFailedToLoad() {
				AppodealGrowIntegration.Instance.OnAdFailedToLoad(AdType.REWARDED_VIDEO);
			}
			public void onRewardedVideoShown() {
				AppodealGrowIntegration.Instance.OnAdDisplayed(AdType.REWARDED_VIDEO);
			}
			public void onRewardedVideoFinished(int amount, string name) {
				AppodealGrowIntegration.Instance.OnRewardedVideoCompleted(AdType.REWARDED_VIDEO, name, (float)amount);
			}
			public void onRewardedVideoClosed() {
				AppodealGrowIntegration.Instance.OnAdClosed(AdType.REWARDED_VIDEO);
			}
		}

		private class AppodealBannerEvents {
			public void onBannerLoaded(bool isPrecache) {
				AppodealGrowIntegration.Instance.OnAdLoaded(AdType.BANNER);
			}
			public void onBannerFailedToLoad() {
				AppodealGrowIntegration.Instance.OnAdFailedToLoad(AdType.BANNER);
			}
			public void onBannerShown() {
				AppodealGrowIntegration.Instance.OnAdDisplayed(AdType.BANNER);
			}
			public void onBannerClicked() {
				AppodealGrowIntegration.Instance.OnAdClicked(AdType.BANNER);
			}
		}
	}
}
