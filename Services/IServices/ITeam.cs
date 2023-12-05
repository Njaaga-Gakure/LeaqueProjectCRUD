using Microsoft.EntityFrameworkCore;
using TestApp.Data;
using TestApp.Models;

namespace TestApp.Services.IServices
{
    public interface ITeam
    {
        bool CreateTeam(Team team, LeagueContext context);
        List<Team> GetAllTeams(LeagueContext context);

        Team? GetTeamById(int id, LeagueContext context);

        bool UpdateTeam(int id, string name, string stadium, LeagueContext context);

        bool DeleteTeam (int id, LeagueContext context);

    }
}
