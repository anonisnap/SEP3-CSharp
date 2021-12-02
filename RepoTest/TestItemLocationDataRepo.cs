using System.Threading.Tasks;
using DataBaseAccess.DataAccess.DbContextImpl;
using DataBaseAccess.DataRepos;
using DataBaseAccess.DataRepos.Impl;
using Entities.Models;
using NUnit.Framework;

namespace RepoTest
{
    public class TestItemLocationDataRepo
    {
        private ItemLocationDataRepo _dataRepo;
        

        [SetUp]
        public void Setup()
        {
            _dataRepo = new ItemLocationDataRepo(new TestDbContext());

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
        public async Task AddItemLocationToDb()
        {
            
           
        }
    }
}