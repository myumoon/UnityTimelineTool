using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IDrawableParts {
	/// <summary>
	/// 描画時に呼び出される
	/// </summary>
	/// <returns></returns>
	Rect Draw();

	/// <summary>
	/// 子供がすべて描画されたときに呼び出される
	/// </summary>
	void OnDrawnChildren();
}
