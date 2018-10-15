using GraduationTracker;
using GraduationTracker.Models;
using GraduationTracker.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;  
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RunFunction
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        GraduationTracker.GraduationTracker gr 
                = new GraduationTracker.GraduationTracker(new Repository());

        private void button1_Click(object sender, EventArgs e)
        {
            var diploma = new Diploma
            {
                Id = 1,
                Credits = 4,
                Requirements = new int[] { 100, 102, 103, 104 }
            };

            var students = new[]
            {
            new Student
               {
                   Id = 1,
                   Courses = new Course[]
                   {
                        new Course{Id = 1, Name = "Math", Mark=95 },
                        new Course{Id = 2, Name = "Science", Mark=95 },
                        new Course{Id = 3, Name = "Literature", Mark=95 },
                        new Course{Id = 4, Name = "Physichal Education", Mark=95 }
                   }
               },
            new Student
               {
                   Id = 2,
                   Courses = new Course[]
                   {
                        new Course{Id = 1, Name = "Math", Mark=80 },
                        new Course{Id = 2, Name = "Science", Mark=80 },
                        new Course{Id = 3, Name = "Literature", Mark=80 },
                        new Course{Id = 4, Name = "Physichal Education", Mark=80 }
                   }
               },
            new Student
            {
                Id = 3,
                Courses = new Course[]
                {
                    new Course{Id = 1, Name = "Math", Mark=50 },
                    new Course{Id = 2, Name = "Science", Mark=50 },
                    new Course{Id = 3, Name = "Literature", Mark=50 },
                    new Course{Id = 4, Name = "Physichal Education", Mark=50 }
                }
            },
            new Student
            {
                Id = 4,
                Courses = new Course[]
                {
                    new Course{Id = 1, Name = "Math", Mark=40 },
                    new Course{Id = 2, Name = "Science", Mark=40 },
                    new Course{Id = 3, Name = "Literature", Mark=40 },
                    new Course{Id = 4, Name = "Physichal Education", Mark=40 }
                }
            }


            //tracker.HasGraduated()
            };

            var graduated = new List<Tuple<bool, STANDING>>();

            foreach (var student in students)
            {
                graduated.Add(gr.HasGraduated(diploma, student));
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Diploma[] _diploma = SeedData.GetDiplomas();
            Student[] _students= SeedData.GetStudents();
            var graduated = new List<Tuple<bool, STANDING>>();

            Tuple<bool, STANDING> getResult = gr.HasGraduated(_diploma[0], _students[3]);

        }
    }
}
