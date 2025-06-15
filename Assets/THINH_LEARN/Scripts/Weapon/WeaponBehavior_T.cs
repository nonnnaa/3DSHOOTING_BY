using UnityEngine;

public class WeaponBehavior_T : MonoBehaviour, IWeapon_T
{
    public virtual void OnSetUp()
    {
        
    }
}

public interface IWeapon_T
{
    void OnSetUp();
}
