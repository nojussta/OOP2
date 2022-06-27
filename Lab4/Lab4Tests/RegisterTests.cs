using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lab4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4.Tests
{
    [TestClass()]
    public class RegisterTests : System.Web.UI.Page
    {
        [TestMethod()]
        public void Test()
        {
        }

        [TestMethod()]
        public void RegisterTest()
        {
            Register allMembers = InOutUtils.ReadFile(@"C:\Users\Lenovo\source\repos\Lab4\Lab4\App_Data\A.txt");
            Assert.IsTrue(allMembers.StudyYear == 2021);
        }

        [TestMethod()]
        public void MemberTest()
        {
            Member member = new Member("Pavardenis", "Vardenis", new DateTime(2000 - 04 - 05), 864235441);
            Assert.AreEqual("Pavardenis", member.Surname);
            Assert.AreEqual("Vardenis", member.Name);
            Assert.AreEqual(new DateTime(2000 - 04 - 05), member.BirthDate);
            Assert.AreEqual(864235441, member.Contact);
        }

        [TestMethod()]
        public void MemberIsOld()
        {
            Member member = new Member("Pavardenis", "Vardenis", new DateTime(2003 - 04 - 05), 864235441);
            Assert.IsFalse(member.OldStudent(member));
        }

        [TestMethod()]
        public void GraduateTest()
        {
            Graduate graduate = new Graduate(2018, "Dirbu.lt", "Pavarde", "Vardas", new DateTime(1993 - 04 - 23), 865623444);
            Assert.AreEqual(2018, graduate.StartYear);
            Assert.AreEqual("Dirbu.lt", graduate.WorkPlace);
            Assert.AreEqual("Pavarde", graduate.Surname);
            Assert.AreEqual("Vardas", graduate.Name);
            Assert.AreEqual(new DateTime(1993 - 04 - 23), graduate.BirthDate);
            Assert.AreEqual(865623444, graduate.Contact);
        }

        [TestMethod()]
        public void GraduateIsOld()
        {
            Graduate graduate = new Graduate(2018, "Dirbu.lt", "Pavarde", "Vardas", new DateTime(1993 - 04 - 23), 865623444);
            Assert.IsTrue(graduate.OldStudent(graduate));
        }

        [TestMethod()]
        public void StudentTest()
        {
            Student student = new Student("E2315", 2019, "Pavarde", "Vardas", new DateTime(1999 - 12 - 25), 865623512);
            Assert.AreEqual("E2315", student.CodeID);
            Assert.AreEqual(2019, student.StartDate);
            Assert.AreEqual("Pavarde", student.Surname);
            Assert.AreEqual("Vardas", student.Name);
            Assert.AreEqual(new DateTime(1999 - 12 - 25), student.BirthDate);
            Assert.AreEqual(865623512, student.Contact);
        }

        [TestMethod()]
        public void StudentIsOld()
        {
            Student student = new Student("E2315", 2016, "Pavarde", "Vardas", new DateTime(1993 - 12 - 25), 865623512);
            Assert.IsTrue(student.OldStudent(student));
        }

        [TestMethod()]
        public void GetCurrentYearListTest()
        {
            Register allMembers1 = InOutUtils.ReadFile(@"C:\Users\Lenovo\source\repos\Lab4\Lab4\App_Data\A.txt");
            Register allMembers2 = InOutUtils.ReadFile(@"C:\Users\Lenovo\source\repos\Lab4\Lab4\App_Data\B.txt");
            int[] months = new int[12];
            string type1 = TaskUtils.BirthdaysToString(months, allMembers1);
            string type2 = TaskUtils.BirthdaysToString(months, allMembers2);
            Assert.AreNotSame(type1, type2);
        }

        [TestMethod()]
        public void GetBirthdays()
        {
            string test = "2021 : sausis vasaris birželis";
            Register allMembers = InOutUtils.ReadFile(@"C:\Users\Lenovo\source\repos\Lab4\Lab4\App_Data\A.txt");
            var data = TaskUtils.GetBirthdays(allMembers).TrimEnd();
            Assert.AreEqual(test, data);
        }
    }
}