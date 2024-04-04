
/// <summary>
/// Weapon factory class for futuristic weapons.
/// </summary>
public class WeaponFactoryFuture : IWeaponFactory
{
    public IWeapon Create(WeaponType type)
    {
        // You can do better than that...
        if (type == WeaponType.Magic)
        {
            return new VacuumEnergyChanneler();
        }

        if (type == WeaponType.Ranged) 
        {
            return new Phaser();
        }

        if (type == WeaponType.Melee)
        {
            return new TazerKnuckles();
        }

        throw new ArgumentException();
    }
}
