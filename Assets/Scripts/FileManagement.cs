using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class FileManagement
{
    public string username;
    public string isMuted;
    UsernameInput input;

    public static void SaveUsername(string username){
        string path = Application.persistentDataPath + "/username.it";
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(path, FileMode.Create);

        formatter.Serialize(stream, username);
        stream.Close();
    }

    public static string LoadUsername(){
        string path = Application.persistentDataPath + "/username.it";
        if(File.Exists(path)){
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            string username = formatter.Deserialize(stream) as string;

            stream.Close();

            return username;            
        }
        else{
            Debug.Log("File not found in " + path);
            return null;
        }
    }

     public static void SaveVolume(string isMuted){
        string path = Application.persistentDataPath + "/volume.vt";
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(path, FileMode.Create);

        formatter.Serialize(stream, isMuted);
        stream.Close();
    }

     public static string LoadVolume(){
        string path = Application.persistentDataPath + "/volume.vt";
        if(File.Exists(path)){
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            string isMuted = formatter.Deserialize(stream) as string;

            stream.Close();

            return isMuted;            
        }
        else{
            Debug.Log("File not found in " + path);
            return null;
        }
    }

}
