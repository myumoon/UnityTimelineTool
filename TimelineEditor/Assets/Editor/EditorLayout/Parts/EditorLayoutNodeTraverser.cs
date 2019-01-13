using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EditorLayout {
	
	public class NodeTraverser {
		private Node m_root = null;

		public NodeTraverser(Node handledRoot)
		{
			m_root = handledRoot;
		}

		// 最後の子供を取得
		public Node FindLastChild()
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
		public IEnumerable<Node> Traverse()
		{
			Queue<Node> nodeQueue = new Queue<Node>();
			if(m_root != null) {
				yield return m_root;
			}
			nodeQueue.Enqueue(m_root);

			Node execNode = null;
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