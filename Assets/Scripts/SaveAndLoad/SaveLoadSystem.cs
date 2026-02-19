using UnityEngine;
using System.IO;
using MessagePack;

public class SaveLoadSystem : Singleton<SaveLoadSystem>
{
    public static new SaveLoadSystem instance => Singleton<SaveLoadSystem>.instance;

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

        //save ID Data
        data.id_ManagerData = ID_Manager.instance.SaveID_Manager();

        //save heroes
        foreach (Hero hero in HeroManager.instance.heroList)
        {
            Hero_SaveData heroData = hero.SaveHero();
            data.heroSaveList.Add(heroData);
        }

        byte[] bytes = MessagePackSerializer.Serialize(data);
        File.WriteAllBytes(savePath,bytes);
        Debug.Log("save at " + savePath);
    }
    public void LoadAll() 
    {
        if (File.Exists(savePath))
        {
            byte[] bytes = File.ReadAllBytes(savePath);
            Game_SaveData data = MessagePackSerializer.Deserialize<Game_SaveData>(bytes);
            // Load oneOffs
            ID_Manager.instance.LoadID_Manager(data.id_ManagerData);

            //Load Items


            //Load heroes
            foreach (Hero_SaveData heroData in data.heroSaveList)
            {
                //spawnheroes pass data container into method
                Hero hero = UnitSpawner.instance.ReturnHeroForLoad();
                hero.LoadHero(heroData);
            }
        }
        else 
        {
            Debug.Log("SaveFile not found in" + savePath);
        }
    }


}
