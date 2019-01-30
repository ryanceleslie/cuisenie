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
using Core.Specifications;
using UnitTests.Builders;
using System.Linq.Expressions;

namespace UnitTests.Infrastructure.Data
{
    public class RepositoryTests
    {
        private Mock<MealPlannerContext> _context { get; set; }
        private IRepository<BaseEntity> _repository { get; set; }
        private BaseEntity _entity { get; set; }
        private MockDbSet<BaseEntity> _dbSet { get; set; }
        private ISpecification<BaseEntity> _spec { get; set; }

        public RepositoryTests()
        {
            _context = new Mock<MealPlannerContext>(new DbContextOptions<MealPlannerContext>());
            _repository = new EfRepository<BaseEntity>(_context.Object);
            _entity = new BaseEntityBuilder().WithDefaultValues();
            _dbSet = new MockDbSet<BaseEntity>(new List<BaseEntity> { _entity });
            _spec = new Mock<BaseSpecification<BaseEntity>>(null) { CallBase = true }.Object;

            _context.Setup(c => c.Set<BaseEntity>()).Returns(_dbSet.Object);
        }

        #region Add
        
        [Fact]
        public async Task Add_Returns_Type_And_Entity()
        {
            // Arrange
            var mockEntity = _entity;
            _dbSet.MockObject.Setup(x => x.AddAsync(It.IsAny<BaseEntity>(), default(System.Threading.CancellationToken))).ReturnsAsync(mockEntity.As<EntityEntry<BaseEntity>>);

            // Act
            var act = await _repository.Add(mockEntity);

            // Assert
            act.Should().BeOfType<BaseEntity>().And.BeEquivalentTo(_entity);
        }
        #endregion

        #region Update

        [Fact]
        public async Task Update_Entity()
        {
            // Arrange
            _entity.ModifiedBy = "differentUser";
            var mockEntity = _entity;
            _dbSet.MockObject.Setup(x => x.Update(It.IsAny<BaseEntity>())).Returns(mockEntity.As<EntityEntry<BaseEntity>>);

            // Act
            await _repository.Update(mockEntity);

            // Assert
            _dbSet.MockObject.Verify(x => x.Update(It.Is<BaseEntity>(y => y == mockEntity)));
        }

        #endregion

        #region Delete

        [Fact]
        public async Task Delete_Entity()
        {
            // Arrange
            var mockEntity = _entity;
            _dbSet.MockObject.Setup(x => x.Remove(It.IsAny<BaseEntity>())).Returns(mockEntity.As<EntityEntry<BaseEntity>>);

            // Act
            await _repository.Delete(mockEntity);

            // Assert
            _dbSet.MockObject.Verify(x => x.Remove(It.Is<BaseEntity>(y => y == mockEntity)));
        }

        #endregion

        #region GetById

        [Fact]
        public async Task GetById_Returns_Type_And_Entity()
        {
            // Arrange
            var id = 1;
            var mockEntity = _entity;
            _dbSet.MockObject.Setup(x => x.FindAsync(It.IsAny<int>())).ReturnsAsync(mockEntity);
            
            // Act
            var act = await _repository.GetById(id);

            // Assert
            act.Should().BeOfType<BaseEntity>().And.BeEquivalentTo(mockEntity);
        }

        #endregion

        #region GetSingleBySpec

        [Fact]
        public async Task GetSingleBySpec_Returns_Type_And_Entity()
        {
            // Arrange
            var id = 1;
            var spec = new BaseEntitySpecificationBuilder(id);
            var single = _dbSet.Object.Where(x => x.Id == id).FirstOrDefault();

            // Act
            var act = await _repository.GetSingleBySpec(spec);

            // Assert
            act.Should().BeOfType<BaseEntity>().And.BeEquivalentTo(single);
        }

        #endregion

        #region List

        [Fact]
        public async Task List_By_Spec_Returns_List()
        {
            // Arrange
            var id = 1;
            var spec = new BaseEntitySpecificationBuilder(id);
            var list = _dbSet.Object.Where(x => x.Id == id).ToList();

            // Act
            var act = await _repository.List(spec);

            // Assert
            act.Should().BeEquivalentTo(list);
        }

        #endregion

        #region ListAll

        [Fact]
        public async Task ListAll_Returns_List()
        {
            // Arrange
            var list = new List<BaseEntity> { _entity };

            // Act
            var act = await _repository.ListAll();

            // Assert
            act.Should().BeEquivalentTo(list);
        }

        #endregion

        #region Count

        [Fact]
        public async Task Count_By_Spec_Returns_Int()
        {
            // Arrange
            var spec = _spec;

            // Act
            var act = await _repository.Count(spec);

            // Assert
            act.Should().BeOfType(typeof(int)).And.BeGreaterThan(0);
        }

        #endregion
    }
}