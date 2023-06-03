using System;
using AppConsole.Entities.Enums;
using AppConsole.Entities;
using System.Globalization;
using System.Data;

namespace AppConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("qual o nome do departamento?_: ");
            string depName = Console.ReadLine();
            Console.Write("Nome do trabalhador: ");
            string name = Console.ReadLine();
            Console.Write("Insira o nivel do trabalhador (junior/midlevel/senior) ");
            WorkerLevel Level = Enum.Parse<WorkerLevel>(Console.ReadLine().ToLower());
            Console.Write("Insira o salario do trabalhador: ");
            double salary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Department dept = new Department(depName);
            Worker worker = new Worker(name, Level, salary, dept);

            Console.WriteLine("quantos contratos vamos ter");
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("entre com o contrato numero #{0}", i);
                Console.WriteLine("Data (DD/MM/YYYY) com /");
                DateTime date = DateTime.Parse(Console.ReadLine());
                Console.Write("Valor por hora:");
                double valuePerHour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("quantas horas?");
                int hours = int.Parse(Console.ReadLine());
                HourContract contract = new HourContract(date, valuePerHour, hours);
                worker.AddContract(contract);
            }

            Console.WriteLine();
            Console.Write("entre com o mês e o ano do contrato: (MM/YYYY) com / ");
            string mothYears = Console.ReadLine();
            int moth = int.Parse(mothYears.Substring(0, 2));
            int year = int.Parse(mothYears.Substring(3));
            Console.WriteLine("Nome: " + worker.Name);
            Console.WriteLine("Departamento: " + worker.Department.Name);
            Console.WriteLine("ganho no periodo: " + mothYears + " : " + worker.Income(year, moth));
        }


    }
}