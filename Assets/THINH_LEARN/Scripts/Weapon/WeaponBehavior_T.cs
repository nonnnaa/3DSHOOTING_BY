using UnityEngine;

public class WeaponBehavior_T : MonoBehaviour, IWeapon_T
{
    public virtual void OnHide()
    {
        gameObject.SetActive(false);
    }

    public virtual void OnSetUp()
    {
        
    }

    public virtual void OnShow(DataBinding dataBingding)
    {
        
    }
}

public interface IWeapon_T
{
    void OnSetUp();
    void OnHide();
    void OnShow(DataBinding dataBingding);
}
