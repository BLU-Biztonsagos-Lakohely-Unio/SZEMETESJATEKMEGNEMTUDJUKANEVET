using System.IO;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.Rendering.UI;
using System.IO;
using PS;

public class Save : MonoBehaviour
{
    string FilePath = "./Assets/SAve_LOad"; 
    string FileName = "savefile.txt";

    public void SaveData()
    {
        File.Delete(Path.Combine(FilePath, FileName));
        SavePosition();
        SaveStat();
    }

    private void SavePosition()
    {
        Transform player = GameObject.FindWithTag("Player").transform;

        Debug.Log("Saving position: " + FilePath + FileName);
        
        

        using (StreamWriter FileN = new StreamWriter(Path.Combine(FilePath, FileName), true))
        {
            FileN.WriteLine(player.position.x);
            FileN.WriteLine(player.position.y);
            FileN.WriteLine(player.position.z);
        }
    }

    private void SaveStat()
    {
        var player = GameObject.FindWithTag("Player").GetComponent<PALYERSTAT>();
        using (StreamWriter FileN = new StreamWriter(Path.Combine(FilePath, FileName), true))
        {
            FileN.WriteLine(player.HP);
            FileN.WriteLine(player.Stamina);
            FileN.WriteLine(player.maxhp);
            FileN.WriteLine(player.maxstamina);
        }
    }
}
