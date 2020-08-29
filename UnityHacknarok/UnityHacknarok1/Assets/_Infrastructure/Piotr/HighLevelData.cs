using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "High Level Data")]
public class HighLevelData : ScriptableObject
{
    public int deathCount;
    public Text deathCountText;

    public int currentLevelIndex;

}
