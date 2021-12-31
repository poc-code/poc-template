using Poc_Template_Api.ViewModel;
using System.Collections.Generic;

namespace Poc_Template_Api.Services.Interface
{
    public interface IMyClassFatherService
    {
        MyClassFatherViewModel GetById(int id);
        List<MyClassFatherViewModel> GetAll();
        MyClassFatherViewModel Add(MyClassFatherViewModel model);
    }
}
