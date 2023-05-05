using Autofac.Extras.Moq;
using CaseStudyService.Interface;
using CaseStudyService.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using UPSCaseStudy;
using Xunit;

namespace CaseStudyTest{
    
    [TestClass]
    public class EmployeeTest
    {        
        [TestMethod]
        public void SaveEmployeeTest()
        {
            using (var mock = AutoMock.GetLoose())
            {
                var emp = new Employee
                {
                    id = 1400565,
                    name = "Shubhhh Garg",
                    email = "Shubhhh@Garg.com",
                    gender = "male",
                    status = "active"
                };
                mock.Mock<IEmployeeService>().Setup(x => x.SaveEmployee(emp)).Returns("200");
                var clss = mock.Create<MainWindow>();
                clss.SaveEmployee(emp);
                mock.Mock<IEmployeeService>().Verify(x => x.SaveEmployee(emp), Times.Exactly(1));
            }
        }

        [TestMethod]
        public void UpdateEmployeeTest()
        {
            using (var mock = AutoMock.GetLoose())
            {
                var emp = new Employee
                {
                    id = 1400565,
                    name = "Shubh1 Garg1",
                    email = "Shubha1@Garg1.com",
                    gender = "male",
                    status = "active"
                };
                mock.Mock<IEmployeeService>().Setup(x => x.UpdateEmployee(emp)).Returns("200");
                var clss = mock.Create<MainWindow>();
                clss.UpdateEmployee(emp);
                mock.Mock<IEmployeeService>().Verify(x => x.UpdateEmployee(emp), Times.Exactly(1));
                //Assert.AreEqual(expected, actual);
                
            }
        }
    }
}
