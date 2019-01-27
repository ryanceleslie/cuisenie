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
    public class RepositoryTests<T> where T : BaseEntity
    {
        public MockDbSet<T> _dbSet { get; set; }
        public Mock<MealPlannerContext> _context { get; set; }
        public IRepository<T> _repo { get; set; }
        public IAsyncRepository<T> _asyncRepo { get; set; }

        #region Add

        // test for type
        public void Test_Add_Entity_Returns_Type(T entity)
        {
            // Arrange
            _context.Setup(c => c.Set<T>())
                .Returns(_dbSet.Object);

            // Act
            var act = _repo.Add(entity);

            // Assert
            act.Should().BeOfType<T>();
        }

        // test for type async
        public async Task Test_AddAsync_Entity_Returns_Type(T entity)
        {
            // Arrange
            _context.Setup(c => c.Set<T>())
                .Returns(_dbSet.Object);

            // Act
            var act = await _asyncRepo.AddAsync(entity);

            // Assert
            act.Should().BeOfType<T>();
        }

        // test for entity
        public void Test_Add_Entity_Returns_Entity(T entity)
        {
            // Arrange
            var mockEntity = entity;
            _context.Setup(c => c.Set<T>())
                .Returns(_dbSet.Object);

            // Act
            var act = _repo.Add(entity);

            // Assert
            act.Should().BeEquivalentTo(mockEntity);
        }

        // test for entity async
        public async Task Test_AddAsync_Returns_Entity(T entity)
        {
            // Arrange
            var mockEntity = entity;
            _context.Setup(c => c.Set<T>())
                .Returns(_dbSet.Object);

            // Act
            var act = await _asyncRepo.AddAsync(entity);

            // Assert
            act.Should().BeEquivalentTo(mockEntity);
        }
        #endregion

        #region Count



        #endregion

        #region Delete



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