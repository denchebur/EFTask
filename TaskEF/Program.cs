using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace TaskEF
{
    class Program
    {
        static void Main(string[] args)
        {
            using(AppContext ctx = new AppContext())
            {
                while (true)
                {
                    Console.WriteLine("Select action");
                    Console.WriteLine("1. Show");
                    Console.WriteLine("2. Add");
                    Console.WriteLine("3. Delete");
                    Console.WriteLine("4. Update");
                    Console.WriteLine("5. Show filters");
                    int i = Convert.ToInt32(Console.ReadLine());
                    switch (i)
                    {
                        case 1:
                            ShowData(ctx);
                            break;
                        case 2:
                            Adding(ctx);
                            break;
                        case 3:
                            Deleteing(ctx);
                            break;
                        case 4:
                            Updating(ctx);
                            break;
                        case 5:                           
                            GetQuery(ctx);                           
                            break;
                        default:
                            Console.WriteLine("try Again");
                            break;

                    }
                }
            }
        }    
        private static void ShowData(AppContext ctx)
        {
            List<Type> types = new List<Type> { typeof(Car), typeof(Owner),
                typeof(Appointment)};
            Console.WriteLine("Change table:");
            int i = 1;
            foreach (var v in types)
            {
                Console.WriteLine($"{i}) {v.Name};");
                i++;
            }
            Console.WriteLine(">>>");
            Console.WriteLine("Select ID");
            var ID = Convert.ToInt32(Console.ReadLine());
            switch (ID)
            {
                case 1:
                    {
                        Console.WriteLine(string.Join("", Enumerable.Repeat("_", 50).ToArray()));
                        Console.WriteLine($"| {"id" + string.Join("", Enumerable.Repeat(" ", (5 - "id".Length)).ToArray())}" +
                                $" | {"Manufacture" + string.Join("", Enumerable.Repeat(" ", (15 - "Manufacture".Length)).ToArray())}" +
                                $" | {"Model" + string.Join("", Enumerable.Repeat(" ", (10 - "Model".Length)).ToArray())}" +
                                $" | ");
                        Console.WriteLine(string.Join("", Enumerable.Repeat("_", 50).ToArray()));
                        foreach (var v in ctx.Cars)
                        {
                            Console.WriteLine($"| {v.Id + string.Join("", Enumerable.Repeat(" ", (5 - v.Id.ToString().Length)).ToArray())}" +
                                $" | {v.Manufacture + string.Join("", Enumerable.Repeat(" ", (15 - v.Manufacture.ToString().Length)).ToArray())}" +
                                $" | {v.Model + string.Join("", Enumerable.Repeat(" ", (10 - v.Model.ToString().Length)).ToArray())}" +
                                $" | ");
                        }
                        Console.WriteLine(string.Join("", Enumerable.Repeat("_", 50).ToArray()));
                    };
                    break;
                case 2:
                    {
                        Console.WriteLine(string.Join("", Enumerable.Repeat("_", 50).ToArray()));
                        Console.WriteLine($"| {"id" + string.Join("", Enumerable.Repeat(" ", (5 - "id".Length)).ToArray())}" +
                                $" | {"Firstname" + string.Join("", Enumerable.Repeat(" ", (15 - "Firstname".Length)).ToArray())}" +
                                $" | {"LastName" + string.Join("", Enumerable.Repeat(" ", (15 - "LastName".Length)).ToArray())}" +
                                $" | ");
                        Console.WriteLine(string.Join("", Enumerable.Repeat("_", 50).ToArray()));
                        foreach (var v in ctx.Owners)
                        {
                            Console.WriteLine($"| {v.Id + string.Join("", Enumerable.Repeat(" ", (5 - v.Id.ToString().Length)).ToArray())}" +
                                $" | {v.Firstname + string.Join("", Enumerable.Repeat(" ", (15 - v.Firstname.ToString().Length)).ToArray())}" +
                                $" | {v.LastName + string.Join("", Enumerable.Repeat(" ", (15 - v.LastName.ToString().Length)).ToArray())}" +
                                $" | ");
                        }
                        Console.WriteLine(string.Join("", Enumerable.Repeat("_", 50).ToArray()));
                    };
                    break;
                case 3:
                    {
                        Console.WriteLine(string.Join("", Enumerable.Repeat("_", 50).ToArray()));
                        Console.WriteLine($"| {"id" + string.Join("", Enumerable.Repeat(" ", (5 - "id".Length)).ToArray())}" +
                                $" | {"VisitDate" + string.Join("", Enumerable.Repeat(" ", (20 - "VisitDate".Length)).ToArray())}" +
                                $" | {"Status" + string.Join("", Enumerable.Repeat(" ", (10 - "Status".Length)).ToArray())}" +
                                $" | ");
                        Console.WriteLine(string.Join("", Enumerable.Repeat("_", 50).ToArray()));
                        foreach (var v in ctx.Appointments)
                        {
                            Console.WriteLine($"| {v.Id + string.Join("", Enumerable.Repeat(" ", (5 - v.Id.ToString().Length)).ToArray())}" +
                                $" | {v.VisitDate + string.Join("", Enumerable.Repeat(" ", (20 - v.VisitDate.ToString().Length)).ToArray())}" +
                                $" | {v._Status + string.Join("", Enumerable.Repeat(" ", (10 - v._Status.ToString().Length)).ToArray())}" +
                                $" | ");      
                        }
                        Console.WriteLine(string.Join("", Enumerable.Repeat("_", 50).ToArray()));
                    };
                    break;
                                    
            };
            Console.ReadKey();
            Console.Clear();
            
        }
        private static void Deleteing(AppContext ctx)
        {
            List<Type> types = new List<Type> { typeof(Car), typeof(Owner),
                typeof(Appointment), typeof(Service), typeof(TypeOfService)};
            Console.WriteLine("Deleting entry:");
            Console.WriteLine(string.Join("", Enumerable.Repeat("_", 50).ToArray()));
            Console.WriteLine($"| {"id" + string.Join("", Enumerable.Repeat(" ", (5 - "id".Length)).ToArray())}" +
                    $" | {"VisitDate" + string.Join("", Enumerable.Repeat(" ", (20 - "VisitDate".Length)).ToArray())}" +
                    $" | {"Status" + string.Join("", Enumerable.Repeat(" ", (10 - "Status".Length)).ToArray())}" +
                    $" | ");
            Console.WriteLine(string.Join("", Enumerable.Repeat("_", 50).ToArray()));
            foreach (var v in ctx.Appointments)
            {

                Console.WriteLine($"| {v.Id + string.Join("", Enumerable.Repeat(" ", (5 - v.Id.ToString().Length)).ToArray())}" +
                                $" | {v.VisitDate + string.Join("", Enumerable.Repeat(" ", (20 - v.VisitDate.ToString().Length)).ToArray())}" +
                                $" | {v._Status + string.Join("", Enumerable.Repeat(" ", (20 - v._Status.ToString().Length)).ToArray())}" +
                                $" | ");
            }
            Console.WriteLine(string.Join("", Enumerable.Repeat("_", 50).ToArray()));
            Console.WriteLine("Select ID");
            Console.Write(">>>");      
            ctx.Appointments.Remove(ctx.Appointments.First(c => c.Id == Convert.ToInt32(Console.ReadLine())));
            ctx.Appointments.UpdateRange();
            ctx.SaveChanges(true);
            Console.WriteLine("Deleted");
            Console.ReadKey();
            Console.Clear();
                       
        } 
        private static void Adding(AppContext ctx)
        {
            List<Type> types = new List<Type> { typeof(Car), typeof(Owner),
                typeof(Appointment), typeof(Service), typeof(TypeOfService)};
            Console.WriteLine("Creating entry:");


            
            Console.WriteLine("Select Id of service:");
            foreach (var v in ctx.Services)
            {
                Console.WriteLine($"| {v.Id + string.Join("", Enumerable.Repeat(" ", (5 - v.Id.ToString().Length)).ToArray())}" +
                    $" | {v.Name + string.Join("", Enumerable.Repeat(" ", (20 - v.Name.ToString().Length)).ToArray())}" +
                    $" | {v.Adress + string.Join("", Enumerable.Repeat(" ", (20 - v.Adress.ToString().Length)).ToArray())}" +
                    $" | ");
            }
            var service = ctx.Services.First(s => s.Id == Convert.ToInt32(Console.ReadLine()));


            var car = new Car();
            Console.WriteLine("Enter car's data:");
            Console.WriteLine("Mark: ");
            car.Manufacture = Console.ReadLine();
            Console.WriteLine("Model:");
            car.Model = Console.ReadLine();
            Console.WriteLine("VinCode:");
            car.VinCode = Console.ReadLine();
            Console.WriteLine("RegNumber:");
            car.RegNumber = Console.ReadLine();
            ctx.Cars.Add(car);
            

            var owner = new Owner();
            Console.WriteLine("Enter your data:");
            Console.WriteLine("FirstName:");
            owner.Firstname = Console.ReadLine();
            Console.WriteLine("LastName:");
            owner.LastName = Console.ReadLine();
            Console.WriteLine("PhoneNumber");
            owner.PhoneNumber = Console.ReadLine();
            owner.Cars.Add(car);
            ctx.Owners.Add(owner);
            

            var appointment = new Appointment();
            var appList = new List<TypeOfService>();

            appointment.Service = service;
            appointment.VisitDate = DateTime.Today;
            appointment._Status = Appointment.Status.InQueue;

            Console.WriteLine("Select services(for exit type ESC):");
            foreach (var v in ctx.TypeOfServices)
            {
                Console.WriteLine($"| {v.Id + string.Join("", Enumerable.Repeat(" ", (5 - v.Id.ToString().Length)).ToArray())}" +
                    $" | {v.Name + string.Join("", Enumerable.Repeat(" ", (20 - v.Name.ToString().Length)).ToArray())}" +
                    $" | {v.Price + string.Join("", Enumerable.Repeat(" ", (20 - v.Price.ToString().Length)).ToArray())}" +
                    $" | \n y/n");
                if (Console.ReadKey().KeyChar == 'y')
                {
                    appList.Add(v);                    
                }
                else if (Console.ReadKey().KeyChar == 'n')
                    Console.WriteLine();
            }
         
            appointment.TypeOfServices = appList;
            appointment.Car = car;
                    
            ctx.Appointments.Add(appointment);

            Console.WriteLine("Are You shure?(Y/N)");
            if (Console.ReadKey().KeyChar == 'y')
            {
                ctx.SaveChanges();
                Console.WriteLine("Entry added!");
                Console.ReadKey();
                Console.Clear();
            }
            else

            Console.WriteLine("Adding canceled!");
            Console.ReadKey();
            Console.Clear();
        }
        private static void Updating(AppContext ctx)
        {
            Console.WriteLine(">Updating entry<");           
            Console.WriteLine("1. Change comleting status entry;");
            Console.WriteLine("2. Cancel entry;");

            var i = Convert.ToInt32(Console.ReadLine());
          
            Console.WriteLine(string.Join("", Enumerable.Repeat("_", 50).ToArray()));
            
            foreach (var v in ctx.Appointments.Where(ap => ap._Status != Appointment.Status.Canceled))
            {
                Console.WriteLine($"| {v.Id + string.Join("", Enumerable.Repeat(" ", (5 - v.Id.ToString().Length)).ToArray())}" +
                                $" | {v.VisitDate + string.Join("", Enumerable.Repeat(" ", (20 - v.VisitDate.ToString().Length)).ToArray())}" +
                                $" | {v._Status + string.Join("", Enumerable.Repeat(" ", (20 - v._Status.ToString().Length)).ToArray())}" +
                                $" | ");
            }
            Console.WriteLine(string.Join("", Enumerable.Repeat("_", 50).ToArray()));
            Console.WriteLine("Select ID");
            Console.Write(">>>");

            var id = Convert.ToInt32(Console.ReadLine());

            switch (i)
            {
                case 1:
                    {                        
                        var app = ctx.Appointments.First(ap => ap.Id == id ).TypeOfServices;
                        Console.WriteLine(string.Join("", Enumerable.Repeat("_", 50).ToArray()));
                        foreach (var v in app)
                        {
                            Console.WriteLine($"| {v.Id + string.Join("", Enumerable.Repeat(" ", (5 - v.Id.ToString().Length)).ToArray())}" +
                                $" | {v.Name + string.Join("", Enumerable.Repeat(" ", (20 - v.Name.ToString().Length)).ToArray())}" +
                                $" | {v.IsCompleted + string.Join("", Enumerable.Repeat(" ", (20 - v.IsCompleted.ToString().Length)).ToArray())}" +
                                $" | ");
                            Console.WriteLine(string.Join("", Enumerable.Repeat("_", 50).ToArray()));
                            Console.WriteLine("This task is comleted? (Y/N)");
                            if (Console.ReadKey().KeyChar == 'y')                            
                                v.IsCompleted = true;                            
                            else if (Console.ReadKey().KeyChar == 'n')
                                v.IsCompleted = false;                           
                        }
                        if (!app.Where(a => a.IsCompleted == false).Any())
                        {
                            ctx.Appointments.First(ap => ap.Id == id)._Status = Appointment.Status.Completed;
                        }
                        if (app.Where(a => a.IsCompleted == true).Any())
                        {
                            ctx.Appointments.First(ap => ap.Id == id)._Status = Appointment.Status.InProccess;
                        }
                        if (app.All(a => a.IsCompleted == false))
                        {
                            ctx.Appointments.First(ap => ap.Id == id)._Status = Appointment.Status.InQueue;
                        }

                        ctx.TypeOfServices.UpdateRange(app);
                        ctx.Appointments.Update(ctx.Appointments.First(ap => ap.Id == id));

                        Console.WriteLine("Changed");
                        ctx.SaveChanges();
                    };
                    break;
                case 2:
                    {
                        ctx.Appointments.First(ap => ap.Id == id)._Status = Appointment.Status.Canceled;
                        ctx.Appointments.Update(ctx.Appointments.First(ap => ap.Id == id));
                        ctx.SaveChanges();
                        Console.WriteLine("Canceled");
                    };
                    break;
                default:
                    Console.WriteLine("error");
                    break;
            }
        }       
        private static void GetQuery(AppContext ctx)
        {
            var cars = from appointment in ctx.Appointments
                       join car in ctx.Cars on appointment.Car equals car
                       join owner in ctx.Owners on car equals owner.Cars.First(c => c.Owner == owner)
                       where EF.Functions.Like(car.RegNumber, "AX%")
                       select new
                       {
                           RegNum = car.RegNumber,
                           Phone = owner.PhoneNumber,
                           Status = appointment._Status
                       };
            foreach(var v in cars)
            {
                Console.WriteLine($"{v.Phone}  {v.RegNum}  {v.Status}");
            }
            var aps = ctx.Appointments.Where(ap => ap.VisitDate == DateTime.Today.AddDays(1));
            var aps2 = ctx.Appointments.Where(ap => ap._Status == Appointment.Status.Canceled);
            var aps3 = ctx.Appointments.ToArray().OrderByDescending(a => a._Status);            
        }
    }
}
