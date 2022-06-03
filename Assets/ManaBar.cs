using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaBar : MonoBehaviour
{
    public Image manaBar;
    public Text manaText;

    public float myMana;

    private float currentMana;
    public Button button; 


    // Start is called before the first frame update
    void Start()
    {
        currentMana = myMana;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentMana < myMana)
        {
            manaBar.fillAmount = Mathf.MoveTowards(manaBar.fillAmount, 1f, Time.deltaTime * 0.1f);
            currentMana = Mathf.MoveTowards(currentMana / myMana, 1f, Time.deltaTime * 0.1f) * myMana;
            button.interactable = true;
        }
        if(currentMana < 0)
        {
            currentMana = 0;

        }

        manaText.text = "" + Mathf.FloorToInt(currentMana);
    }

    public void Magic(float mana)
    {
        if (mana <= currentMana)
        {
            currentMana -= mana;
            manaBar.fillAmount -= mana / myMana;
            button.interactable = true;

        }
        else if(currentMana <= mana)
        {
            button.interactable = false;
        }
    }

}
