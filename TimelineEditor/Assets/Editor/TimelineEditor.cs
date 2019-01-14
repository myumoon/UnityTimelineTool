using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public class TimelineEditor : EditorWindow {
	static EditorLayout.System m_layoutSystem = new EditorLayout.System();
	
	public TimelineEditor()
	{
	}

    [MenuItem("Timeline/ActionTimeline")]
    static void Open()
    {
		GetWindow<TimelineEditor>();
		m_layoutSystem.Build();
    }

	void Update()
	{
		Repaint();
	}

	void OnGUI()
	{
		wantsMouseMove = true;   // マウス情報を取得.

#if false
		GUILayout.BeginVertical();

		GUILayout.BeginHorizontal();
		GUILayout.Button("Save");
		GUILayout.Button("Revert");
		GUILayout.Button("Forward");
		GUILayout.EndHorizontal();

		GUILayout.BeginHorizontal();
		//GUILayout.BeginArea(new Rect(10, 10, 100, 100));
		m_windowRect = new Rect(20, 20, 200, 100);
		m_windowRect = GUILayout.Window(0, m_windowRect, DoMyWindow, "My Window", GUILayout.Width(100));
		GUILayout.Button("test2");
		//GUILayout.EndArea();
		GUILayout.EndHorizontal();

		GUILayout.EndVertical();
		
		GUILayout.Button("test3");

		m_partsSelector.Update();
		m_partsDragger.Update();
		
		foreach(var drawParts in m_drawList) {
			drawParts.Draw();
		}

		//box.Draw();
		//EditorGUI.DrawRect(new Rect(0, 0, 100, 100), new Color(0.1f, 0.1f, 0.1f, 0.1f));

		/*
		// マウス位置を取得.
		Debug.Log("mouse pos : " + Event.current.mousePosition);

		// マウス状態を取得.
		Debug.Log("mouse state : " + Event.current.type);

		// マウス移動で再描画を促す.
		if (Event.current.type == EventType.MouseMove) {
			Repaint();
		}
		*/

		/*
#if false
		base.OnGUI();
		windowRect = GUILayout.Window(0, windowRect, DoMyWindow, "My Window", GUILayout.Width(100));
#endif
		*/
#endif
	}


}
