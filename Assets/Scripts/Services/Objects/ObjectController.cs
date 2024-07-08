using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController : MonoBehaviour
{
    public void ActiveObjects(List<GameObject> gameObjects) {
        foreach(GameObject element in gameObjects){
            element.SetActive(true);
        }
    }

    public void DeactiveObjects(List<GameObject> gameObjects)
    {
        foreach(GameObject gameObject in gameObjects)
        {
            gameObject.SetActive(false);
        }
    }
}
