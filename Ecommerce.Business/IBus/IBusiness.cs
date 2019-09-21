using Ecommerce.Common.Struct;
using Ecommerce.ViewModel;
using System.Collections.Generic;

namespace Ecommerce.Business.IBus
{
    public interface IBusiness<TEdit, TDisplay> where TEdit : BaseViewModel where TDisplay : BaseViewModel
    {
        TEdit InitInsert();
        TEdit InitUpdate(int id);
        TEdit InitDelete(int id);
        ResultHandle Insert(TEdit viewModel);
        ResultHandle Update(TEdit viewModel);
        ResultHandle Delete(int id);
        List<TDisplay> DisplayAll();
        List<TEdit> GetAll();
        TEdit GetById(int id);
    }
}
