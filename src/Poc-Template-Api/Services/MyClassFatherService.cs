using Poc_Template_Api.Services.Interface;
using Poc_Template_Api.ViewModel;
using System.Collections.Generic;
using System.Linq;

namespace Poc_Template_Api.Services
{
    public class MyClassFatherService : IMyClassFatherService
    {
        private List<MyClassFatherViewModel> _listObject;

        public MyClassFatherService()
        {
            _listObject = new List<MyClassFatherViewModel>
            {
                new MyClassFatherViewModel(1, "John", new MyClassChildViewModel(1,"Doe",18)),
                new MyClassFatherViewModel(2, "Mary", new MyClassChildViewModel(2,"Stwart",20))
            };
        }

        public MyClassFatherViewModel GetById(int id)
        {
            return _listObject.FirstOrDefault(x => x.Id == id);
        }

        public List<MyClassFatherViewModel> GetAll()
        {
            return _listObject;
        }

        public MyClassFatherViewModel Add(MyClassFatherViewModel model)
        {
            var id = _listObject.Select(x => x.Id).Max() + 1;
            List<MyClassChildViewModel> child = new();

            _listObject.ForEach(x =>
            {
                child.Add(x.Child);
            });
            model.Id = id;
            model.Child.Id = child.Select(x => x.Id).Max() + 1;
            _listObject.Add(model);

            return model;
        }
    }
}
