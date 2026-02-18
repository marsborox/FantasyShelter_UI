using UnityEngine;
using System.IO;
using MessagePack;

public class SaveAndLoadSystem : Singleton<SaveAndLoadSystem>
{
    public static new SaveAndLoadSystem instance => Singleton<SaveAndLoadSystem>.instance;

    public string fileName = "/gameSave.sav";
    public string savePath;

    private void Awake()
    {
        base.Awake();
        savePath = Application.persistentDataPath + fileName;// sets to some default location
    }
    public void SaveAll()
    {
        Game_SaveData data = new Game_SaveData();
        foreach (Hero hero in HeroManager.instance.heroList)
        {
            Hero_SaveData heroData = hero.SaveHero();
            data.heroSaveList.Add(heroData);
        }

        byte[] bytes = MessagePackSerializer.Serialize(data);
        File.WriteAllBytes(savePath,bytes);
    }
    public void LoadAll() 
    {
        if (File.Exists(savePath))
        {
            byte[] bytes = File.ReadAllBytes(savePath);
            Game_SaveData data = MessagePackSerializer.Deserialize<Game_SaveData>(bytes);

            //Load Items


            //Load heroes
            foreach (Hero_SaveData heroData in data.heroSaveList)
            {
                //spawnheroes pass data container into method
            }
        }
        else 
        {
            Debug.Log("SaveFile not found in" + savePath);
        }
    }


}
