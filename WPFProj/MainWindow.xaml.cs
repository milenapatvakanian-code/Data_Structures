using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MySetProj;

namespace WPFProj
{
    public partial class MainWindow : Window
    {
        MySet<Student> _men = new MySet<Student>();
        MySet<Student> _women = new MySet<Student>();
        MySet<Student> _reading = new MySet<Student>();
        MySet<Student> _writing = new MySet<Student>();
        MySet<Student> _arithmetic = new MySet<Student>();

        Dictionary<string, MySet<Student>> allSets = new Dictionary<string, MySet<Student>>(); 
        public MainWindow()
        {
            Student james = new Student(1, "James", Gender.Male);
            Student robert = new Student(2, "Robert", Gender.Male);
            Student john = new Student(3, "John", Gender.Male);
            Student mark = new Student(4, "Mark", Gender.Male);
            Student otherMark = new Student(5, "other", Gender.Male);
            _men.AddRange(new[] { james, robert, john, mark, otherMark });

            Student liz = new Student(6, "Elizabeth", Gender.Female);
            Student amy = new Student(7, "Amy", Gender.Female);
            Student eve = new Student(8, "Evelyn", Gender.Female);
            _women.AddRange(new[] { liz, amy, eve });

            _reading.AddRange(new[] { james, robert, liz });
            _writing.AddRange(new[] { robert, mark, amy, eve, liz });
            _arithmetic.AddRange(new[] { john, mark, otherMark, amy });

            allSets.Add("MEN", _men);
            allSets.Add("WOMEN", _women);
            allSets.Add("READING", _reading);
            allSets.Add("WRITING", _writing);
            allSets.Add("ARITHMETIC", _arithmetic);
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (string name in allSets.Keys)
            {
                LeftSet.Items.Add(name);
                RightSet.Items.Add(name);
            }
            Operation.Items.Add("UNION");
            Operation.Items.Add("INTERSECTION");
            Operation.Items.Add("DIFFERENCE");
            Operation.Items.Add("SYMMETRIC DIFFERENCE");
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var listBox = sender as ListBox;
            var selectedItem = listBox.SelectedItem;

            MessageBox.Show(selectedItem.ToString());


        }

        private void LeftMySet_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            LeftMember.Items.Clear();
            if (e.AddedItems.Count > 0)
            {
                DisplayMySetData(GetMySetByName(e.AddedItems[0].ToString()), LeftMember);
            }


        }

        private void RightMySet_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            RightMember.Items.Clear();
            if (e.AddedItems.Count > 0)
            {
                DisplayMySetData(GetMySetByName(e.AddedItems[0].ToString()), RightMember);
            }


        }

        private MySet<Student> GetMySetByName(string? name)
        {
            return allSets[name];
        }

        private void DisplayMySetData(MySet<Student> set, ListBox listBox)
        {
            listBox.Items.Clear();
            foreach (var student in set)
            {
                listBox.Items.Add(student.Name);
            }
        }

        private void evaluateButton_Click(object sender, RoutedEventArgs e)
        {
            if (LeftSet.SelectedItem == null || RightSet.SelectedItem == null || Operation.SelectedItem == null)
            {
                MessageBox.Show("Please select both sets and operation!");
                return;
            }

            var left = GetMySetByName(LeftSet.SelectedItem.ToString());
            var right = GetMySetByName(RightSet.SelectedItem.ToString());
            var op = Operation.SelectedItem.ToString();

            MySet<Student> result = new MySet<Student>();

            switch (op)
            {
                case "UNION":
                    result = left.Union(right);
                    break;

                case "INTERSECTION":
                    result = left.Intersection(right);
                    break;

                case "DIFFERENCE":
                    result = left.Difference(right);
                    break;

                case "SYMMETRIC DIFFERENCE":
                    result = left.SymmetricDifference(right);
                    break;
            }

            ResultSet.Items.Clear();
            DisplayMySetData(result, ResultSet);
        }
    }
}