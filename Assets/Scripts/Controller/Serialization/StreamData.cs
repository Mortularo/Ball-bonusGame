using System;
using System.Collections.Generic;
using MF;
using System.IO;
using UnityEngine;

namespace MF
{
    public class StreamData : ISaveData
    {
        string SavePath = Path.Combine(Application.dataPath, "STREAMData.xyz");

        public void SaveData(PlayerData player)
        {
            using (StreamWriter sw = new StreamWriter(SavePath))
            {
                //sw.WriteLine(player.Name);
                //sw.WriteLine(player.Position);
                //sw.WriteLine(player.Rotation);
                sw.WriteLine(player.Health);
                sw.WriteLine(player.PlayerDead);
            }
        }
        public PlayerData Load()
        {
            PlayerData result = new PlayerData();
            if (!File.Exists(SavePath))
            {
                Debug.Log("NO saved Data");
                return result;
            }
            using(StreamReader sr = new StreamReader(SavePath))
            {
                //result.Name = sr.ReadLine();
                result.Health = Convert.ToInt32(sr.ReadLine());
                result.PlayerDead = Convert.ToBoolean(sr.ReadLine());

            }
            return result;
        }
    }
}


