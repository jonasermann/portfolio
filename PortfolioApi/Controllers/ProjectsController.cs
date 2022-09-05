using Microsoft.AspNetCore.Mvc;
using PortfolioApi.Models;

namespace PortfolioApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProjectsController : ControllerBase
{
    [HttpGet]
    public List<ProjectDTO> Get()
    {
        var projects = new List<ProjectDTO>
        {
            new ProjectDTO
            {
                Title = "Quiz",
                ImgUrl = "/static/media/graduation-project-quiz.16f62e8345593e24ba87.gif",
                Text = "This is a project I did together with three other developers in the span of two weeks. It is a fullstack application with two single page front ends using React, an ASP.NET CORE web Api backend and SQL server database. It is an application where users can take a multiple choize quiz, based on lecture material given during the salt bootcamp.",
                GitUrl = "https://github.com/jonasermann/hackday"
            },

            new ProjectDTO
            {
                Title = "Horizon Calculator",
                ImgUrl = "/static/media/horizon-calculator-hackday.1cdedf764f8cba1cdedc.png",
                Text = "This is a project that I did during the span of only one day. It is a full stack application, with a React single page front end, an ASP.NET Core web Api backend and an SQL server database. It takes the height above sea level of (and including the height of) an observer and the radius of a planet to calculate the geographical distance between the observer and the geometrical horizon. The application provides CRUD functionality as in adding and deleting planets.",
                GitUrl = "https://github.com/jonasermann/hackday"
            },

            new ProjectDTO
            {
                Title = "Horizon Calculator (again)",
                ImgUrl = "/static/media/horizon-calculator-mvc.40e1e11659d0a7090f44.png",
                Text = "This is a simplified version of the previous one. It has no CRUD functionality and is a MVC application. I wanted to have the same application in only c# and html, which is why I re-created it.",
                GitUrl = "https://github.com/jonasermann/horizon-calculator"
            },

            new ProjectDTO
            {
                Title = "Kalaha",
                ImgUrl = "/static/media/kalaha-play.704d0d6cd7091ac2448a.png",
                Text = "In my early days of coding, I started off with Python. It was an easy language to learn, and as my first project I got to create a console-application of a game called \"Kalaha\". The rules are very easy and thus it wasn't so hard to program. In this program, two players can play against each other, or one can play against a script where the computer will do random choices. There is also an application for simulating thousands of kalaha games played by two different scripts, to see which script is better (one does random choices, the other chooses based on some rules).",
                GitUrl = "https://github.com/jonasermann/python-projects/blob/main/Kalaha_Play.py"
            },

            new ProjectDTO
            {
                Title = "Python Projects",
                ImgUrl = "/static/media/python-logo.755f4b6a7ab54b8d0ac4.jp",
                Text = "After the kalaha projects, I continued coding in my free time and other courses in university. I have gathered them all in one collective repository on github, where you can view all of them. They are all calculators, except the kalaha one.",
                GitUrl = "https://github.com/jonasermann/python-projects/"
            },
        };

        return projects;
    }
}
