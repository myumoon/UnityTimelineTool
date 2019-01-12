using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TimelineLayout {
	
	public class LayoutNode {
		private LayoutNode m_parent      = null;
		private LayoutNode m_child       = null;
		private LayoutNode m_prevSibling = null;
		private LayoutNode m_nextSibling = null;

		// 親を取得
		public LayoutNode parent {
			private set { m_parent = value; }
			get { return m_parent; }
		}

		// 最初の子を取得
		public LayoutNode childRoot {
			private set { m_child = value; }
			get { return m_child; }
		}

		// 姉を取得
		public LayoutNode prevSibling {
			private set { m_prevSibling = value; }
			get { return m_prevSibling; }
		}

		// 妹を取得
		public LayoutNode nextSibling {
			private set { m_nextSibling = value; }
			get { return m_nextSibling; }
		}

		// 子を追加
		public void AddChild(LayoutNode addedChild)
		{
			if(childRoot == null) {
				childRoot = addedChild;
			}
			else {
				LayoutNodeTraverser traverser = new LayoutNodeTraverser(childRoot);
				var lastChild = traverser.FindLastChild();
				lastChild.nextSibling = addedChild;
			}
		}

		// 親にアタッチ
		public void AttachToParent(LayoutNode targetParent)
		{
			LayoutNodeTraverser traverser = new LayoutNodeTraverser(targetParent);
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