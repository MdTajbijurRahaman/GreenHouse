using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameUiController : MonoBehaviour {


    public Text currentGoldText;
    
    public Text[] itemPricesText;


	// Use this for initialization
	void Start () {
       // UtilityManeger.SaveGoldScore();
        UtilityManeger.InitData();
        
            for (int i = 0; i < itemPricesText.Length; i++)
            {
            if (UtilityManeger.isEnglish)
                itemPricesText[i].text = "" + (i + 1) * UtilityManeger.unitGold;
            else
                itemPricesText[i].text = WordCoverterIntegerToString((i + 1) * UtilityManeger.unitGold);
        }
        }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Escape))
            SceneManager.LoadScene(0);



        if (UtilityManeger.isEnglish)
            currentGoldText.text = "" + UtilityManeger.currentGold;
        else
            currentGoldText.text=WordCoverterIntegerToString(UtilityManeger.currentGold);

    }


    public string WordCoverterIntegerToString(int num)
    {
        string result = "";
        while (num > 0) //do till num greater than  0
        {
            int mod = num % 10;  //split last digit from number
            num = num / 10;    //divide num by 10. num /= 10 also a valid one


            result = BanglaCover(mod) + result;


        }

        return result;
    }


    public string BanglaCover(int mod)
    {

        switch (mod)
        {
            case 1:
                return "১";

            case 2:
                return "২";

            case 3:
                return "৩";

            case 4:
                return "৪";

            case 5:
                return "৫";

            case 6:
                return "৬";

            case 7:
                return "৭";

            case 8:
                return "৮";

            case 9:
                return "৯";

            default:
                return "০";



        }
    }
}
