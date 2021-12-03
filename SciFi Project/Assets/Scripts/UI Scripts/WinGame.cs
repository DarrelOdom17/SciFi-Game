using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WinGame : MonoBehaviour
{
    [HideInInspector]
    public int enemyCount;

    private GameObject winCanvas;
    private GameObject enemy;

    private void Start()
    {
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        winCanvas = GameObject.Find("WinCanvas");
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Enemy") == null)
        {
            winCanvas.gameObject.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
