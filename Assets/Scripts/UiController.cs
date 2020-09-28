using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UiController : MonoBehaviour
{

    public SoundController soundController;
    public Image soundButtonImage;
    public Image languageButtonImage;
    public Sprite[] languageButtonSprites;
    public Sprite[] soundSprites;

    // Use this for initialization
    void Start()
    {
        UtilityManeger.InitData();
        Init();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {

            // Quit the application
            Application.Quit();
        }

    }

    private void Init()
    {
       


        if (UtilityManeger.isSound)
        {
            // audioSource.mute = false;
            //audioSource.Play();
            soundController.OnPlay();
            soundButtonImage.sprite = soundSprites[1];
        }
        else
        {
            //audioSource.mute = true;
            // audioSource.Play();
            soundController.OnMute();
            soundButtonImage.sprite = soundSprites[0];
        }

        if (UtilityManeger.isEnglish)
            languageButtonImage.sprite = languageButtonSprites[0];
        else
            languageButtonImage.sprite = languageButtonSprites[1];


       
    }

  

    public void PlayButtonClick()
    {
        soundController.ButtonClick();
        SceneManager.LoadScene(1);
    }

    public void RatingButtonClick()
    {
        soundController.ButtonClick();
    }

    public void RatingCloseButtonClick()
    {
        soundController.ButtonClick();
    }

    public void ShareButtonClick()
    {
        soundController.ButtonClick();
#if UNITY_ANDROID
        // Get the required Intent and UnityPlayer classes.
        AndroidJavaClass intentClass = new AndroidJavaClass("android.content.Intent");
        AndroidJavaClass unityPlayerClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");

        // Construct the intent.
        AndroidJavaObject intent = new AndroidJavaObject("android.content.Intent");
        intent.Call<AndroidJavaObject>("setAction", intentClass.GetStatic<string>("ACTION_SEND"));
        intent.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_TEXT"), "Here's the text I want to share.");
        intent.Call<AndroidJavaObject>("setType", "text/plain");

        // Display the chooser.
        AndroidJavaObject currentActivity = unityPlayerClass.GetStatic<AndroidJavaObject>("currentActivity");
        AndroidJavaObject chooser = intentClass.CallStatic<AndroidJavaObject>("createChooser", intent, "Share");
        currentActivity.Call("startActivity", chooser);
#endif
    }

    public void InAppPurChaseButtonClick() { }

    public void LanguageButtonClick()
    {
        UtilityManeger.isEnglish = !UtilityManeger.isEnglish;
        UtilityManeger.SaveLanguage();

        if (UtilityManeger.isEnglish)
            languageButtonImage.sprite = languageButtonSprites[0];
        else
            languageButtonImage.sprite = languageButtonSprites[1];
    }

    public void SoundButtonClick()
    {
        soundController.ButtonClick();
        UtilityManeger.isSound = !UtilityManeger.isSound;
        UtilityManeger.SaveSound();
        if (UtilityManeger.isSound)
        {
            soundController.OnPlay();
            soundButtonImage.sprite = soundSprites[1];
        }
        else
        {
            soundController.OnMute();
            soundButtonImage.sprite = soundSprites[0];
        }

    }



    public void BackgroundSoundPlay() {
        
    }






}
