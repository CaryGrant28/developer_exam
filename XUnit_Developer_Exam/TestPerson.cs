using Developer_Exam.Controllers;
using Developer_Exam.ModelExtensions;
using Developer_Exam.Models;
using Developer_Exam.Services;
using Xunit;


namespace XUnit_Developer_Exam
{
    public class UnitTest1 
    {
        PersonController _personController;

        public UnitTest1(PersonController personController)
        {
            _personController = personController;
        }

        [Fact]
        public void Create()
        {

            Person p = new()
            {
                Id = 0,
                FirstName = "Cary",
                MiddleName = "",
                LastName = "Grant"
            };

            Assert.Equal("1", _personController.Create(p).ToString());
        }
    }
}