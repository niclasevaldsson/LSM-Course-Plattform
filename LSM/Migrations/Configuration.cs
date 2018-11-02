namespace LSM.Migrations
{
    using LSM.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<LSM.Models.ApplicationDbContext>
    {
        public Configuration()
        {

            AutomaticMigrationsEnabled = false;
            ContextKey = "LSM.Models.ApplicationDbContext";
        }

        protected override void Seed(LSM.Models.ApplicationDbContext context)
        {

            //Use debugging for the seed during the update database
            if (System.Diagnostics.Debugger.IsAttached == false)
                {
                    System.Diagnostics.Debugger.Launch();
                }


            var courses = new List<Course>

            {
                new Course { Name = "Java", Description = "Coding Java",
                    StartDate = DateTime.Parse("2019-09-01"), StopDate = DateTime.Parse("2019-10-01")},
                new Course { Name = "Python", Description = "Coding Pyhton",
                    StartDate = DateTime.Parse("2019-09-01"), StopDate = DateTime.Parse("2019-10-01")},
                new Course { Name = "C#", Description = "Coding C#",
                    StartDate = DateTime.Parse("2019-09-01"), StopDate = DateTime.Parse("2019-10-01")},
                new Course { Name = "Course with long description", Description = "Proin tincidunt ullamcorper lectus, sit amet tempus neque maximus quis. Phasellus at lorem id nunc hendrerit congue quis eu odio. Praesent convallis vitae odio in posuere. Interdum et malesuada fames ac ante ipsum primis in faucibus. Proin blandit diam eu dignissim pharetra. In volutpat orci nec quam placerat, nec vehicula lacus vulputate. Nullam sagittis sollicitudin nisl, non blandit orci vestibulum at. Nullam leo est, finibus ut iaculis in, consectetur eu ligula. Integer nisi neque, tempus id orci ac, porttitor sodales nunc. Praesent pretium libero scelerisque, rhoncus purus in, consectetur risus. Praesent sollicitudin est nec lectus pretium, at bibendum purus volutpat. Quisque viverra imperdiet lacus, non volutpat metus porttitor eu. Praesent convallis neque odio, cursus pretium ipsum convallis eu. Vivamus ut metus id ante tristique fringilla id quis augue.Proin tincidunt ullamcorper lectus, sit amet tempus neque maximus quis. Phasellus at lorem id nunc hendrerit congue quis eu odio. Praesent convallis vitae odio in posuere. Interdum et malesuada fames ac ante ipsum primis in faucibus. Proin blandit diam eu dignissim pharetra. In volutpat orci nec quam placerat, nec vehicula lacus vulputate. Nullam sagittis sollicitudin nisl, non blandit orci vestibulum at. Nullam leo est, finibus ut iaculis in, consectetur eu ligula. Integer nisi neque, tempus id orci ac, porttitor sodales nunc. Praesent pretium libero scelerisque, rhoncus purus in, consectetur risus. Praesent sollicitudin est nec lectus pretium, at bibendum purus volutpat. Quisque viverra imperdiet lacus, non volutpat metus porttitor eu. Praesent convallis neque odio, cursus pretium ipsum convallis eu. Vivamus ut metus id ante tristique fringilla id quis augue.",
                    StartDate = DateTime.Parse("2019-09-01"), StopDate = DateTime.Parse("2019-10-01")},
                new Course { Name = "Course with many modules, activites students.",   Description = "Course with many modules, activites students.",
                    StartDate = DateTime.Parse("2019-09-01"), StopDate = DateTime.Parse("2019-10-01")},
          };
            var date = DateTime.Now;
                       
            courses.ForEach(s => context.Courses.AddOrUpdate(p => p.Name, s));
            context.SaveChanges();

            var CourseMany = context.Courses.Where(m => m.Name == "Course with many modules, activites students.").First();
            var CourseJava = context.Courses.Where(m => m.Name == "Java").First();
            var CourseC = context.Courses.Where(m => m.Name == "C#").First();
            var CoursePython = context.Courses.Where(m => m.Name == "Python").First();
                                 
            var roleStore = new RoleStore<IdentityRole>(context);
            var roleManager = new RoleManager<IdentityRole>(roleStore);

            var roleNames = new[] { "Teacher", "Student" };       // A list of different roles...
            foreach (var roleName in roleNames)
            {
                if (context.Roles.Any(r => r.Name == roleName)) continue;

                // Create new role
                var role = new IdentityRole { Name = roleName };
                var result2 = roleManager.Create(role);
                if (!result2.Succeeded)
                {
                    throw new Exception(string.Join("\n", result2.Errors));
                }
            }

            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);

            var emails = new[] { "aragon@a1.se", "galadriel@a1.se", "frodo@a1.se", "gimli@a1.se",
                 "bilbo@a1.se",  "sam@a1.se",  "pippin@a1.se"};
            var name = new[] { "Aragon", "Galadriel", "Frodo", "Gimli",
                 "Bilbo",  "Samwise",  "Peregrin" };
            var lastname = new[] { "Elessar", "Of the Forest", "Baggings", "Craftman",
                 "Baggins",  "Gamgee",  "Took" };

            string emailname;

            for (int i = 0; i < emails.Length; i++)
            {
                emailname = emails[i]; //Must be set here not in the lamba expression
                if (context.Users.Any(u => u.UserName == emailname)) continue;

                // Create user, with username and pwd
                // Update with FirstName, LastName
                DateTime t1 = DateTime.Now;
                var user = new ApplicationUser
                {
                    UserName = emails[i],
                    Email = emails[i],
                    FirstName = name[i],
                    LastName = lastname[i],
                    CourseId = CourseMany.Id
                };
                var result = userManager.Create(user, "Lsm123!");
                if (!result.Succeeded)
                {
                    throw new Exception(string.Join("\n", result.Errors));
                }
            }


            
            var u1 = userManager.FindByName("aragon@a1.se");
            userManager.AddToRole(u1.Id, "Student");


            var u2 = userManager.FindByName("galadriel@a1.se");
            userManager.AddToRole(u2.Id, "Student");


            var u3 = userManager.FindByName("frodo@a1.se");
            userManager.AddToRoles(u3.Id, "Student");


            var u4 = userManager.FindByName("gimli@a1.se");
            userManager.AddToRoles(u4.Id, "Student");


            var u5 = userManager.FindByName("bilbo@a1.se");
            userManager.AddToRoles(u5.Id, "Student");


            var u6 = userManager.FindByName("sam@a1.se");
            userManager.AddToRoles(u6.Id, "Student");


            var u7 = userManager.FindByName("pippin@a1.se");
            userManager.AddToRoles(u7.Id, "Student");

            var Teacher = new ApplicationUser
            {
                UserName = "teacher@lsm.se",
                Email = "teacher@lsm.se",
                FirstName = "Gandalf",               
                LastName = "The Grey",
                CourseId = null
            };

            userManager.Create(Teacher, "Lsm123!");
            var u8 = userManager.FindByName("teacher@lsm.se");
            userManager.AddToRoles(u8.Id, "Teacher");

            var modules = new List<Module>

            {
                new Module { Name = "Many activities", Description = "First introduction",
                    StartDate = DateTime.Parse("2019-09-01"), StopDate = DateTime.Parse("2019-10-01"), CourseId = CourseMany.Id },
                new Module { Name = "Part1", Description = "First introduction",
                    StartDate = DateTime.Parse("2019-09-01"), StopDate = DateTime.Parse("2019-10-01"), CourseId = CourseJava.Id },
                new Module { Name = "Part2", Description = "Going uphill",
                    StartDate = DateTime.Parse("2019-09-01"), StopDate = DateTime.Parse("2019-10-01"), CourseId = CourseJava.Id },
                new Module { Name = "Part3", Description = "Go downhill",
                    StartDate = DateTime.Parse("2019-09-01"), StopDate = DateTime.Parse("2019-10-01"), CourseId = CourseC.Id },
                new Module { Name = "Part4", Description = "Go forward",
                    StartDate = DateTime.Parse("2019-09-01"), StopDate = DateTime.Parse("2019-10-01"), CourseId = CourseC.Id },
                new Module { Name = "Part5", Description = "Run back",
                    StartDate = DateTime.Parse("2019-09-01"), StopDate = DateTime.Parse("2019-10-01"), CourseId = CoursePython.Id },
                new Module { Name = "Part6", Description = "Start flying",
                    StartDate = DateTime.Parse("2019-09-01"), StopDate = DateTime.Parse("2019-10-01"), CourseId = CoursePython.Id },
                new Module { Name = "Part7", Description = "Take a walk",
                    StartDate = DateTime.Parse("2019-09-01"), StopDate = DateTime.Parse("2019-10-01"), CourseId = CoursePython.Id }

            };


            var dateModule = DateTime.Now;
            for (int index = 0; index < 15; index++)
            {
                dateModule.AddMonths(1);

                modules.Add(new Module
                {
                    Name = "Module" + index,
                    Description = "Qwerty 123",
                    StartDate = date,
                    StopDate = date,
                    CourseId = CourseMany.Id

                });
            }

           

            modules.ForEach(s => context.Modules.AddOrUpdate(p => p.Name, s));
            context.SaveChanges();
            var ActivityMany = context.Modules.Where(m => m.Name == "Many activities").First();





            var act = new List<Activity>
            {
                new Activity { Name = "Act20", Description = "1",
                    Day = DateTime.Parse("2019-09-01"), Pass = Epass.FMEM, ModuleId = 1 },
                new Activity { Name = "Act21", Description = "2",
                    Day = DateTime.Parse("2019-09-01"), Pass = Epass.FMEM, ModuleId = 2 },
                new Activity { Name = "Act22", Description = "3",
                    Day = DateTime.Parse("2019-09-01"), Pass = Epass.FMEM, ModuleId = 3 },
                new Activity { Name = "Act23", Description = "4",
                    Day = DateTime.Parse("2019-09-01"), Pass = Epass.FMEM, ModuleId = 3 },
                new Activity { Name = "Act24", Description = "5",
                    Day = DateTime.Parse("2019-09-01"), Pass = Epass.FMEM, ModuleId = 3 }


            };

            for (int index = 0; index < 15; index++)
            {


                act.Add(new Activity
                {
                    Name = "Activity" + index,
                    Description = "Qwerty 123",
                    Day = date,
                    Pass = Epass.FMEM,
                    ModuleId = ActivityMany.Id

                });
            }

            act.ForEach(s => context.Activitys.AddOrUpdate(p => p.Name, s));
            context.SaveChanges();
                       
        }
    }
}
