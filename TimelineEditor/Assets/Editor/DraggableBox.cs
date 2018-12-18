using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class DraggableBox : IDrawableParts, IDraggableParts {
	Rect    m_rect;
	Vector2 m_originPos   = Vector2.zero;
	Color   m_color       = Color.red;
	bool    m_selected    = false;
	Vector2 m_mouseOffset = Vector2.zero;

	public DraggableBox(Rect rect)
	{
		m_rect = rect;
		m_originPos = new Vector2(m_rect.x, m_rect.y);
	}
	public DraggableBox(Rect rect, Color color)
	{
		m_rect = rect;
		m_originPos = new Vector2(m_rect.x, m_rect.y);
		m_color = color;
	}

	public Rect Draw()
	{
		//GUI.Label(m_rect, "text");
		//GUI.Box(m_rect, "testtext");
		EditorGUI.DrawRect(m_rect, m_color);
		//Debug.Log("@@@DrawRect " + m_rect);
		return m_rect;
	}

	private Vector2 Pos { 
		get { 
			return new Vector2(m_rect.x, m_rect.y); 
		}
		set {
			m_rect.x = value.x;
			m_rect.y = value.y;
		} 
	}

	public void OnSelect(Vector2 mousePos)
	{
		m_selected = true;
		m_mouseOffset = mousePos - Pos;
		Debug.Log("@@@OnSelect");
	}

	public void OnUnselect()
	{
		m_selected = false;
		Debug.Log("@@@OnUnselect");
	}

	public bool IsSelected()
	{
		return m_selected;
	}

	public Rect GetRect()
	{
		return m_rect;
	}

	public void OnDrag(Vector2 move)
	{
		Pos = Pos + move;
		//Debug.Log("@@@OnDrag m_rect:" + m_rect);
	}

	public void OnRelease()
	{
		m_originPos.x = m_rect.x;
		m_originPos.y = m_rect.y;
		Debug.Log("@@@OnRelease m_rect:" + m_rect);
	}

	public void OnRevert()
	{
		m_rect.x = m_originPos.x;
		m_rect.y = m_originPos.y;
		Debug.Log("@@@OnRevert m_rect:" + m_rect);
	}
}
