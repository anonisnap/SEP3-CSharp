using System;
using System.Threading.Tasks;
using DataBaseAccess.DataAccess.DbContextImpl;
using DataBaseAccess.DataRepos;
using DataBaseAccess.DataRepos.Impl;
using Entities.Models;
using NUnit.Framework;

namespace RepoTest
{
    public class TestItemDataRepo
    {
        //https://docs.nunit.org/articles/nunit/writing-tests/setup-teardown/index.html
        //https://www.thereformedprogrammer.net/using-in-memory-databases-for-unit-testing-ef-core-applications/

        private IItemDataRepo _dataRepo;
        private Item _item = new();

        [SetUp]
        public void Setup()
        {
            Console.WriteLine("SetUp");
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
        
        
        [Test]
        public async Task RemoveItemAsync()
        {
            Item item = await _dataRepo.AddAsync(_item);
            
            var removeResult=  await _dataRepo.RemoveAsync(item.Id);

            var getRemoved = await _dataRepo.GetAsync(item.Id);
            
            Assert.Null(getRemoved);
            Assert.NotNull(removeResult);
        }
    }
}