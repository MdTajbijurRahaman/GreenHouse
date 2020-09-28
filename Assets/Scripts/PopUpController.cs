using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PopUpController : MonoBehaviour {

    public SoundController soundController;
    public float timeUnitsToDelay;
    public GrowingStep currentStep=GrowingStep.SEED;
    public Text timer;
    public Image popupButtonImage;
    public SpriteRenderer plot1;
    public PanelConroller panelConroller;
    public Sprite[] itemSprites;


    public bool isFlower;

    public Sprite[] sprites;

    private bool isTiming = false;
    private int cuttingPrice;
    private float seedingTimes;
    private float waterTimes;
    private float fartilizerTimes;
    private float cuttingTimes;


    // Use this for initialization
    void Start() {


    }

    // Update is called once per frame
    void Update() {

    }


    public void PlantItem(int cuttingPrice,int index) {
        plot1.sprite = itemSprites[0];
        currentStep = GrowingStep.WATER;
        this.cuttingPrice=cuttingPrice;

        seedingTimes = index * timeUnitsToDelay;
        waterTimes = index * timeUnitsToDelay;
        fartilizerTimes = index * timeUnitsToDelay;
        cuttingTimes = 1f;

        StartCoroutine(GetTimer(seedingTimes));
    }
    public void PopupClick() {
        if (!isTiming&&!panelConroller.isPanelUp ) {
            switch (currentStep)
            {
                case GrowingStep.SEED:
                    
                    if (UtilityManeger.unitGold <= UtilityManeger.currentGold)
                        panelConroller.AnimationIn(this, isFlower);
                    else
                        return;
                    
                    break;
                case GrowingStep.WATER:
                    soundController.PopUpClick();
                    plot1.sprite = itemSprites[1];
                    currentStep = GrowingStep.FARTILIZER;

                    StartCoroutine(GetTimer(waterTimes));
                    break;
                case GrowingStep.FARTILIZER:
                    soundController.PopUpClick();
                    plot1.sprite = itemSprites[2];
                    currentStep = GrowingStep.CUTTER;

                    StartCoroutine(GetTimer(fartilizerTimes));
                    break;
                case GrowingStep.CUTTER:
                    soundController.CoinEarn();
                    plot1.sprite = null;
                    currentStep = GrowingStep.SEED;
                    UtilityManeger.currentGold = UtilityManeger.currentGold+ cuttingPrice;
                    if (isFlower && UtilityManeger.unlockFloewerLevel < UtilityManeger.levelTotal)
                    {
                        UtilityManeger.unlockFloewerLevel++;
                        UtilityManeger.currentFlowerLevel++;
                       
                    }
                    else if (!isFlower && UtilityManeger.unlockFruitLevel < UtilityManeger.levelTotal)
                    {
                        UtilityManeger.unlockFruitLevel++;
                        UtilityManeger.currentFruitLevel++;
                    }
                    UtilityManeger.SaveCurrentLevel();
                    UtilityManeger.SaveGoldScore();
                    UtilityManeger.SaveUnlockLevel();
                    StartCoroutine(GetTimer(cuttingTimes));
                    break;

            }
            popupButtonImage.gameObject.SetActive(false);
        }
    }


    IEnumerator GetTimer(float time) {
        isTiming = true;
        while (time >= 0) { 
            int seconds =(int) time % 60;
            int minutes =(int) time / 60;
            if(UtilityManeger.isEnglish)
                timer.text = minutes + ":" + seconds;
            else
                timer.text = WordCoverterIntegerToString( minutes) + ":" + WordCoverterIntegerToString(seconds);
            time--;
            yield return new WaitForSeconds(1);
           
        }
        popupButtonImage.gameObject.SetActive(true);
        switch (currentStep)
        {
            case GrowingStep.SEED:
                popupButtonImage.sprite = sprites[0];
                break;
            case GrowingStep.WATER:
                popupButtonImage.sprite = sprites[1];
                break;
            case GrowingStep.FARTILIZER:
                popupButtonImage.sprite = sprites[2];
                break;
            case GrowingStep.CUTTER:
                popupButtonImage.sprite = sprites[3];
                break;

        }
        timer.text = "";
        isTiming = false;
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
