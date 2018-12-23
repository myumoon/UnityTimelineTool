using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CompoentData01 {
	public int     m_intData;
	public string  m_stringData;
	public Vector3 m_vectorData;
}

public class TimelineComponent01 : MonoBehaviour {

	[SerializeField]
	private float m_start;

	[SerializeField]
	private float m_end;

	[SerializeField]
	private CompoentData01 m_componentData;
}
