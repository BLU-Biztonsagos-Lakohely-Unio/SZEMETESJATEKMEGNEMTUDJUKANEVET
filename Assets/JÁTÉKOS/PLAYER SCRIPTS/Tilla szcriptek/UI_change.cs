using TMPro;
using UnityEngine;

public class UI_change : MonoBehaviour
{
    PALYERSTAT stat;
    Canvas canvas;
    public TextMeshProUGUI HP, St;
    void Start()
    {
        canvas = GetComponentInChildren<Canvas>();
        stat = GetComponent<PALYERSTAT>();
        stat.OnHPC += UpdateHp;
        stat.OnSTDC += UpdateSt;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void UpdateHp(int hp)
    {
        HP.text = $" HP :\t {stat.HP}";
    }
    void UpdateSt(int st)
    {
        St.text = $" Stamina :\t {stat.Stamina}";
    }
    
}
