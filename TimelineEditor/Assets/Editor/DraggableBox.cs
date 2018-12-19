using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class DraggableBox : IDrawableParts, IDraggableParts {
	private Vector2   m_originPos   = Vector2.zero;
	private Vector2   m_mouseOffset = Vector2.zero;
	private BoxDrawer m_boxDrawer   = new BoxDrawer();

	public DraggableBox(Rect rect)
	{
		m_boxDrawer.SetRect(rect);
		m_originPos = new Vector2(rect.x, rect.y);
	}
	public DraggableBox(Rect rect, Color color)
	{
		m_boxDrawer.SetRect(rect);
		m_boxDrawer.SetColor(color);
		m_originPos = new Vector2(rect.x, rect.y);
	}

	public Rect Draw()
	{
		return m_boxDrawer.Draw();
	}

	private Vector2 Pos { 
		get { 
			return m_boxDrawer.GetPos();
		}
		set {
			m_boxDrawer.SetPos((int)value.x, (int)value.y);
		} 
	}

	public void OnSelect(Vector2 mousePos)
	{
		m_boxDrawer.SetSelected(true);
		m_mouseOffset = mousePos - Pos;
		Debug.Log("@@@OnSelect");
	}

	public void OnUnselect()
	{
		m_boxDrawer.SetSelected(false);
		Debug.Log("@@@OnUnselect");
	}

	public bool IsSelected()
	{
		return m_boxDrawer.IsSelected();
	}

	public Rect GetRect()
	{
		return m_boxDrawer.GetRect();
	}

	public void OnDrag(Vector2 move)
	{
		Pos = Pos + move;
	}

	public void OnRelease()
	{
		m_originPos.x = m_boxDrawer.GetPos().x;
		m_originPos.y = m_boxDrawer.GetPos().y;
	}

	public void OnRevert()
	{
		m_boxDrawer.SetPos((int)m_originPos.x, (int)m_originPos.y);
	}
}
