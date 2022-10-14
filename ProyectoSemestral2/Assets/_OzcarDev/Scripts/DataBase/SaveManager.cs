using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
public static class SaveManager 
{
	public static void SavePlayerData(Move player)
    {
	    PlayerData playerData = new PlayerData(player);
        string dataPath = Application.persistentDataPath + "/game.save";
        FileStream fileStream = new FileStream(dataPath, FileMode.Create);
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        binaryFormatter.Serialize(fileStream, playerData);
        fileStream.Close();
    }

    public static PlayerData LoadPlayerData()
	{
		if (!(Directory.Exists(Application.persistentDataPath + "/fotos")))
		{
			Directory.CreateDirectory(Application.persistentDataPath + "/fotos");
			Debug.Log("Crear carpeta");
		}
		
	
        string dataPath = Application.persistentDataPath + "/game.save";

        if (File.Exists(dataPath))
        {
            FileStream fileStream = new FileStream(dataPath, FileMode.Open);
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            PlayerData playerData = (PlayerData) binaryFormatter.Deserialize(fileStream);
            fileStream.Close();
            return playerData;
        }
        else
        {
	        Debug.Log("No hay datos guardados");
	       

            return null;
        }
    }

    public static void DeletePlayerData()
    {
	    System.IO.File.Delete(Application.persistentDataPath + "/game.save");
	    Directory.Delete(Application.persistentDataPath+"/fotos");
    }
}

