using UnityEngine;
using System.Collections;

public class Global : MonoBehaviour {


    int currentAnimation;
    public Animator anim;


    public void SaveExp(int EXP)
    {
        int temp;
        if (PlayerPrefs.HasKey("Exp"))
        {
            temp = PlayerPrefs.GetInt("Exp") + EXP;
        }
        else {
            temp = EXP;
        }

        PlayerPrefs.SetInt("Exp",temp);
        PlayerPrefs.Save();
    }
    public int getExp()
    {
        if(PlayerPrefs.HasKey("Exp"))
            return PlayerPrefs.GetInt("Exp");
        else
            return 0;
    }


    
    //animacion
    public int getCurrentAnimation()
    {
        return currentAnimation;
    }
    public void setAnimIdle() //idle
    {
        currentAnimation = 0;
        anim.SetInteger("animacion", currentAnimation);
    }
    public void setAnimRun() //run
    {
        currentAnimation = 1;
        anim.SetInteger("animacion", currentAnimation);
    }
    public void setAnimWrong()//wrong
    {
        currentAnimation = 2;
        anim.SetInteger("animacion", currentAnimation);
    }
    public void setAnimCorrect()//correct
    {
        currentAnimation = 3;
        anim.SetInteger("animacion", currentAnimation);
    }
}
