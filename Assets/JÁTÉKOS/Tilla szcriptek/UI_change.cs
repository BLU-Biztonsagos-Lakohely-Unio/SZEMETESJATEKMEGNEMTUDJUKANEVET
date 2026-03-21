using TMPro;
using UnityEngine;
using PS;
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
        UpdateHp(stat.HP);
        UpdateSt(stat.Stamina);
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
        St.text = $" ST :\t {stat.Stamina}";
    }
    
}
