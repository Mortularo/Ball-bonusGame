using UnityEngine.Analytics;
using UnityEngine;
using System.IO; 

namespace MF
{
    public class JSONData : ISaveData
    {
        string SavePath = Path.Combine(Application.dataPath, "JSONData.json");

        public void SaveData(PlayerData player)
        {
            string FileJson = JsonUtility.ToJson(player);
            File.WriteAllText(SavePath, FileJson);
        }
        public PlayerData Load()
        {
            PlayerData result = new PlayerData();
            if (!File.Exists(SavePath))
            {
                Debug.Log("NO saved Data");
                return result;
            }
            string json = File.ReadAllText(SavePath);
            result = JsonUtility.FromJson<PlayerData>(json);
            
            return result;
        }
    }
}

