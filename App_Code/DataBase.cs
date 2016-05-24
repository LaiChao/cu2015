using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Day1PM
{
    public class DataBase
    {
        public static List<Employee> GetEmployeesByPageIndex(int p)
        {
            int skip=(p-1)*4;
            int take=4;
            List<Employee> all = GetAll();
            var query = (from e in all
                         select e)
                      .Skip<Employee>(skip)
                      .Take<Employee>(take);
            List<Employee> result = query.ToList<Employee>();
            return result;
        }

        private static List<Employee> GetAll()
        {
            List<Employee> list = new List<Employee>
            {
                new Employee{Id=1,Name="胡帅",Salary=1000000,Unit="津巴布韦币",Job="总裁"},
                new Employee{Id=2,Name="陆云飞",Salary=8866,Unit="美元",Job="班长"},
                new Employee{Id=3,Name="张春",Salary=9900,Unit="美元",Job="排长"},
                new Employee{Id=4,Name="李海波",Salary=11000,Unit="美元",Job="连长"},
                new Employee{Id=5,Name="曹真真",Salary=12300,Unit="坦桑尼亚币",Job="营长"},
                new Employee{Id=6,Name="李林",Salary=13200,Unit="美元",Job="团长"},
                new Employee{Id=7,Name="张新颖",Salary=15882,Unit="美元",Job="旅长"},
                new Employee{Id=8,Name="王强龙",Salary=26445,Unit="美元",Job="师长"},
                new Employee{Id=9,Name="蒲新",Salary=34556,Unit="维吾尔币",Job="切糕党"},
                new Employee{Id=10,Name="冯伟坚",Salary=45852,Unit="美元",Job="军长"},
                new Employee{Id=11,Name="黄晓宁",Salary=58963,Unit="美元",Job="参谋长"},
                new Employee{Id=12,Name="任宇",Salary=65666,Unit="美元",Job="司令"},
                new Employee{Id=13,Name="习近平",Salary=6646466,Unit="美元",Job="军委主席"},
            };
            return list;
        }
    }

    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Salary { get; set; }
        public string Unit{get;set;}
        public string Job { get; set; }
    }
}