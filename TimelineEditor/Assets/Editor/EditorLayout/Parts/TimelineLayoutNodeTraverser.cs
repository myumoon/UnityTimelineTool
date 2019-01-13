using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TimelineLayout {
	
	public class LayoutNodeTraverser {
		private LayoutNode m_root = null;

		public LayoutNodeTraverser(LayoutNode handledRoot)
		{
			m_root = handledRoot;
		}

		// 最後の子供を取得
		public LayoutNode FindLastChild()
		{
			if(m_root == null) {
				return null;
			}

			var element = m_root.childRoot;
			if(element != null) {
				while(element.nextSibling != null) {
					element = element.nextSibling;
				}
			}

			return element;
		}

		// 幅優先でトラバース
		public IEnumerable<LayoutNode> Traverse()
		{
			Queue<LayoutNode> nodeQueue = new Queue<LayoutNode>();
			if(m_root != null) {
				yield return m_root;
			}
			nodeQueue.Enqueue(m_root);

			LayoutNode execNode = null;
			while(0 < nodeQueue.Count) {
				execNode = nodeQueue.Dequeue();
				yield return execNode;
			
				execNode = execNode.childRoot;
				while(execNode != null) {
					nodeQueue.Enqueue(execNode);
					execNode = execNode.nextSibling;
				}
			}

		}

	}

}