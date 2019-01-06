using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.Timeline;
using UnityEngine.Playables;


public static class TimelineOutput {

	[MenuItem("GameObject/Timeline/Convert Timeline to Component", false, 10)]
	public static void ConvertTimelineToComponent()
	{
		Debug.Log("ConvertTimelineToComponent");
		string name = Selection.activeGameObject.name;
		string timelineName = name;
		//string timelinePath = "Assets/TimlineTest/TimelineData/" + timelineName + ".prefab";
		string timelinePath = "Assets/TimlineTest/Playable/" + timelineName + ".prefab";

		Debug.Log("asset path:" + timelinePath);
		var asset = AssetDatabase.LoadAssetAtPath<PlayableAsset>(timelinePath);
		Debug.Log("asset.name:" + asset.name);
	}
}
