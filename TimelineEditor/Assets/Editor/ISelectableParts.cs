using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISelectableParts {
	void OnSelect(Vector2 mousePos);
	void OnUnselect();
	bool IsSelected();
	Rect GetRect();
}
