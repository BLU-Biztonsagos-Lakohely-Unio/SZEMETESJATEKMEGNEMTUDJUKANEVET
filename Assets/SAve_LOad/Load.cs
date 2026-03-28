using UnityEngine;
using System.IO;
using PS;

public class Load : MonoBehaviour
{
    string FilePath = "./Assets/SAve_LOad";
    string FileName = "savefile.txt";

    public void LoadData()
    {
        LoadPosition();
        LoadStat();
    }

    private void LoadPosition()
    {
        Transform player = GameObject.FindWithTag("Player").transform;
        string[] lines = File.ReadAllLines(Path.Combine(FilePath, FileName));
        if (lines.Length >= 3)
        {
            float x = float.Parse(lines[0]);
            float y = float.Parse(lines[1]);
            float z = float.Parse(lines[2]);
            player.position = new Vector3(x, y, z);
        }
    }

    private void LoadStat()
    {
        var player = GameObject.FindWithTag("Player").GetComponent<PALYERSTAT>();
        string[] lines = File.ReadAllLines(Path.Combine(FilePath, FileName));
        
            player.HP = int.Parse(lines[3]);
            player.Stamina = int.Parse(lines[4]);
            PALYERSTAT.MaxHp = int.Parse(lines[5]);
            PALYERSTAT.MaxStamina = int.Parse(lines[6]);
        
    }
}
