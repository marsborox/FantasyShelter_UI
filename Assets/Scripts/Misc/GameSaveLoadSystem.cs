using UnityEngine;
using System.IO;//we use this if we want to communicate with files on system
using System.Runtime.Serialization.Formatters.Binary;//able to acess binary formatter

// he used public static class GameSaveLoad
public class GameSaveLoadSystem : Singleton<GameSaveLoadSystem>
{
    public static new GameSaveLoadSystem instance => Singleton<GameSaveLoadSystem>.instance;


    private void Awake()
    {
        base.Awake();
    }
    //he used public static void SaveObject
    public  void SaveObject(TestSaveObject saveObject)
    { 
        BinaryFormatter formatter = new BinaryFormatter();
        //where to save - lcoation of file
        //string path = "C:/System/";// this would save to system

        //will use data directory on OS thats not going to change??
        // + subfile - where exactly its going to be saved
        //since its binary we can use whaever filetype we want (.fun .save .whateverthefuck)
        string path = Application.persistentDataPath + "/saveObject.fun";
        //create file - we will use sort of datastream - stream of data flwoing into / from file
        FileStream stream = new FileStream(path, FileMode.Create);

        //we create data file and push object into constructor
        GameSaveData data = new GameSaveData(saveObject);

        formatter.Serialize(stream, data);
        //if flow of data has ended clsoe file
        stream.Close();

    }
    //he used public static GameSaveData
    public  GameSaveData LoadObject()
    {
        string path = Application.persistentDataPath + "/saveObject.fun";
        if (File.Exists(path))
        {//kinda same thing in kinda reversed order
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);


            GameSaveData data = formatter.Deserialize(stream) as GameSaveData;
            Debug.Log("Load File Finished");
            //stream msut be closed or we get errors
            stream.Close();

            return data;
        }
        else 
        {
            Debug.Log("SaveFile not found in" + path);
            return null;
        }
    }
}
