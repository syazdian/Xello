using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using GraduationTracker;
using GraduationTracker.Models;
using GraduationTracker.Repositories;

namespace GraduationTracker.Tests.Unit
{
    [TestClass]
    public class GraduationTrackerTests
    {
        //REFACTORING MAKING SETUP METHOD

        GraduationTracker _tracker;
        Diploma[] _diploma;
        Student[] _students;
        [TestInitialize]
        public void Setup()
        {
            _tracker = new GraduationTracker(new Repository());
            _diploma = SeedData.GetDiplomas();
            _students = SeedData.GetStudents();

        }

       

        //REWRITING TestHasCredits FUNCTION
        [TestMethod]
        public void TestGraduationTracker_differentStudents_AddToList()
        {
            //Arrange -> SETUP METHOD

            //Act
            var graduated = new List<Tuple<bool, STANDING>>();
            foreach (var student in _students)
            {
                graduated.Add(_tracker.HasGraduated(_diploma[0], student));
            }
            //Assert
            Assert.IsNotNull(graduated);
        }

       
        [TestMethod]
        public void TestGraduationTracker_Bellow50_GetRemedial()
        {
            //Arrange -> setup method
            //Act
            Tuple<bool, STANDING> getResult = _tracker.HasGraduated(_diploma[0], _students[3]);
            //Assert
            Assert.IsTrue(getResult.Item2 == STANDING.Remedial);
        }


        [TestMethod]
        public void TestGraduationTracker_Bellow80_GetAverage()
        {
            //Arrange 
           
            //Act
            Tuple<bool, STANDING> getResult = _tracker.HasGraduated(_diploma[0], _students[2]);
            //Assert
            Assert.IsTrue(getResult.Item2 == STANDING.Average);
        }

        [TestMethod]
        public void TestGraduationTracker_Bellow95_GetMagnaCumLaude()
        {
            //Arrange 
            
            //Act
            Tuple<bool, STANDING> getResult = _tracker.HasGraduated(_diploma[0], _students[1]);
            //Assert
            Assert.IsTrue(getResult.Item2 == STANDING.MagnaCumLaude);
        }

        [TestMethod]
        public void TestGraduationTracker_Over95_GetSumaCumLaude()
        {
            //Arrange 
          
            //Act
            Tuple<bool, STANDING> getResult = _tracker.HasGraduated(_diploma[0], _students[0]);
            //Assert
            Assert.IsTrue(getResult.Item2 == STANDING.SumaCumLaude);

        }



    }
}
