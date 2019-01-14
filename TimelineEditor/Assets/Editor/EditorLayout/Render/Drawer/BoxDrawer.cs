using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class BoxDrawer : EditorLayout.IDrawableParts {
	static int    SelectedLineWidth = 2;
	static Color  SelectedColor     = Color.blue;
	
	private bool    m_selected = false;
	private Rect    m_rect;
	private Texture m_texture = null;
	private Color   m_color = Color.white;

	public BoxDrawer()
	{
	}

	public BoxDrawer(Rect rect)
	{
		m_selected = false;
		m_rect = rect;
	}

	public void SetSelected(bool selected)
	{
		m_selected = selected;
	}

	public bool IsSelected()
	{
		return m_selected;
	}

	public void SetRect(Rect rect)
	{
		m_rect = rect;
	}

	public void SetSize(int w, int h)
	{
		m_rect.width = w;
		m_rect.height = h;
	}

	public void SetPos(int x, int y)
	{
		m_rect.x = x;
		m_rect.y = y;
	}

	public void SetColor(Color color)
	{
		m_color = color;
	}

	public Vector2 GetPos()
	{
		return m_rect.position;
	}

	public Rect GetRect()
	{
		return m_rect;
	}

	public UnityEngine.Rect Render()
	{
		if(m_selected) {
			EditorGUI.DrawRect(
				new Rect(
					m_rect.x - SelectedLineWidth,
					m_rect.y - SelectedLineWidth,
					m_rect.width + SelectedLineWidth * 2,
					m_rect.height + SelectedLineWidth * 2),
				SelectedColor
			);
		}
		EditorGUI.DrawRect(m_rect, m_color);

		return m_rect;
	}

	public void PostRender()
	{

	}

}
