// (c) Copyright HutongGames, LLC 2010-2014. All rights reserved.
// REMOVED ECOSYSTEM FLAG TO AVOID DUPLICATES IN ECOSYSTEM BROWSER, AS IT SEARCHED THIS REP AS WELL


using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory(ActionCategory.Application)]
	[Tooltip("Open a Url link in the browser")]
	public class ApplicationOpenUrl : FsmStateAction
	{
		
		[RequiredField]
		public FsmString url;
		
		[Tooltip("When in webPlayer, will open a new window, define the name of that window here.")]
		public FsmString WebWindowTitle;
		
		public override void Reset()
		{
			url ="";
		}

		public override void OnEnter()
		{
			if (Application.isWebPlayer)
			{
#if UNITY_IPHONE
#else
				Application.ExternalEval("window.open('"+url+"','"+WebWindowTitle.Value+"')");
#endif
			}else{
				Application.OpenURL(url.Value);
			}
			Finish();
		}
	}
}