using System;
using System.Linq;
using System.Threading.Tasks;
using DataBaseAccess.DataAccess.DbContextImpl;
using DataBaseAccess.DataRepos.Impl;
using Entities.Models;
using NUnit.Framework;

namespace RepoTest
{
    public class TestInventoryDataRepo
    {
        private InventoryDataRepo _inventoryDataRepo;
        private Item _testItem1, _testItem2;
        private Location _testLocaiton;
        private Inventory _testInventory;
        private ItemDataRepo _itemDataRepo;
        private LocationDataRepo _locationDataRepo;

        [SetUp]
        public void Setup()
        {
            _inventoryDataRepo = new InventoryDataRepo(new TestDbContext());
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
            _inventoryDataRepo.RemoveAsync(_testInventory.Id);
        }

        [Test]
        public async Task AddInventoryToDb()
        {
            var result = await _inventoryDataRepo.AddAsync(_testInventory);
            Assert.NotNull(result);
            Assert.AreEqual(_testInventory, result );
        }

        [Test]
        public async Task GetInventory()
        {
            await _inventoryDataRepo.AddAsync(_testInventory);
            var result = await _inventoryDataRepo.GetAsync(_testInventory.Id);
            Assert.NotNull(result);
            Assert.AreEqual(_testInventory, result);
        }
        

        [Test]
        public async Task RemoveInventory()
        {
            await _inventoryDataRepo.AddAsync(_testInventory);
            var result =await _inventoryDataRepo.RemoveAsync(_testInventory.Id);
            Assert.NotNull(result);
            Assert.AreEqual(_testInventory, result);
        }

        [Test]
        public void UpdateInventory()
        {      
            _inventoryDataRepo.AddAsync(_testInventory);
            _testInventory.Amount = 100;
            var result = _inventoryDataRepo.UpdateAsync(_testInventory).Result;
            Assert.AreEqual(_testInventory.Id, result.Id);
            Assert.NotNull(result);
            Assert.AreEqual(100, result.Amount);
        }
        
    }
}