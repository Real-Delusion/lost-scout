using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Nivel
{
    public int ID;
    public string LevelName;
    public string Title;
    public bool Completed;
    public int Insignias;
    public bool Locked;
    public int MaxTime;
    public int MaxInteractions;
    public float RecordTime;
    public bool Available;

    public Nivel (int id, string levelName, string title, bool completed, int insignias, bool locked, int time, int interactions, float record, bool available){
        this.ID = id;
        this.LevelName = levelName;
        this.Title = title;
        this.Completed = completed;
        this.Insignias = insignias;
        this.Locked = locked;
        this.MaxTime = time;
        this.MaxInteractions = interactions;
        this.RecordTime = record;
        this.Available = available;
    }
}
