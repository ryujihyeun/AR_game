using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SystemManager : MonoBehaviour
{
    public float numOut = 0f;
    public float numIn = 0f;
    public float totalOut = 0f;
    public float gameTime = 300.0f;
    private float timer = 0.0f;

    public TextMeshProUGUI textOut = null;
    public TextMeshProUGUI textIn = null;
    public TextMeshProUGUI textTime = null;

    SpawnManager spawn = null;
    UIButtonManager uIButton = null;

    // Start is called before the first frame update
    void Start()
    {
        // initialize text
        textIn.text = "IN:00%";
        textTime.text = "TIME:5-00";
        textOut.text = "OUT:" + numOut.ToString();

        GameObject tmp = GameObject.Find("SpawnManager");
        spawn = tmp.GetComponent<SpawnManager>();

        GameObject smObj = GameObject.Find("UIButtonManager");
        uIButton = smObj.GetComponent<UIButtonManager>();
    }

    // Update is called once per frame
    void Update()
    {
        // update gameTime and text
        gameTime -= Time.deltaTime;
        int minutes = Mathf.FloorToInt(gameTime / 60);
        int seconds = Mathf.FloorToInt(gameTime % 60);

        textTime.text = "TIME:" + string.Format("{0:}-{1:00}", minutes, seconds);

        // update numOut
        textOut.text = "OUT:" + numOut.ToString();
        timer += Time.deltaTime;
        if (timer > 30)
        {
            // call function that duplicate characters
            spawn.spawnNum = 0;
            timer = 0;
        }

        // update percent of success 
        float perIn = (numIn / totalOut) * 100;
        textIn.text = "IN:" + string.Format("{0:00}%", perIn);

        // if perIn is bigger than 80, game win
        if (perIn > 70)
        {
            spawn.isSpawn = false;
            Time.timeScale = 0.0f;
            uIButton.GameWin();
        }

        // Loose
        if ((spawn.totalNum > 37) && (numOut <= 0))
        {
            Time.timeScale = 0.0f;
            uIButton.GameLose();
        }

        // TimeOut
        if (gameTime < 0)
        {
            spawn.isSpawn = false;
            Time.timeScale = 0.0f;
            uIButton.GameLose();
        }
    }

    public void CountSuccessNum()
    {
        numIn += 1f;
        numOut -= 1f;
        float perIn = (numIn / totalOut) * 100;

        textIn.text = "IN:" + string.Format("{0:00}%", perIn);
    }
}
