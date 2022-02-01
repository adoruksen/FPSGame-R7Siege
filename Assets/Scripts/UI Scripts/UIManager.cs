using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            LevelManager.gameState = GameState.Settings;
            SettingsButtonFunc();
        }
    }

    public void PlayButtonFunc()
    {
        LevelManager.gameState = GameState.Normal;
        transform.parent.GetChild(3).gameObject.SetActive(false);
    }

    public void SettingsButtonFunc()
    {
        transform.GetChild(1).gameObject.SetActive(true);
        if (GameManager.RedBulletButton ==1)
        {
            transform.GetChild(1).GetChild(1).GetChild(0).GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("UI/On_Sprite");
        }
        else
        {
            transform.GetChild(1).GetChild(1).GetChild(0).GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("UI/Off_Sprite");
        }
        if (GameManager.HugeBulletButton ==1)
        {
            transform.GetChild(1).GetChild(1).GetChild(2).GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("UI/On_Sprite");
        }
        else
        {
            transform.GetChild(1).GetChild(1).GetChild(2).GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("UI/Off_Sprite");
        }
        if (GameManager.ExplosiveBulletButton ==1)
        {
            transform.GetChild(1).GetChild(1).GetChild(1).GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("UI/On_Sprite");
        }
        else
        {
            transform.GetChild(1).GetChild(1).GetChild(1).GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("UI/Off_Sprite");
        }
    }

    public void ExitButtonFunc()
    {
        LevelManager.gameState = GameState.Normal;
        transform.GetChild(1).gameObject.SetActive(false);
    }

    public void RedBulletOnFunc()
    {
        if (GameManager.RedBulletButton ==0)
        {
            GameManager.RedBulletButton = 1;
            transform.GetChild(1).GetChild(1).GetChild(0).GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("UI/On_Sprite");
        }
        else
        {
            GameManager.RedBulletButton = 0;
            transform.GetChild(1).GetChild(1).GetChild(0).GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("UI/Off_Sprite");
        }
    }

    public void ExplosiveBulletOnFunc()
    {
        if (GameManager.ExplosiveBulletButton == 0)
        {
            GameManager.ExplosiveBulletButton = 1;
            transform.GetChild(1).GetChild(1).GetChild(1).GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("UI/On_Sprite");
        }
        else
        {
            GameManager.ExplosiveBulletButton = 0;
            transform.GetChild(1).GetChild(1).GetChild(1).GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("UI/Off_Sprite");
        }
    }

    public void HugeBulletOnFunc()
    {
        if (GameManager.HugeBulletButton == 0)
        {
            GameManager.HugeBulletButton = 1;
            transform.GetChild(1).GetChild(1).GetChild(2).GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("UI/On_Sprite");
        }
        else
        {
            GameManager.HugeBulletButton = 0;
            transform.GetChild(1).GetChild(1).GetChild(2).GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("UI/Off_Sprite");
        }

    }

    
}
