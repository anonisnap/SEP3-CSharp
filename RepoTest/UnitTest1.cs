using System;
using System.Collections;
using System.Threading.Tasks;
using DataBaseAccess;
using DataBaseAccess.DataAccess.DbContextImpl;
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

        private IItemDataRepo _dataRepo;
        private Item _item = new();

        [SetUp]
        public void Setup()
        {
            _dataRepo = new ItemDataRepo(new TestDbContext());
            _item.ItemName = "TestItemTest";
            _item.Length = 6;
            _item.Width = 7;
            _item.Height = 8;
            _item.Weight = 9;
        }

        [SetUpAttribute]
        public void AttributeSetup()
        {
        }

        [TearDownAttribute]
        public void AttributeTearDown()
        {
            
        }

        [Test]
        public async Task AddItemToDb()
        {
            
            Item item = await _dataRepo.AddAsync(_item);
            Assert.NotNull(item);
            Assert.AreEqual(_item,item);
            
        }
    }
}