using System;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class InteractableEvents
{
	public string eventName;
	public UnityEvent unityEvent;
	public bool isSceneTransition; // Thêm thuộc tính này để xác định sự kiện chuyển cảnh

	public void Invoke()
	{
		unityEvent.Invoke();
	}
}
