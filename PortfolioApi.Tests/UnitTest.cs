using Xunit;
using FluentAssertions;
using Moq;
using MockQueryable.Moq;
using Microsoft.EntityFrameworkCore;
using PortfolioApi.Models;

namespace PortfolioApiTests;

public class UnitTest
{
    [Fact]
    public void Test()
    {
        var mockProjects = new List<Project>
        {
            new Project
            {
                Id = 1,
                Title = "Title 1",
                ImgUrl = "ImgUrl1",
                Text = "Text1",
                GitUrl = "GitUrl1"
            },

            new Project
            {
                Id = 2,
                Title = "Title2",
                ImgUrl = "ImgUrl2",
                Text = "Text2",
                GitUrl = "GitUrl2"
            }
        };

        var mockDbCOntext = mockProjects.AsQueryable().BuildMockDbSet();

    }
}