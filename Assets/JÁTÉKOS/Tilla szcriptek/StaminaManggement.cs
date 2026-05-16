using System.Collections;
using UnityEngine;
using PS;

/// <summary>
/// Kezeli a stamina, éhség és szomjúság fogyását, regenerációját,
/// valamint a sebesség módosítását ezek alapján.
/// Ugyanarra a GameObject-re kell tenni, mint a PALYERSTAT és MOZGAS1.
/// </summary>
public class StaminaManagement : MonoBehaviour
{
    [Header("Éhség / Szomjúság beállítások")]
    [Tooltip("Hány másodpercenként csökken 1-gyel az éhség.")]
    public float ehsegFogyasIntervallum = 10f;

    [Tooltip("Hány másodpercenként csökken 1-gyel a szomjúság.")]
    public float szomjusagFogyasIntervallum = 8f;

    [Tooltip("Ha éhség = 0, ennyi HP-t von le másodpercenként.")]
    public int ehsegDamage = 1;

    [Tooltip("Ha szomjúság = 0, ennyi HP-t von le másodpercenként.")]
    public int szomjusagDamage = 1;

    private PALYERSTAT stat;
    private MOZGAS1 mozog;

    private bool fut;
    private bool regenFut;
    private Coroutine regenCoroutine;

    void Start()
    {
        stat = GetComponent<PALYERSTAT>();
        mozog = GetComponent<MOZGAS1>();

        mozog.Ugras += UgrasStamina;

        // Stamina levonás futásnál
        InvokeRepeating(nameof(FutasStamina), 1f, 1f);

        // Éhség és szomjúság folyamatos csökkentése
        //InvokeRepeating(nameof(EhsegCsokkent), ehsegFogyasIntervallum, ehsegFogyasIntervallum);
        //InvokeRepeating(nameof(SzomjusagCsokkent), szomjusagFogyasIntervallum, szomjusagFogyasIntervallum);

        // HP-csökkentés ha éhes/szomjas – másodpercenként ellenőriz
        //InvokeRepeating(nameof(EhsegSzomjusagKar), 1f, 1f);
    }

    void Update()
    {
        if (stat.IsDead) return;

        fut = Input.GetKey(KeyCode.LeftShift);

        // Alapsebesség stamina alapján
        PALYERSTAT.gyorsasag = stat.Stamina >= 20 ? PALYERSTAT.MaxSeb : PALYERSTAT.MaxSeb/2;

        // Futás: kétszeres sebesség, csak ha van elég stamina
        
        if (fut && stat.Stamina > 0)
            PALYERSTAT.gyorsasag *= 2f;
        
    }

    // ── Stamina ───────────────────────────────────────────────────

    private void UgrasStamina()
    {
        stat.Stamina -= 10;
        StopRegen();
    }

    private void FutasStamina()
    {
        if (stat.IsDead) return;

        if (fut)
        {
            stat.Stamina -= 3;
            StopRegen();
        }
        else
        {
            if (!regenFut)
                StartRegen(delayMasodperc: 5f);
        }
    }

    // ── Éhség / Szomjúság ─────────────────────────────────────────

    private void EhsegCsokkent()
    {
        if (stat.IsDead) return;
        stat.Hunger -= 1;
    }

    private void SzomjusagCsokkent()
    {
        if (stat.IsDead) return;
        stat.Thirst -= 1;
    }

    /// <summary>
    /// Ha az éhség vagy szomjúság 0-ra csökkent, HP-t von le.
    /// </summary>
    private void EhsegSzomjusagKar()
    {
        if (stat.IsDead) return;

        if (stat.Hunger <= 0)
            stat.HP -= ehsegDamage;

        if (stat.Thirst <= 0)
            stat.HP -= szomjusagDamage;
    }

    // ── Regen kezelés ─────────────────────────────────────────────

    private void StartRegen(float delayMasodperc)
    {
        regenFut = true;
        regenCoroutine = StartCoroutine(StaminaRegen(delayMasodperc));
    }

    private void StopRegen()
    {
        if (regenCoroutine != null)
        {
            StopCoroutine(regenCoroutine);
            regenCoroutine = null;
        }
        regenFut = false;
    }

    private IEnumerator StaminaRegen(float delaySec)
    {
        yield return new WaitForSeconds(delaySec);

        while (!fut && stat.Stamina < PALYERSTAT.MaxStamina)
        {
            stat.Stamina += 1;
            yield return new WaitForSeconds(1f);
        }

        regenFut = false;
        regenCoroutine = null;
    }
}