using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Data
{ 

    public static float floatStrength = 0.20f;
    public static int maxScore;
    public static int lifeSpan = 15;
    public static int level = 1;
    public static float maxLevel = 4; //Inclusive

    public static float floatMultiplier = 0.1f;

    //Setter
    public static void setFloatStrength(float str)
    {
        floatStrength = str;
    }
    public static void setMaxScore(int scr)
    {
        maxScore = scr;
    }
    public static void setLifeSpan(int life)
    {
        lifeSpan = life;
    }

    //Getter
    public static float getFloatStrength()
    {
        return floatStrength;
    }
    public static int getMaxScore()
    {
        return maxScore;
    }
    public static int getLifeSpan()
    {
        return lifeSpan;
    }

    //Increment
    public static void incrementFloatStrength()
    {
        floatStrength += floatMultiplier;
    }

    public static void resetValues()
    {

        
        float strength = floatStrength - (maxLevel * floatMultiplier);
        Debug.Log(strength);
        setFloatStrength(strength);
        lifeSpan = 15;
        level = 1;
    }
}
