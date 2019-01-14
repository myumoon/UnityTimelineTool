using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EditorLayout {

	interface IDrawableParts {
		/// <summary>
		/// 描画時に呼び出される
		/// </summary>
		/// <returns></returns>
		UnityEngine.Rect Render();

		/// <summary>
		/// 子供がすべて描画されたときに呼び出される
		/// </summary>
		void PostRender();
	}

}