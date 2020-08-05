using System.Collections;
using UnityEngine;

public class HelicopterRescueController : MonoBehaviour
{
    public event System.Action OnHumanLoaded;
    public event System.Action OnHumanUnloaded;

    [Tooltip("How many humans can helicopter fit.")]
    [SerializeField] private int _helicopterCapacity;

    public int HumansInHelicopter { get; private set; }
    public int HelicopterCapacity => _helicopterCapacity;

    public void LoadHuman(HumanController human)
    {
        if (HumansInHelicopter == _helicopterCapacity)
            return;

        human.GrabRope();
        HumansInHelicopter++;
        OnHumanLoaded();
    }

    public int UnloadHumans()
    {
        int humansToGive = HumansInHelicopter;
        HumansInHelicopter = 0;
        OnHumanUnloaded();
        return humansToGive;
    }
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<HumanController>(out var humanController))
            LoadHuman(humanController);
    }
}
