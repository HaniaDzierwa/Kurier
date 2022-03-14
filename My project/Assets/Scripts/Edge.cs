using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Edge
{
  
    private float distance;
    private int idStart;
    private int idEnd;


    public Edge (float distance, int idStart, int idEnd)
    {
      
        this.distance = distance;
        this.idStart = idStart;
        this.idEnd = idEnd;


      
    }

  

   public void setDistance(float distance)
    {
        this.distance = distance;
    }

    

    public float getDistance()
    {
        return this.distance;
    }


    public int getidStart()
    {
        return this.idStart;
    }

    public int getidEnd()
    {
        return this.idEnd;
    }


}