using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EditorLayout {

	public class System {

		private List<IDraggableParts> m_draggableList = new List<IDraggableParts>();
		private PartsSelector m_selector = new PartsSelector();
		private PartsDragger  m_dragger  = new PartsDragger();

		public System()
		{
			m_dragger.Initialize(m_selector);
		}

		public void Build()
		{

		}

		public T NewDraggableParts<T>() where T : IDraggableParts, new()
		{
			var created = new T();
			m_draggableList.Add(created);

			return created;
		}
		
	}

}