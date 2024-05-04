using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShelfLock : MonoBehaviour
{
    public TextMeshProUGUI textMesh;
    public GameObject lockShelf;
    public int comboLock;
    private int countDown;
                
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        countDown = comboLock - PlayerPrefs.GetInt("localComboCounterPrefs");
        textMesh.text = countDown.ToString();
        if (PlayerPrefs.GetInt("localComboCounterPrefs") >= comboLock)
        {
            lockShelf.SetActive(false);
            Debug.LogError("true");
        }
    }
}
