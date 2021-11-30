using System;
using System.Collections;
using System.Threading.Tasks;
using DataBaseAccess.DataRepos;
using DataBaseAccess.DataRepos.Impl;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using WebDBserverAPI.Controllers;

namespace RepoTest
{
    public class Tests
    {
        //https://docs.nunit.org/articles/nunit/writing-tests/setup-teardown/index.html
        //https://www.thereformedprogrammer.net/using-in-memory-databases-for-unit-testing-ef-core-applications/
        
        private IDataRepo<Item> _dataRepo;

        [SetUp]
        public void Setup()
        {
            _dataRepo = new ItemDataRepo();
        }

        [SetUpAttribute]
        public void AttributeSetup()
        {
            Item item = new();
        }

        [TearDownAttribute]
        public void AttributeTearDown()
        {
            
        }

        [Test]
        public void Test1()
        {
            Item item = new();
            item.Id = 5;
            item.ItemName = "TestItemTest";
            item.Length = 6;
            item.Width = 7;
            item.Height = 8;
            item.Weight = 9;

            Console.WriteLine(_dataRepo.Add(item));
            //Assert.AreEqual();
            //Assert.Pass();
        }
    }
}