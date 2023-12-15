using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeCounter
{
    public float TotalTime { get; private set; }
    private float timeLeft;

    public TimeCounter(float totalTime)
    {
        TotalTime = totalTime;
        timeLeft =  TotalTime;
    }
   
    
    public bool IsTickFinished(float deltaTime) 
    {
        if (this.timeLeft > 0) //5
        {
            this.timeLeft -= deltaTime; //.1F
            return false; //4.8
        }
        else
        {
            this.timeLeft = this.TotalTime; //5
        }
        return true;
    }
    public float GetTimeLeft()
    {
        return this.timeLeft;
    }
    
}