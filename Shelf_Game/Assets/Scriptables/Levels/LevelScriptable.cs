using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Level", menuName = "Levels")]
public class LevelScriptable : ScriptableObject
{
    public string levelName;
    [SerializeField]
    public List<GameObject> itemPrefabs = new List<GameObject>();
}