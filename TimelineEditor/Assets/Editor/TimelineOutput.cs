using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public static class TimelineOutput {

	[MenuItem("GameObject/Timeline/Convert Timeline to Component", false, 10)]
	public static void ConvertTimelineToComponent()
	{
		Debug.Log("ConvertTimelineToComponent");
		string name = Selection.activeGameObject.name;
		string timelineName = "Timeline_" + name;
		string timelinePath = "Assets/TimlineTest/TimelineData/" + timelineName + ".prefab";

		var asset = AssetDatabase.LoadAssetAtPath<Timeline>(timelinePath);
	}
}
