using System;
using System.Linq;
using System.Threading.Tasks;
using DataBaseAccess.DataAccess.DbContextImpl;
using DataBaseAccess.DataRepos.Impl;
using Entities.Models;
using NUnit.Framework;

namespace RepoTest
{
    public class TestItemLocationDataRepo
    {
        private ItemLocationDataRepo _itemLocationDataRepo;
        private Item _testItem1, _testItem2;
        private Location _testLocaiton;
        private Inventory _testInventory;
        private ItemDataRepo _itemDataRepo;
        private LocationDataRepo _locationDataRepo;

        [SetUp]
        public void Setup()
        {
            _itemLocationDataRepo = new ItemLocationDataRepo(new TestDbContext());
            _itemDataRepo = new ItemDataRepo(new TestDbContext());
            _locationDataRepo = new LocationDataRepo(new TestDbContext());
            
        }

        [SetUpAttribute]
        public void AttributeSetup()
        {
            Console.WriteLine("SetUp");
            
            _testItem1 = _itemDataRepo.GetAllAsync().Result.First();

            if (_testItem1 == null)
            {
                Item tempItem = new( ) { Id = 0, ItemName = "The Answer to Life, The Universe, and Everything", 
                    Height = 420, Length = 69, Width = 727, Weight = 15 };
                _testItem1 = _itemDataRepo.AddAsync(tempItem).Result;
            }

            _testLocaiton = _locationDataRepo.GetAllAsync().Result.First();
            
            if (_testLocaiton == null)
            {
                Location tempLocation =  new( ) { Id = 0, Description = "SandersTestLocation" };
                _testLocaiton = _locationDataRepo.AddAsync(tempLocation).Result;
            }
            
            _testInventory =  new();
            _testInventory.Amount = 10;
            _testInventory.Item = _testItem1;
            _testInventory.Location = _testLocaiton;
            
        }

        [TearDownAttribute]
        public void AttributeTearDown()
        {
            Console.WriteLine("TearDown");
            _itemLocationDataRepo.RemoveAsync(_testInventory.Id);
        }

        [Test]
        public async Task AddItemLocationToDb()
        {
            var result = await _itemLocationDataRepo.AddAsync(_testInventory);
            Assert.NotNull(result);
            Assert.AreEqual(_testInventory, result );
        }

        [Test]
        public async Task GetItemLocation()
        {
            await _itemLocationDataRepo.AddAsync(_testInventory);
            var result = await _itemLocationDataRepo.GetAsync(_testInventory.Id);
            Assert.NotNull(result);
            Assert.AreEqual(_testInventory, result);
        }
        

        [Test]
        public async Task RemoveItemLocation()
        {
            await _itemLocationDataRepo.AddAsync(_testInventory);
            var result =await _itemLocationDataRepo.RemoveAsync(_testInventory.Id);
            Assert.NotNull(result);
            Assert.AreEqual(_testInventory, result);
        }

        [Test]
        public void UpdateItemLocation()
        {      
            _itemLocationDataRepo.AddAsync(_testInventory);
            _testInventory.Amount = 100;
            var result = _itemLocationDataRepo.UpdateAsync(_testInventory).Result;
            Assert.AreEqual(_testInventory.Id, result.Id);
            Assert.NotNull(result);
            Assert.AreEqual(100, result.Amount);
        }
        
    }
}