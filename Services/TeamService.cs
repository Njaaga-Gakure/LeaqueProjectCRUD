using Microsoft.EntityFrameworkCore;
using TestApp.Data;
using TestApp.Models;
using TestApp.Services.IServices;
using System.Linq;

namespace TestApp.Services
{
    public class TeamService : ITeam
    {
        public bool CreateTeam(Team team, LeagueContext context)
        {
            try {
                context.Teams.Add(team);
                context.SaveChanges();  

                return true;   

            } catch (Exception e) {
                Console.WriteLine(e.Message);

                return false;
            }
        }
        public List<Team> GetAllTeams(LeagueContext context)
        {
            try {
                var teams = context.Teams;

                return teams.ToList();
            
            } catch (Exception e) {
                Console.WriteLine(e.Message);
                return new List<Team>();

            }
        }

        public Team? GetTeamById(int id, LeagueContext context)
        {
            try {
                var team = context.Teams.Where(team => team.Id == id).FirstOrDefault();

                if (team is Team) {
                        return team;
                }

                context.SaveChanges();
                return null;
            } catch (Exception e) {
                Console.WriteLine(e.Message);

                return null;
            }
        }

        public bool UpdateTeam(int id, string name, string stadium, LeagueContext context)
        {
            try {

                var team = context.Teams.Where(team => team.Id == id).FirstOrDefault();
                if (team is Team) { 
                
                    team.Name = name;
                    team.Stadium = stadium;
                    return true;
                }

                context.SaveChanges();

                return false;   
            
            } catch (Exception e) { 
            Console.WriteLine(e.Message);
                return false;
            }

        }

        public bool DeleteTeam(int id, LeagueContext context)
        {
            try

            {
                var team = context.Teams.Where(team => team.Id == id).FirstOrDefault();

                if (team != null) { 
                    context.Teams.Remove(team);
                    context.SaveChanges();
                    return true;
                }
                return false;   

            }
            catch (Exception e) {
                Console.WriteLine(e.Message);
                return false;
            }
        }
    }
}
