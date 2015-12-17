namespace RPGArmeni.Interfaces
{
	using Models.Items.ArmorItems;

    public interface IArmor
    {
        int DefenceBonus { get; }

        ArmorType ArmorType { get; }
    }
}
