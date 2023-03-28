using System.Windows.Forms;

namespace Poleev_linq
{
    public partial class Form1 : Form
    {
        bool test = false;
        private List<Person> people;
        List<Department> department = new List<Department>();
        private List<Employ> employes = new List<Employ>();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            people = new List<Person>();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (test == false)
            {
                test = true;
                panel1.Visible = true;
                button3.Visible = false;
                button1.Text = "Вернуться назад";
                listBox1.Items.Clear();
                people.Clear();
                string namefile = "file.txt";
                if (File.Exists(namefile))
                {
                    string[] lines = File.ReadAllLines(namefile);
                    foreach (string line in lines)
                    {
                        string[] parts = line.Split(' ');
                        string firstName = parts[0];
                        string secondName = parts[1];
                        string surName = parts[2];
                        int age = int.Parse(parts[3]);
                        int weight = int.Parse(parts[4]);
                        Person person = new Person(firstName, secondName, surName, age, weight);
                        people.Add(person);
                        listBox1.Items.Add(line);
                    }
                }
                else
                {
                    MessageBox.Show("Такого файла нет.");
                }
            }
            else
            {
                test = false;
                panel1.Visible = false;
                button3.Visible = true;
                button1.Text = "Задание 1";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<Person> yPeople = new List<Person>();
            yPeople.Clear();
            listBox1.Items.Clear(); ;
            yPeople = people.Where(people => people.Age < 40).ToList();
            foreach (Person person in yPeople)
            {
                listBox1.Items.Add(person);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (test == false)
            {
                test = true;
                panel2.Visible = true;
                button1.Visible = false;
                button3.Text = "Вернуться назад";
                listBox2.Items.Clear();
                department.Clear();
                employes.Clear();
                department.Add(new Department { Name = "Отдел закупок", Reg = "Германия" });
                department.Add(new Department { Name = "Отдел продаж", Reg = "Испания" });
                department.Add(new Department { Name = "Отдел маркетинга", Reg = "Иран" });
                employes.Add(new Employ() { Name = "Иванов", Department = "Отдел закупок" });
                employes.Add(new Employ() { Name = "Петров", Department = "Отдел закупок" });
                employes.Add(new Employ() { Name = "Сидоров", Department = "Отдел продаж" });
                employes.Add(new Employ() { Name = "Лямин", Department = "Отдел продаж" });
                employes.Add(new Employ() { Name = "Сидоренко", Department = "Отдел маркетинга" });
                employes.Add(new Employ() { Name = "Кривоносов", Department = "Отдел продаж" });
                var query = from emp in employes
                            join dep in department on emp.Department equals dep.Name
                            group emp by dep into depGroup
                            select new
                            {
                                Department = depGroup.Key.Name,
                                Employees = depGroup.Select(emp => emp.Name)
                            };
                foreach (var group in query)
                {
                    listBox2.Items.Add(group.Department);
                    foreach (var emp in group.Employees)
                    {
                        listBox2.Items.Add("   " + emp);
                    }
                }
            }
            else
            {
                test = false;
                panel2.Visible = false;
                button1.Visible = true;
                button3.Text = "Задание 2";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            var res = from employ in employes
                      join dep in department on employ.Department equals dep.Name
                      where dep.Reg.StartsWith("И")
                      select new { employ.Name, dep.Reg };
            foreach (var item in res)
            {
                listBox2.Items.Add(item.Name + " - " + item.Reg);
            }
        }
    }
}