using System.Data.Common;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

using WebApp.Controllers;
using WebApp.Models;

namespace WebApp.Test;

// How to test without real database
// https://learn.microsoft.com/en-us/ef/core/testing/testing-without-the-database

public class LabwareControllerTests : IDisposable
{
    private readonly DbConnection _connection;
    private readonly DbContextOptions<LabwareContext> _contextOptions;

    public LabwareControllerTests()
    {
        _connection = new SqliteConnection("Filename=:memory:");
        _connection.Open();
        _contextOptions = new DbContextOptionsBuilder<LabwareContext>()
            .UseSqlite(_connection)
            .Options;
    }

    public void Dispose()
    {
        _connection.Close();
    }

    [Fact]
    public void ShouldReturnCorrectCountOfLabwares()
    {
        // Arrange
        using (var context = new LabwareContext(_contextOptions))
        {
            var exist = context.Database.EnsureCreated();
            Assert.True(exist);
            context.Labwares.Add(new Labware { Id = 1, DisplayName = "Test Labware 1" });
            context.Labwares.Add(new Labware { Id = 2, DisplayName = "Test Labware 2" });
            context.SaveChanges();
        }

        // Act
        using (var context = new LabwareContext(_contextOptions))
        {
            var controller = new LabwareController(context);
            var result = controller.GetAllLabware();

            // Assert
            var items = Assert.IsType<List<Labware>>(result);
            Assert.Equal(2, items.Count);
        }
    }

    [Fact]
    public void ShouldHaveZeroCountOfLabwaresWhenInitial()
    {
        // Arrange
        using (var context = new LabwareContext(_contextOptions))
        {
            var exist = context.Database.EnsureCreated();
            Assert.True(exist);
        }

        // Act
        using (var context = new LabwareContext(_contextOptions))
        {
            var controller = new LabwareController(context);
            var result = controller.GetAllLabware();

            // Assert
            var items = Assert.IsType<List<Labware>>(result);
            Assert.Empty(items);
        }
    }

    [Fact]
    public void ShouldAddNewLabware()
    {
        // Arrange
        using (var context = new LabwareContext(_contextOptions))
        {
            var exist = context.Database.EnsureCreated();
            Assert.True(exist);
        }

        // Act
        using (var context = new LabwareContext(_contextOptions))
        {
            var controller = new LabwareController(context);
            var result = controller.PostLabware(new LabwareDTO { DisplayName = "Test Labware" });

            // Assert
            Assert.IsType<OkResult>(result);
            Assert.Single(context.Labwares);
        }
    }
}
