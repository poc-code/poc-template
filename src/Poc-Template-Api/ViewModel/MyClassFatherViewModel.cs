namespace Poc_Template_Api.ViewModel
{
    public class MyClassFatherViewModel
    {
        public MyClassFatherViewModel(int id, string nome, MyClassChildViewModel child)
        {
            Id = id;
            Nome = nome;
            Child = child;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public MyClassChildViewModel Child { get; set; }
    }

    public class MyClassChildViewModel
    {
        public MyClassChildViewModel(int id, string surname, int age)
        {
            Id = id;
            Surname = surname;
            Age = age;
        }

        public int Id { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
    }
}
