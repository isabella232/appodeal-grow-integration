/*
 * Copyright (C) 2012-2016 Soomla Inc. - All Rights Reserved
 *
 *   Unauthorized copying of this file, via any medium is strictly prohibited
 *   Proprietary and confidential
 *
 *   Written by Refael Dakar <refael@soom.la>
 */

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
			var appodealManager = GetType("YOUR_EVENT_MANAGER_CLASS_HERE"); // TODO Replace with your namespace + class name
			if (appodealManager != null) {
				this.bindEvents(appodealManager, typeof(AppodealEvents));
			}
		}

		private class AppodealEvents {

			// Here you need to define the events you have.
			// Make sure that the name and parameter types match the event.

			public static void EVENT_EXAMPLE() {
				AppodealGrowIntegration.Instance.OnAdLoaded(AdType.INTERSTITIAL);
			}

		}
	}
}
