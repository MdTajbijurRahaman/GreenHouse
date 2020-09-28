using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UtilityManeger  {


    public static int levelTotal = 6;
    public static int unitGold=100;
    public static int currentFlowerLevel = 0;
    public static int unlockFloewerLevel = 1;
    public static int currentFruitLevel = 0;
    public static int unlockFruitLevel = 1;
    public static int currentGold = 600;

    public static bool isSound = true;
    public static bool isEnglish = true;


    public static void InitData() {

        if (PlayerPrefs.HasKey("gold"))
            currentGold = PlayerPrefs.GetInt("gold");
        else 
            PlayerPrefs.SetInt("gold", currentGold);



        if (PlayerPrefs.HasKey("flower_unlock_level"))
            unlockFloewerLevel = PlayerPrefs.GetInt("flower_unlock_level");
        else
            PlayerPrefs.SetInt("flower_unlock_level", unlockFloewerLevel);

        if (PlayerPrefs.HasKey("flower_current_level"))
            currentFlowerLevel = PlayerPrefs.GetInt("flower_current_level");
        else
            PlayerPrefs.SetInt("flower_current_level", currentFlowerLevel);



        if (PlayerPrefs.HasKey("fruit_unlock_level"))
            unlockFruitLevel = PlayerPrefs.GetInt("fruit_unlock_level");
        else
            PlayerPrefs.SetInt("fruit_unlock_level", unlockFruitLevel);

        if (PlayerPrefs.HasKey("fruit_current_level"))
            currentFruitLevel = PlayerPrefs.GetInt("fruit_current_level");
        else
            PlayerPrefs.SetInt("fruit_current_level", currentFruitLevel);



        if (PlayerPrefs.HasKey("sound"))
        {

            if (PlayerPrefs.GetInt("sound") == 0)
                isSound = false;
            else
                isSound = true;
        }
        else
        {
            if (isSound) 
                PlayerPrefs.SetInt("sound", 1);
            else
                PlayerPrefs.SetInt("sound", 0);
        }

        if (PlayerPrefs.HasKey("languge"))
        {
            if (PlayerPrefs.GetInt("languge") == 0)
                isEnglish = false;
            else
                isEnglish = true;
                
            
        }
        else
        {
            if(isEnglish)
              PlayerPrefs.SetInt("languge", 1);
            else
                PlayerPrefs.SetInt("languge", 0);
        }

    }

    public static void SaveGoldScore() {
        PlayerPrefs.SetInt("gold", currentGold);
    }

    public static void SaveUnlockLevel()
    {
        PlayerPrefs.SetInt("flower_unlock_level", unlockFloewerLevel);
        PlayerPrefs.SetInt("fruit_unlock_level", unlockFruitLevel);
    }

    public static void SaveCurrentLevel()
    {
        PlayerPrefs.SetInt("flower_current_level", currentFlowerLevel);
        PlayerPrefs.SetInt("fruit_current_level", currentFruitLevel);
    }

    public static void SaveSound() {
        if (isSound)
            PlayerPrefs.SetInt("sound", 1);
        else
            PlayerPrefs.SetInt("sound", 0);
    }

    public static void SaveLanguage() {
        if (isEnglish)
            PlayerPrefs.SetInt("languge", 1);
        else
            PlayerPrefs.SetInt("languge", 0);
    }
}

public enum GrowingStep {
    SEED,
    WATER,
    FARTILIZER,
    CUTTER

}
