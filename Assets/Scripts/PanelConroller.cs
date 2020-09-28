using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelConroller : MonoBehaviour {


    public SoundController soundController;
    public Image [] unlockImages;

    public Sprite[] flower1; 
    public Sprite[] flower2; 
    public Sprite[] flower3; 
    public Sprite[] flower4; 
    public Sprite[] flower5; 
    public Sprite[] flower6;
    public Sprite[] fruit1;
    public Sprite[] fruit2;
    public Sprite[] fruit3;
    public Sprite[] fruit4;
    public Sprite[] fruit5;
    public Sprite[] fruit6;

    public Sprite[] panelSprites;
    private PopUpController popUp;
    private bool isFlower = false;
    public bool isPanelUp = false;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void AnimationIn(PopUpController popUp,bool isFlower) {
        this.popUp = popUp;
        this.isFlower = isFlower;
        isPanelUp = true;
        if (isFlower)
        {
            GetComponent<Image>().sprite = panelSprites[0];
            for (int i = 0; i < UtilityManeger.unlockFloewerLevel; i++)
            {
                unlockImages[i].gameObject.SetActive(false);
            }

        }
        else
        {
            GetComponent<Image>().sprite = panelSprites[1];
            
            for (int i = 0; i < UtilityManeger.unlockFruitLevel; i++)
            {
                unlockImages[i].gameObject.SetActive(false);
            }
        }
        soundController.PopUpClick();
        GetComponent<Animator>().SetBool("in",true);
    }

   

    public void PanelItemClick(int index) {
        

        if (index<UtilityManeger.unlockFloewerLevel+1 || index<UtilityManeger.unlockFruitLevel+1) {
          
            if (UtilityManeger.currentGold >= index * UtilityManeger.unitGold)
                UtilityManeger.currentGold = UtilityManeger.currentGold - index * UtilityManeger.unitGold;
            else
                return;

            if (isFlower)
            {
               
                switch (index)
                {
                    case 1:
                        popUp.itemSprites = flower1;                      
                        break;
                    case 2:
                        popUp.itemSprites = flower2;                      
                        break;
                    case 3:
                        popUp.itemSprites = flower3;                     
                        break;
                    case 4:
                        popUp.itemSprites = flower4;                    
                        break;
                    case 5:
                        popUp.itemSprites = flower5;                       
                        break;
                    case 6:
                        popUp.itemSprites = flower6;                       
                        break;
                }
            }
            else {
                switch (index)
                {
                    case 1:
                        popUp.itemSprites = fruit1;                       
                        break;
                    case 2:
                        popUp.itemSprites = fruit2;                       
                        break;
                    case 3:
                        popUp.itemSprites = fruit3;                      
                        break;
                    case 4:
                        popUp.itemSprites = fruit4;                     
                        break;
                    case 5:
                        popUp.itemSprites = fruit5;                   
                        break;
                    case 6:
                        popUp.itemSprites = fruit6;                      
                        break;
                }
                }
            popUp.PlantItem(index * UtilityManeger.unitGold + (int)((index * UtilityManeger.unitGold) * .25), index);
            soundController.PopUpClick();
            GetComponent<Animator>().SetBool("in", false);
            isPanelUp = false;

        }
        
      
    }
}
