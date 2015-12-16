namespace RPGArmeni.Interfaces
{
    using System;
    using Models.Items.ArmorItems;

    public interface IArmor
    {
        int DefenceBonus { get; }

        public ArmorType ArmorType { get; }
    }
}
