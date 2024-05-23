using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WinFormsApp9
{
    public partial class Form1 : Form
    {
        private EmployeeViewModel _viewModel;

        public Form1()
        {
            InitializeComponent();
            _viewModel = new EmployeeViewModel();
            BindControls();
        }



        public class Employee
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public override string ToString()
            {
                return Name+"-"+Age;
            }
        }
        public class EmployeeViewModel : INotifyPropertyChanged
        {
            private string _name;
            private int _age;
            public BindingList<Employee> _employees;

            public event PropertyChangedEventHandler PropertyChanged;

            public EmployeeViewModel()
            {
                Employees = new BindingList<Employee>();
            }

            public string Name
            {
                get { return _name; }
                set
                {
                    if (_name != value)
                    {
                        _name = value;
                        OnPropertyChanged("Name");
                    }
                }
            }

            public int Age
            {
                get { return _age; }
                set
                {
                    if (_age != value)
                    {
                        _age = value;
                        OnPropertyChanged("Age");
                    }
                }
            }

            public BindingList<Employee> Employees
            {
                get { return _employees; }
                set
                {
                    if (_employees != value)
                    {
                        _employees = value;
                        OnPropertyChanged("Employees");
                    }
                }
            }

            protected void OnPropertyChanged(string propertyName)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }

            public void AddEmployee()
            {
                Employees.Add(new Employee { Name = this.Name, Age = this.Age });
            }
            
        }




      

        private void BindControls()
        {
            // Привязываем текстовые поля и кнопку
            textBox1.DataBindings.Add("Text", _viewModel, "Name", false, DataSourceUpdateMode.OnPropertyChanged);
           numericUpDown1.DataBindings.Add("Value", _viewModel, "Age", false, DataSourceUpdateMode.OnPropertyChanged);
            listBox1.DataSource = _viewModel.Employees;

            AddButton.Click += (s, e) => _viewModel.AddEmployee();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }






}





    








