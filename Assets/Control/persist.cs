using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
public static class persist
{
    /*
     * Origional Method for saving data,
     * as the classes this was design to work with
     * are not longer in uses, this currently doesn't work.
     * 
     */

    

/*============================================+Save Character Funtion+=======================================*/
    public static void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");

        character data = GameManager.instance.gameModel.playerCharacter;

        bf.Serialize(file, data);
        file.Close();
    }
    /*============================================-Save Character Funtion-=======================================*/


    /*============================================+Load Character Funtion+=======================================*/
    public static void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
            character data = (character)bf.Deserialize(file);
            GameManager.instance.gameModel.playerCharacter = data;
            file.Close();

            //Health = data.health;
            // Experience = data.experience;
        }
    }
    /*============================================-Load Character Funtion-=======================================*/
}




