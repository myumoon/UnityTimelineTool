using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIRenderer {
	private List<GUILayoutRenderContext> m_renderQueue = new List<GUILayoutRenderContext>();

	public void AddRenderObject(GUILayoutRenderContext context)
	{
		m_renderQueue.Add(context);
	}

	public void Render()
	{

	}
}
