using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chaty.Repo
{
    public interface GeneralInterface<T>
    {
        List<T> GetAllData();
        void AddNewItem(T NewItem);
        void EditItem(T NewItem , int OldItemId);
        void DeleteItem(int ItemIndex);
    }
}
