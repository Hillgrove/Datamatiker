
/// <summary>
/// Weapon factory class for medieval weapons.
/// </summary>
public class WeaponFactoryMedieval : IWeaponFactory
{
    public IWeapon Create(WeaponType type)
    {
        // You can do better than that...
        if (type == WeaponType.Magic)
        {
            return new Wand();
        }

        if (type == WeaponType.Ranged)
        {
            return new CrossBow();
        }

        if (type == WeaponType.Melee)
        {
            return new Dagger();
        }

        throw new ArgumentException();

    }
}
