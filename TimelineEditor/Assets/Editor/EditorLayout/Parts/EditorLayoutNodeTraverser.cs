using System.Collections;
using System.Collections.Generic;
using System;
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
		
		/// <summary>
		/// 幅優先でトラバース
		/// </summary>
		/// <returns></returns>
		public IEnumerable<Node> TraverseBreadthFirst()
		{
			return TraverseBreadthFirstIf(Node => true);
		}

		public IEnumerable<Node> TraverseBreadthFirstIf(Func<Node, bool> condition)
		{
			Queue<Node> nodeQueue = new Queue<Node>();
			if(m_root != null) {
				yield return m_root;
			}
			nodeQueue.Enqueue(m_root);

			Node execNode = null;
			while(0 < nodeQueue.Count) {
				execNode = nodeQueue.Dequeue();
				if(!condition(execNode)) {
					continue;
				}
				yield return execNode;
			
				execNode = execNode.childRoot;
				while(execNode != null) {
					nodeQueue.Enqueue(execNode);
					execNode = execNode.nextSibling;
				}
			}

		}

#if false
		/// <summary>
		/// 深さ優先でトラバース
		/// </summary>
		/// <returns></returns>
		public IEnumerable<Node> TraverseDepthFirst()
		{
			return TraverseDepthFirstIf(m_root, Node => true);
		}
#endif

		/// <summary>
		/// 幅優先でトラバースする
		/// </summary>
		/// <param name="startAction">開始時に呼び出される</param>
		/// <param name="endAction">子供探索後に呼び出される</param>
		/// <param name="condition">このノードを処理するかどうかの条件</param>
		/// <returns>conditionでfalseが帰ってきた場合はnullが帰る<returns>
		public void TraverseDepthFirst(Node current, Action<Node> startAction, Action<Node> endAction, Func<Node, bool> condition = null)
		{
			if(condition != null && !condition(current)) {
				return;
			}

			if(startAction != null) {
				startAction(current);
			}

			var child = current.childRoot;
			while(child != null) {
				TraverseDepthFirst(child, startAction, endAction, condition);
				child = child.nextSibling;
			}

			if(endAction != null) {
				endAction(current);
			}
		}
	}

}