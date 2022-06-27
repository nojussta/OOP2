using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Lab2.Tests
{
    [TestClass()]
    public class NodeTests
    {
        [TestMethod]
        public void AddingAFirstElementToAlistCheckingIfFirstElementIsTheSame()
        {
            LinkedList<Publications> list = new LinkedList<Publications>();
            Publications p = new Publications("124", "Aurimas", 8);
            Publications p1 = new Publications("156", "Aurimukas", 4);
            list.Add(p);
            list.Add(p1);
            list.Start();
            Assert.AreEqual(p, list.TakeData());
        }

        [TestMethod]
        public void AddingALastElementToAlistCheckingIfFirstElementIsTheSame()
        {
            LinkedList<Publications> list = new LinkedList<Publications>();
            Publications p = new Publications("666", "Tomas", 6);
            Publications p1 = new Publications("777", "Tomukas", 3);
            list.SetLifo(p);
            list.SetLifo(p1);
            list.Start();
            Assert.AreEqual(p1, list.TakeData());
        }

        [TestMethod]
        public void AddingAFirstElementToAlistCheckingIfFirstElementIsTheSame1()
        {
            LinkedList<Subscribers> list = new LinkedList<Subscribers>();
            Subscribers p = new Subscribers("Eitvidas", "Vyduno al. 19", 2, 3, "254", 3);
            Subscribers p1 = new Subscribers("Stasiunas", "Technikos g. 10", 6, 9, "147", 8);
            list.Add(p);
            list.Add(p1);
            list.Start();
            Assert.AreEqual(p, list.TakeData());
        }

        [TestMethod]
        public void AddingALastElementToAlistCheckingIfFirstElementIsTheSame2()
        {
            LinkedList<Subscribers> list = new LinkedList<Subscribers>();
            Subscribers p = new Subscribers("Petrauskas", "Traku g. 20A", 2, 3, "254", 3);
            Subscribers p1 = new Subscribers("Ozelis", "Studentu g. 47", 6, 9, "147", 8);
            list.SetLifo(p);
            list.SetLifo(p1);
            list.Start();
            Assert.AreEqual(p1, list.TakeData());
        }

        [TestMethod]
        public void EmptyListSortIsNull()
        {
            LinkedList<Publications> list = new LinkedList<Publications>();
            list.Start();
            list.Sort();
            Assert.IsFalse(list == null);
        }

        [TestMethod]
        public void EmptyListSortIsNotNull()
        {
            LinkedList<Publications> list = new LinkedList<Publications>();
            Publications p = new Publications("651", "Genijus", 9);
            list.Add(p);
            list.Start();
            list.Sort();
            Assert.IsTrue(list != null);
        }

        [TestMethod]
        public void CheckingIfListIsSorted()
        {
            LinkedList<Publications> list = new LinkedList<Publications>();
            Publications p = new Publications("651", "Genijus", 9);
            Publications p1 = new Publications("328", "Augenijus", 2);
            list.Add(p);
            list.Add(p1);
            list.Sort();
            list.Start();
            Assert.AreEqual(p1, list.TakeData());
        }

        [TestMethod]
        public void CheckingIfListIsSorted2()
        {
            LinkedList<Publications> list = new LinkedList<Publications>();
            Publications p = new Publications("651", "Genijus", 9);
            Publications p1 = new Publications("328", "Augenijus", 2);
            Publications p2 = new Publications("666", "ATest1", 6);
            Publications p3 = new Publications("777", "BTest2", 7);
            Publications p4 = new Publications("0", "AAtest1", 3);
            Publications p5 = new Publications("998", "Tomas", 1);
            list.Add(p);
            list.Add(p1);
            list.Add(p2);
            list.Add(p3);
            list.Add(p4);
            list.Add(p5);
            list.Start();
            list.Sort();
            Assert.AreEqual(p4, list.TakeData());
        }

        [TestMethod]
        public void EmptyLinkedListBegin()
        {
            LinkedList<Subscribers> emptyList = new LinkedList<Subscribers>();
            LinkedList<Subscribers> objList = new LinkedList<Subscribers>();
            Subscribers obj = new Subscribers("Petrauskas", "Traku g. 20A", 2, 3, "254", 3);
            objList.Add(obj);
            emptyList.Start();
            objList.Start();
            Assert.AreNotSame(emptyList, objList);
        }

        [TestMethod]
        public void LinkedListNext()
        {
            LinkedList<Subscribers> objList = new LinkedList<Subscribers>();
            Subscribers obj1 = new Subscribers("Petrauskas", "Traku g. 20A", 2, 3, "254", 3);
            Subscribers obj2 = new Subscribers("Ozelis", "Studentu g. 47", 6, 9, "147", 8);
            objList.Add(obj1);
            objList.Add(obj2);
            objList.Start();
            objList.Next();
            ReferenceEquals(obj1, obj2);
        }

        [TestMethod]
        public void LinkedListExistCheckIfElementExists1()
        {
            LinkedList<Subscribers> objList = new LinkedList<Subscribers>();
            Subscribers obj1 = new Subscribers("Petrauskas", "Traku g. 20A", 2, 3, "254", 3);
            objList.Add(obj1);
            objList.Start();
            Assert.AreEqual(objList.Exist(), true);
        }

        [TestMethod]
        public void LinkedListExistCheckIfElementExists2()
        {
            LinkedList<Publications> list = new LinkedList<Publications>();
            list.Start();
            Assert.AreEqual(list.Exist(), false);
        }

        [TestMethod]
        public void CalculateValueDoesNotContainItemsFromOtherList()
        {
            LinkedList<Publications> list1 = new LinkedList<Publications>();
            InOutUtils.ReadLifo1(list1, @"C:\Users\Lenovo\source\repos\Lab2\Lab2\App_Data\U3a.txt");
            LinkedList<Subscribers> list2 = new LinkedList<Subscribers>();
            InOutUtils.ReadLifo2(list2, @"C:\Users\Lenovo\source\repos\Lab2\Lab2\App_Data\U3b.txt");
            List<string> firstList = TaskUtils.MonthlyIncomeMax(list2, list1, @"C:\Users\Lenovo\source\repos\Lab2\Lab2\App_Data\Rezultatai.txt");
            CollectionAssert.DoesNotContain(firstList, list2);
        }
    }
}