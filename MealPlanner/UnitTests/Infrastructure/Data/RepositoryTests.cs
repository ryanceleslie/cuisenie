using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Moq;
using FluentAssertions;
using UnitTests.Utilities;
using Infrastructure.Data;

namespace UnitTests.Infrastructure.Data
{
    public class RepositoryTests
    {
        private Mock<DbSet<BaseEntity>> _dbSet { get; set; }
        private Mock<MealPlannerContext> _context { get; set; }
        private IRepository<BaseEntity> _repo { get; set; }
        private IAsyncRepository<BaseEntity> _asyncRepo { get; set; }
        private BaseEntity _entity { get; set; }

        public RepositoryTests()
        {
            _dbSet = new Mock<DbSet<BaseEntity>>();
            _context = new Mock<MealPlannerContext>(new DbContextOptions<MealPlannerContext>());
            _repo = new EfRepository<BaseEntity>(_context.Object);
            _asyncRepo = new EfRepository<BaseEntity>(_context.Object);

            _context.Setup(c => c.Set<BaseEntity>())
                .Returns(_dbSet.Object);

            _entity = new BaseEntity()
            {
                Id = 1,
                CreatedBy = "user",
                ModifiedBy = "otheruser"
            };
        }

        #region Add

        [Fact]
        public void Add_Entity_Returns_Type_And_Entity()
        {
            // Arrange
            var mockEntity = _entity;
            _dbSet.Setup(x => x.Add(It.IsAny<BaseEntity>())).Returns(mockEntity.As<EntityEntry<BaseEntity>>);

            // Act
            var act = _repo.Add(mockEntity);

            // Assert
            act.Should().BeOfType<BaseEntity>().And.BeEquivalentTo(_entity);
        }
        
        [Fact]
        public async Task AddAsync_Returns_Type_And_Entity()
        {
            // Arrange
            var mockEntity = _entity;
            _dbSet.Setup(x => x.AddAsync(It.IsAny<BaseEntity>(), default(System.Threading.CancellationToken))).ReturnsAsync(mockEntity.As<EntityEntry<BaseEntity>>);

            // Act
            var act = await _asyncRepo.AddAsync(mockEntity);

            // Assert
            act.Should().BeOfType<BaseEntity>().And.BeEquivalentTo(_entity);
        }
        #endregion

        #region Count



        #endregion

        #region Delete
        
        [Fact]
        public void Delete_Entity()
        {
            // Arrange
            var mockEntity = _entity;
            _dbSet.Setup(x => x.Remove(It.IsAny<BaseEntity>())).Returns(mockEntity.As<EntityEntry<BaseEntity>>);

            // Act
            _repo.Delete(mockEntity);

            // Assert
            _dbSet.Verify(x => x.Remove(It.Is<BaseEntity>(y => y == mockEntity)));
        }

        [Fact]
        public async Task DeleteAsync_Entity()
        {
            // Arrange
            var mockEntity = _entity;
            _dbSet.Setup(x => x.Remove(It.IsAny<BaseEntity>())).Returns(mockEntity.As<EntityEntry<BaseEntity>>);

            // Act
            await _asyncRepo.DeleteAsync(mockEntity);

            // Assert
            _dbSet.Verify(x => x.Remove(It.Is<BaseEntity>(y => y == mockEntity)));
        }

        #endregion

        #region GetById

        [Fact]
        public void GetById_Returns_Type_And_Entity()
        {
            // Arrange
            var mockEntity = new BaseEntity();
            _dbSet.Setup(x => x.Find(It.IsAny<int>())).Returns(mockEntity);

            // Act
            var act = _repo.GetById(1);

            // Assert
            act.Should().BeOfType<BaseEntity>().And.BeEquivalentTo(mockEntity);
        }

        [Fact]
        public async Task GetByIdAsync_Returns_Type_And_Entity()
        {
            // Arrange
            var mockEntity = new BaseEntity();
            _dbSet.Setup(x => x.FindAsync(It.IsAny<int>())).ReturnsAsync(mockEntity);

            // Act
            var act = await _asyncRepo.GetByIdAsync(1);

            // Assert
            act.Should().BeOfType<BaseEntity>().And.BeEquivalentTo(mockEntity);
        }

        #endregion

        #region GetSingleBySpec



        #endregion

        #region List



        #endregion

        #region Update

        [Fact]
        public void Update_Entity()
        {
            // Arrange
            var mockEntity = _entity;
            _dbSet.Setup(x => x.Update(It.IsAny<BaseEntity>())).Returns(mockEntity.As<EntityEntry<BaseEntity>>);

            // Act
            _repo.Update(mockEntity);

            // Assert
            _dbSet.Verify(x => x.Update(It.Is<BaseEntity>(y => y == mockEntity)));
        }

        [Fact]
        public async Task UpdateAsync_Entity()
        {
            // Arrange
            var mockEntity = _entity;
            _dbSet.Setup(x => x.Update(It.IsAny<BaseEntity>())).Returns(mockEntity.As<EntityEntry<BaseEntity>>);

            // Act
            await _asyncRepo.UpdateAsync(mockEntity);

            // Assert
            _dbSet.Verify(x => x.Update(It.Is<BaseEntity>(y => y == mockEntity)));
        }

        #endregion
    }
}