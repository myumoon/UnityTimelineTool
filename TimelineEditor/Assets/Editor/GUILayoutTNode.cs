using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUILayoutNode {
	private GUILayoutNode m_parent  = null;
	private GUILayoutNode m_child   = null;
	private GUILayoutNode m_sibling = null;

	// 親を取得
	public GUILayoutNode parent {
		private set { m_parent = value; }
		get { return m_parent; }
	}

	// 最初の子を取得
	public GUILayoutNode childRoot {
		private set { m_child = value; }
		get { return m_child; }
	}

	// 兄弟を取得
	public GUILayoutNode sibling {
		private set { m_sibling = value; }
		get { return m_sibling; }
	}

	// 子を追加
	public void AddChild(GUILayoutNode addedChild)
	{
		if(childRoot == null) {
			childRoot = addedChild;
		}
		else {
		}
	}

	// 親にアタッチ
	public void AttachToParent(GUILayoutNode parent)
	{
		m_parent = parent;
		
	}

	// 親から切り離す
	public void DetachFromParent()
	{
		m_parent.
		m_parent = null;
	}
}
