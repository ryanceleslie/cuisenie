using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using Moq;
using FluentAssertions;
using UnitTests.Utilities;
using Infrastructure.Data;

namespace UnitTests.Infrastructure.Data
{
    public class RepositoryTests
    {
        //TODO cleanup
        //public MockDbSet<T> _dbSet { get; set; }
        //public Mock<MealPlannerContext> _context { get; set; }
        //public IRepository<T> _repo { get; set; }
        //public IAsyncRepository<T> _asyncRepo { get; set; }

        public Mock<DbSet<BaseEntity>> _dbSet { get; set; }
        public Mock<MealPlannerContext> _context { get; set; }
        public IRepository<BaseEntity> _repo { get; set; }
        public IAsyncRepository<BaseEntity> _asyncRepo { get; set; }

        public RepositoryTests()
        {
            _dbSet = new Mock<DbSet<BaseEntity>>();
            _context = new Mock<MealPlannerContext>(new DbContextOptions<MealPlannerContext>());
            _repo = new EfRepository<BaseEntity>(_context.Object);
            _asyncRepo = new EfRepository<BaseEntity>(_context.Object);
        }

        #region Add

        // test for type
        [Fact]
        public void Test_Add_Entity_Returns_Type()
        {
            // Arrange
            var mockEntity = new BaseEntity();

            _context.Setup(c => c.Set<BaseEntity>())
                .Returns(_dbSet.Object);

            // Act
            var act = _repo.Add(mockEntity);

            // Assert
            act.Should().BeOfType<BaseEntity>();
        }

        //TODO cleanup
        //// test for type async
        //public async Task Test_AddAsync_Entity_Returns_Type(T entity)
        //{
        //    // Arrange
        //    _context.Setup(c => c.Set<T>())
        //        .Returns(_dbSet.Object);

        //    // Act
        //    var act = await _asyncRepo.AddAsync(entity);

        //    // Assert
        //    act.Should().BeOfType<T>();
        //}

        //// test for entity
        //public void Test_Add_Entity_Returns_Entity(T entity)
        //{
        //    // Arrange
        //    var mockEntity = entity;
        //    _context.Setup(c => c.Set<T>())
        //        .Returns(_dbSet.Object);

        //    // Act
        //    var act = _repo.Add(entity);

        //    // Assert
        //    act.Should().BeEquivalentTo(mockEntity);
        //}

        //// test for entity async
        //public async Task Test_AddAsync_Returns_Entity(T entity)
        //{
        //    // Arrange
        //    var mockEntity = entity;
        //    _context.Setup(c => c.Set<T>())
        //        .Returns(_dbSet.Object);

        //    // Act
        //    var act = await _asyncRepo.AddAsync(entity);

        //    // Assert
        //    act.Should().BeEquivalentTo(mockEntity);
        //}
        #endregion

        #region Count



        #endregion

        #region Delete

        //TODO cleanup
        //// test for no error
        //public void Test_Delete_Entity_No_Error()
        //{
        //    // Arrange
        //    _context.Setup(c => c.Set<T>())
        //        .Returns(_dbSet.Object);

        //    // Act
        //    _repo.Delete(entity);


        //}

        // test asyc for no error

        #endregion

        #region GetById



        #endregion

        #region GetSingleBySpec



        #endregion

        #region List



        #endregion

        #region Update



        #endregion
    }
}