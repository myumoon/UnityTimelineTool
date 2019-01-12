using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TimelineLayout {
	
	public class GUILayoutNode {
		private GUILayoutNode m_parent      = null;
		private GUILayoutNode m_child       = null;
		private GUILayoutNode m_prevSibling = null;
		private GUILayoutNode m_nextSibling = null;

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

		// 姉を取得
		public GUILayoutNode prevSibling {
			private set { m_prevSibling = value; }
			get { return m_prevSibling; }
		}

		// 妹を取得
		public GUILayoutNode nextSibling {
			private set { m_nextSibling = value; }
			get { return m_nextSibling; }
		}

		// 子を追加
		public void AddChild(GUILayoutNode addedChild)
		{
			if(childRoot == null) {
				childRoot = addedChild;
			}
			else {
				GUILayoutElementTraverser traverser = new GUILayoutElementTraverser(childRoot);
				var lastChild = traverser.FindLastChild();
				lastChild.nextSibling = addedChild;
			}
		}

		// 親にアタッチ
		public void AttachToParent(GUILayoutNode targetParent)
		{
			GUILayoutElementTraverser traverser = new GUILayoutElementTraverser(targetParent);
			var lastChild = traverser.FindLastChild();

			parent = targetParent;
			lastChild.nextSibling = this;
			prevSibling = lastChild;
		}

		// 親から切り離す
		public void DetachFromParent()
		{
			if(parent.childRoot == this) {
				parent.childRoot = nextSibling;
			}
			if(prevSibling != null) {
				prevSibling.nextSibling = nextSibling;
			}
			if(nextSibling != null) {
				nextSibling.prevSibling = prevSibling;
			}
			parent = null;
		}
	}

}