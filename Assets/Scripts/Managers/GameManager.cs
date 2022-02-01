using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    static int explosiveBulletButton;
    static int redBulletButton;
    static int hugeBulletButton;
    private void Awake()
    {
        if (!PlayerPrefs.HasKey("explosiveBulletButton"))
        {
            PlayerPrefs.SetInt("explosiveBulletButton", 0);
        }

        if (!PlayerPrefs.HasKey("redBulletButton"))
        {
            PlayerPrefs.SetInt("redBulletButton", 0);
        }

        if (!PlayerPrefs.HasKey("hugeBulletButton"))
        {
            PlayerPrefs.SetInt("hugeBulletButton", 0);
        }
    }

    public static int ExplosiveBulletButton
    {
        get
        {
            if (!PlayerPrefs.HasKey("explosiveBulletButton"))
            {
                return 1;
            }
            return PlayerPrefs.GetInt("explosiveBulletButton");
        }
        set
        {
            explosiveBulletButton = value;
            PlayerPrefs.SetInt("explosiveBulletButton", explosiveBulletButton);
        }
    }

    public static int RedBulletButton
    {
        get
        {
            if (!PlayerPrefs.HasKey("redBulletButton"))
            {
                return 1;
            }
            return PlayerPrefs.GetInt("redBulletButton");
        }
        set
        {
            redBulletButton = value;
            PlayerPrefs.SetInt("redBulletButton", redBulletButton);
        }
    }

    public static int HugeBulletButton
    {
        get
        {
            if (!PlayerPrefs.HasKey("hugeBulletButton"))
            {
                return 1;
            }
            return PlayerPrefs.GetInt("hugeBulletButton");
        }
        set
        {
            hugeBulletButton = value;
            PlayerPrefs.SetInt("hugeBulletButton", hugeBulletButton);
        }
    }
}
