using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class PartsDragger {
	private PartsSelector         m_selector = null;
	private List<IDraggableParts> m_draggableParts = new List<IDraggableParts>();
	private bool                  m_drag = false;
	private Vector2               m_prevMousePos = Vector2.zero;

	public PartsDragger()
	{

	}

	public PartsDragger(PartsSelector selector)
	{
		m_selector = selector;
	}

	public void Initialize(PartsSelector selector)
	{
		m_selector = selector;
	}

	public void Register(IDraggableParts parts)
	{
		if(!m_draggableParts.Contains(parts)) {
			m_draggableParts.Add(parts);
		}
	}

	public void Unregister(IDraggableParts parts)
	{
		m_draggableParts.Remove(parts);
	}

	public void Update()
	{
		if(Event.current.type == EventType.MouseDown) {
			m_prevMousePos = Event.current.mousePosition;
		}

		bool draggable = false;
		for(int i = 0; i < m_draggableParts.Count; ++i) {
			var parts = m_draggableParts[i];
			if(parts.IsSelected()) {
				if(parts.GetRect().Contains(Event.current.mousePosition)) {
					draggable = true;
					break;
				}
			}
		}

		{
			if(Event.current.type == EventType.MouseDrag) {
				//m_drag = true;
				var deltaDrag = Event.current.mousePosition - m_prevMousePos;

				for(int i = 0; i < m_draggableParts.Count; ++i) {
					var dragParts = m_draggableParts[i];
					if(dragParts.IsSelected()) {
						dragParts.OnDrag(deltaDrag);
					}
				}
				Debug.Log("Drag : mouse:" + Event.current.mousePosition);
				m_prevMousePos = Event.current.mousePosition;
			}
		}
		
		{
			if(Event.current.type == EventType.MouseUp) {
				for(int i = 0; i < m_draggableParts.Count; ++i) {
					if(m_draggableParts[i].IsSelected()) {
						m_draggableParts[i].OnRelease();
					}
				}
			}
		}

	}
}
