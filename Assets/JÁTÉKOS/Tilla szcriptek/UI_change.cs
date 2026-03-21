using TMPro;
using UnityEngine;
using PS;

/// <summary>
/// Frissíti a HUD szöveges elemeit a PALYERSTAT eseményei alapján.
/// Ugyanarra a GameObject-re kell tenni, mint a PALYERSTAT.
/// </summary>
public class UI_Change : MonoBehaviour
{
    [Header("HUD szöveges elemek")]
    public TextMeshProUGUI hpSzoveg;
    public TextMeshProUGUI staminaSzoveg;
    //public TextMeshProUGUI ehsegSzoveg;
    //public TextMeshProUGUI szomjusagSzoveg;

    /*
    [Header("Halál képernyő")]
    [Tooltip("Egy GameObject aminek a Canvas/Panel a halál képernyő – Start()-ban kikapcsoljuk.")]
    public GameObject halalKepernyo;
    */
    private PALYERSTAT stat;

    void Start()
    {
        stat = GetComponent<PALYERSTAT>();

        // Feliratkozás eseményekre
        stat.OnHPChanged += FrissitHP;
        stat.OnStaminaChanged += FrissitStamina;
        //stat.OnHungerChanged += FrissitEhseg;
        //stat.OnThirstChanged += FrissitSzomjusag;
        //stat.OnDeath += MutatHalalKepernyo;

        /*
        //Halál képernyő alapból rejtett
        if (halalKepernyo != null)
            halalKepernyo.SetActive(false);
        */
        // Kezdeti értékek kiírása
        FrissitHP(stat.HP);
        FrissitStamina(stat.Stamina);
        //FrissitEhseg(stat.Hunger);
        //FrissitSzomjusag(stat.Thirst);
    }

    void OnDestroy()
    {
        if (stat == null) return;
        stat.OnHPChanged -= FrissitHP;
        stat.OnStaminaChanged -= FrissitStamina;
        //stat.OnHungerChanged -= FrissitEhseg;
        //stat.OnThirstChanged -= FrissitSzomjusag;
        //stat.OnDeath -= MutatHalalKepernyo;
    }

    // ── Frissítő metódusok ────────────────────────────────────────

    private void FrissitHP(int hp)
    {
        if (hpSzoveg != null)
            hpSzoveg.text = $"HP:\t{hp} / {PALYERSTAT.MaxHp}";
    }

    private void FrissitStamina(int stamina)
    {
        if (staminaSzoveg != null)
            staminaSzoveg.text = $"ST:\t{stamina} / {PALYERSTAT.MaxStamina}";
    }

    //private void FrissitEhseg(int hunger)
    //{
    //    if (ehsegSzoveg != null)
    //        ehsegSzoveg.text = $"Éhség:\t{hunger} / {PALYERSTAT.MaxHunger}";
    //}

    //private void FrissitSzomjusag(int thirst)
    //{
    //    if (szomjusagSzoveg != null)
    //        szomjusagSzoveg.text = $"Szomj:\t{thirst} / {PALYERSTAT.MaxThirst}";
    //}

    //private void MutatHalalKepernyo()
    //{
    //    if (halalKepernyo != null)
    //        halalKepernyo.SetActive(true);
    //}
}