using UnityEditor.Experimental.RestService;

namespace MF
{
    public interface ISaveData
    {
        void SaveData(PlayerData _playerData);
        PlayerData Load();

    }
}

