using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDraggableParts : ISelectableParts {
	void OnDrag(Vector2 mousePos);
	void OnRelease();
	void OnRevert();
}
