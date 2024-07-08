using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptManager : MonoBehaviour
{
    public List<MonoBehaviour> scripts;
    public void EnableScript(int index)
    {
        //Check if the index is valid or not
        if (index - 1 < 0 || index - 1 >= scripts.Count)
        {
            Debug.LogError("Invalid index, valid index must be equal or larger than 1");
            return;
        }
        scripts[index-1].enabled = true;
    }

    public void DisableScript(int index)
    {
        if (index - 1 < 0 || index - 1 >= scripts.Count)
        {
            Debug.LogError("Invalid index, valid index must be equal or larger than 1\"");
            return;
        }
        scripts[index-1].enabled = false;
    }
}
