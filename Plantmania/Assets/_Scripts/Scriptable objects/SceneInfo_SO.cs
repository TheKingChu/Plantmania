using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SceneInfo", menuName = "SceneInfo", order = 50)]
public class SceneInfo_SO : ScriptableObject
{
    public bool isNextScene = true;

    private void OnEnable()
    {
        isNextScene = true;
    }
}
