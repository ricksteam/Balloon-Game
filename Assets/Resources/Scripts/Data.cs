using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data
{ 

    public static float floatStrength = 0.20f;
    //public static int maxScore;
    public static int lifeSpan = 15;
    public static int level = 1;
    public static int balloonsHit = 0;
    public static int balloonsMissed = 0;
    public static float balloonShift = -0.5f;

    //Setter
    public static void setFloatStrength(float str)
    {
        floatStrength = str;
    }
   /* public static void setMaxScore(int scr)
    {
        maxScore = scr;
    }*/
    public static void setLifeSpan(int life)
    {
        lifeSpan = life;
    }

    //Getter
    public static float getFloatStrength()
    {
        return floatStrength;
    }
    /* static int getMaxScore()
    {
        return maxScore;
    }*/
    public static int getLifeSpan()
    {
        return lifeSpan;
    }

    //Increment
    public static void incrementFloatStrength()
    {
        int totalBalloons = balloonsMissed + balloonsHit;
        Debug.Log("Total Balloons: " + totalBalloons);
        Debug.Log("Balloons Missed: " + balloonsMissed);
        if (balloonsMissed == 0) balloonsMissed = -1;
        
        float percentMissed = ((float)(totalBalloons - balloonsMissed) / totalBalloons);
        
        float newStrength = floatStrength * percentMissed;
        if (newStrength == 0) newStrength = floatStrength - (floatStrength / 2);
        if (newStrength <= 0.01f) newStrength = 0.02f;
        if (newStrength > 1) newStrength = 1;
        Debug.Log("Difficulty: " + newStrength * 100 + "%");
        floatStrength = newStrength;
        balloonsMissed = 0;
        balloonsHit = 0;
    }

    public static void resetValues()
    {


        float strength = 0.2f;
        Debug.Log(strength);
        setFloatStrength(strength);
        lifeSpan = 15;
        level = 1;
        balloonsHit = 0;
        balloonsMissed = 0;
    }
}
