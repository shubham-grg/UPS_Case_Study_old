using System;
using System.Windows;
using System.Windows.Data;
using CaseStudyService.Interface;
using Newtonsoft.Json;
using CaseStudyService.Model;

namespace UPSCaseStudy
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IEmployeeService _service;
        public MainWindow(IEmployeeService service)
        {           
            _service = service;
            InitializeComponent();
        }
        private void LoadEmployees(object sender, RoutedEventArgs e)
        {
            GetEmployees();
        }
        private void GetEmployees()
        {
            var response = _service.GetEmployees();
            if (response.Result != null)
            {
                wrapperEmployee employees = JsonConvert.DeserializeObject<wrapperEmployee>(response.Result.ToString());
                dgEmployee.DataContext = employees.data;
            }
        }
       
        public void SaveEmployee(Employee employee)
        {
            string messageBoxText = "", caption = "";
            try
            {
                var res = _service.SaveEmployee(employee);
                if (res == "200")
                {
                    messageBoxText = "User added successfully";
                    caption = "Message";
                }                
            }
            catch(Exception ex)
            {
                messageBoxText = "Please try again after sometime.";
                caption = "Message";
            }
            finally
            {                
                MessageBox.Show(messageBoxText, caption);
            }
        }
        public void UpdateEmployee(Employee emp)
        {

            string messageBoxText = "", caption = "";
            try
            {
                var res = _service.UpdateEmployee(emp);
                if (res == "200")
                {
                    messageBoxText = "User deatils Modified successfully";
                    caption = "Message";
                }
            }
            catch (Exception ex)
            {
                messageBoxText = "Please try again after sometime.";
                caption = "Message";
            }
            finally
            {
                GetEmployees();                
                MessageBox.Show(messageBoxText, caption);
            }            
        }
        private void DeleteEmployee(int empid)
        {
            var response = _service.DeleteEmployee(empid);
            string messageBoxText = "User removed successfully";
            string caption = "Message";
            MessageBox.Show(messageBoxText, caption);
            GetEmployees();
        }
        private void SaveEmployeeDetails(object sender, RoutedEventArgs e)
        {
            var employee = new Employee()
            {
                id = Convert.ToInt32(txtEmployeeId.Text),
                name = txtName.Text.ToString(),
                email = txtEmail.Text.ToString(),
                gender = txtGender.Text.ToString(),
                status = txtStatus.Text.ToString()
            };
            if (employee.id == 0)
            {
                SaveEmployee(employee);
                GetEmployees();
            }
            else
            {
                UpdateEmployee(employee);
                GetEmployees();
            }
            txtEmployeeId.Text = 0.ToString();
            txtName.Text = "";
            txtEmail.Text = "";
            txtGender.Text = "";
            txtStatus.Text = "";
            GetEmployees();
        }
        private void EditEmployeeDetails(object sender, RoutedEventArgs e)
        {
            Employee employee = ((FrameworkElement)sender).DataContext as Employee;
            txtEmployeeId.Text = employee.id.ToString();
            txtName.Text = employee.name;
            txtEmail.Text = employee.email;
            txtGender.Text = employee.gender;
            txtStatus.Text = employee.status;
        }
        void DeleteEmployeeDetails(object sender, RoutedEventArgs e)
        {
            Employee employee = ((FrameworkElement)sender).DataContext as Employee;
            this.DeleteEmployee(employee.id);
            GetEmployees();
            
        }

    }
}
