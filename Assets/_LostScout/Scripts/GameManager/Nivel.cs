using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nivel : MonoBehaviour
{
    public int ID { get; set; }
    public string LevelName { get; set; }
    public string Title { get; set; }
    public bool Completed { get; set; }
    public int Insignias { get; set; }
    public bool Locked { get; set; }
    public int MaxTime { get; set; }
    public int MaxInteractions { get; set; }

    public Nivel (int id, string levelName, string title, bool completed, int insignias, bool locked, int time, int interactions){
        this.ID = id;
        this.LevelName = levelName;
        this.Title = title;
        this.Completed = completed;
        this.Insignias = insignias;
        this.Locked = locked;
        this.MaxTime = time;
        this.MaxInteractions = interactions;
    }

    public void Complete(){
        this.Completed = true;
    }

    public void Complete(int insignias){
        this.Completed = true;
        this.Insignias = insignias;
    }

    public void Lock (){
        this.Locked = true;
    }

    public void Unlock (){
        this.Locked = false;
    }

}
