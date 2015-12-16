using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGArmeni.Interfaces
{
    public interface IContainer
    {
        int NumberOfSlots { get; }

        IEnumerable<ICommonSlot> Slots { get; }

        void AddItem(IGameItem itemToBeAdded);

        void RemoveItem(IGameItem itemToBeRemoved);

        void ListItems();
    }
}
