using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyCounter : MonoBehaviour
{
    public Text enemiesKilledText;
    public Text enemiesLeftText;

    int enemiesKilled = 0;
    int enemiesLeft;

    private void Start()
    {
        enemiesKilledText.text = enemiesKilled.ToString() + " Killed";
        //enemiesLeftText.text = 0;
    }
}
