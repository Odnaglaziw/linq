using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using  linq2.classes;

namespace linq2
{
    public partial class Form1 : Form
    {
        private ListBox listBoxTaskA;
        private ListBox listBoxTaskB;
        public Form1()
        {
            BackColor = Color.FromArgb(44,44,44);
            InitializeComponent();
            InitializeListBoxes();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<Department> departments = new List<Department>()
        {
            new Department { Name = "Отдел закупок", Reg = "Германия" },
            new Department { Name = "Отдел продаж", Reg = "Испания" },
            new Department { Name = "Отдел маркетинга", Reg = "Испания" }
        };

            List<Employ> employees = new List<Employ>()
        {
            new Employ { Name = "Иванов", Department = "Отдел закупок" },
            new Employ { Name = "Петров", Department = "Отдел закупок" },
            new Employ { Name = "Сидоров", Department = "Отдел продаж" },
            new Employ { Name = "Лямин", Department = "Отдел продаж" },
            new Employ { Name = "Сидоренко", Department = "Отдел маркетинга" },
            new Employ { Name = "Кривоносов", Department = "Отдел продаж" }
        };
            var groupedDepartments = from emp in employees
                                     join dep in departments on emp.Department equals dep.Name
                                     group emp by dep into grouped
                                     select new
                                     {
                                         Department = grouped.Key.Name,
                                         Employees = grouped.Select(empInGroup => empInGroup.Name).ToList()
                                     };

            DisplayGroupedDepartments(groupedDepartments);
            var employeesInRegionI = from emp in employees
                                     join dep in departments on emp.Department equals dep.Name
                                     where dep.Reg.StartsWith("И")
                                     select emp;

            DisplayEmployeesInRegionI(employeesInRegionI);
        }

        private void DisplayGroupedDepartments(IEnumerable<dynamic> groupedDepartments)
        {
            foreach (var group in groupedDepartments)
            {
                listBoxTaskA.Items.Add($"Отдел: {group.Department}");
                foreach (var employee in group.Employees)
                {
                    listBoxTaskA.Items.Add($"   - {employee}");
                }
            }
        }

        private void DisplayEmployeesInRegionI(IEnumerable<Employ> employeesInRegionI)
        {
            foreach (var employee in employeesInRegionI)
            {
                listBoxTaskB.Items.Add($"- {employee.Name}, Отдел: {employee.Department}");
            }
        }

        private void InitializeListBoxes()
        {
            listBoxTaskA = new ListBox
            {
                Location = new System.Drawing.Point(10, 30),
                Size = new System.Drawing.Size(200, 200),
                MultiColumn = true
            };

            listBoxTaskB = new ListBox
            {
                Location = new System.Drawing.Point(250, 30),
                Size = new System.Drawing.Size(200, 200),
                MultiColumn = true,
                
            };

            Controls.Add(listBoxTaskA);
            Controls.Add(listBoxTaskB);
        }
    }
}
