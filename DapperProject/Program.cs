using Dapper;
using System.Data.SqlClient;

namespace DapperProject
{
    internal class Program
    {
        const string connString = "Data Source=localhost;Initial Catalog=Company_CS;Integrated Security=True";
        static void Main(string[] args)
        {
            var projects = new List<Project>();

            //var sql = "select * from project";

            var sql =
                "SELECT Project.*, SSN, FName, LName " +
                "FROM Project " +
                "INNER JOIN Works_on ON PNumber = PNo " +
                "INNER JOIN Employee ON Essn = SSN";


            using (var connection = new SqlConnection(connString))
            {
                //projects = connection.Query<Project>(sql).ToList();

                projects = connection.Query<Project, Employee, Project>(sql, (project, employee) =>
                {
                    project.Employees.Add(employee);
                    return project;
                }, splitOn: "SSN")
                .GroupBy(p => p.PNumber).Select(g =>
                 {
                     var groupedPost = g.First();
                     groupedPost.Employees = g.Select(p => p.Employees.Single()).ToList();
                     return groupedPost;
                 }).ToList();

                foreach (var project in projects)
                {
                    Console.WriteLine(project);
                    foreach (var employee in project.Employees)
                        Console.WriteLine("        " + employee);
                }
            }
        }
    }
}