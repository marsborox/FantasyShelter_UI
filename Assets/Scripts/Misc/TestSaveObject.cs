using UnityEngine;

public class TestSaveObject : MonoBehaviour
{
    public string heroName = "Johnny";
    public int level = 5;
    public int health = 10;

    private void Start()
    {
        //GameSaveLoadSystem.instance.SaveObject(this);
    }

    public void SaveThisObject()
    {
        // he would use SaveSystem.SaveObject(this);
        GameSaveLoadSystem.instance.SaveObject(this);
    }
    public void LoadThisObject()
    {
        GameSaveData data = GameSaveLoadSystem.instance.LoadObject();
        name = data.name;
        level = data.level;
        health = data.health;

        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        transform.position = position;
        Debug.Log("Load Finished");

    }
}
