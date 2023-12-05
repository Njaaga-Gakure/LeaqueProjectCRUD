
using Microsoft.EntityFrameworkCore;
using TestApp.Data;
using TestApp.Models;
using TestApp.Services;
using System.Linq;
using System.ComponentModel.DataAnnotations;

using LeagueContext context = new LeagueContext();


var teams = from team in context.Teams
            where team != null
            orderby team.Name
            select team;

foreach (var team in teams) {
    Console.WriteLine($"{team.Name} -> {team.Stadium}");
}





