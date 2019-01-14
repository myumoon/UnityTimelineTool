using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartsSelector {
	private List<ISelectableParts> m_selectableParts = new List<ISelectableParts>();

	public void Register(ISelectableParts parts)
	{
		m_selectableParts.Add(parts);
	}

	public void Update()
	{
		if(IsClicked()) {
			if(!IsMultiSelectMode()) {
				UnselectAll();
			}
			for(int i = 0; i < m_selectableParts.Count; ++i) {
				ISelectableParts checkParts = m_selectableParts[i];
				if(checkParts.GetRect().Contains(Event.current.mousePosition)) {
					checkParts.OnSelect(Event.current.mousePosition);
				}
			}
		}
	}

	private bool IsClicked()
	{
		return (Event.current.type == EventType.MouseDown);
	}

	private bool IsMultiSelectMode()
	{
		if(	Event.current.keyCode == KeyCode.LeftControl  ||
			Event.current.keyCode == KeyCode.RightControl ||
			Event.current.keyCode == KeyCode.LeftCommand  ||
			Event.current.keyCode == KeyCode.RightCommand ) 
		{
			return true;
		}

		return false;
	}

	private void UnselectAll()
	{
		for(int i = 0; i < m_selectableParts.Count; ++i) {
			if(m_selectableParts[i].IsSelected()) {
				m_selectableParts[i].OnUnselect();
			}
		}
	}

	public List<ISelectableParts> MakeSelectedList()
	{
		List<ISelectableParts> selected = new List<ISelectableParts>();
		ActSelected((parts) => { selected.Add(parts); });
		return selected;
	}

	public void ActSelected(System.Action<ISelectableParts> action)
	{
		for(int i = 0; i < m_selectableParts.Count; ++i) {
			if(m_selectableParts[i].IsSelected()) {
				action(m_selectableParts[i]);
			}
		}
	}

}
