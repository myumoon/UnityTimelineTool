using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUILayoutElementTraverser {
	private GUILayoutNode m_root = null;

	public GUILayoutElementTraverser(GUILayoutNode handledRoot)
	{
		m_root = handledRoot;
	}

	// 最後の子供を取得
	public GUILayoutNode FindLastChild()
	{
		if(m_root == null) {
			return null;
		}

		var element = m_root;
		while(element.sibling != null) {
			element = element.sibling;
		}

		return element;
	}

	// 幅優先でトラバース
	public IEnumerable<GUILayoutNode> Traverse()
	{
		Queue<GUILayoutNode> nodeQueue = new Queue<GUILayoutNode>();
		if(m_root != null) {
			yield return m_root;
		}
		nodeQueue.Enqueue(m_root);

		GUILayoutNode execNode = null;
		while(0 < nodeQueue.Count) {
			execNode = nodeQueue.Dequeue();
			yield return execNode;
		
			execNode = execNode.childRoot;
			while(execNode != null) {
				nodeQueue.Enqueue(execNode);
				execNode = execNode.sibling;
			}
		}

	}

}
