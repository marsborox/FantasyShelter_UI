using UnityEngine;

[System.Serializable]//means we can save it in file
public class GameSaveData 
{
    public string name;
    public int level;
    public int health;
    public float[] position;

    
    public GameSaveData(TestSaveObject saveObject)
    { 
        name = saveObject.name;
        level = saveObject.level;
        health = saveObject.health;
        position = new float[3];
        position[0] = saveObject.transform.position.x;
        position[1] = saveObject.transform.position.y;
        position[2] = saveObject.transform.position.z;

    }
}