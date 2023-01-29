using System;
using System.Collections.Generic;

using System;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        job1._jobTitle = "Hardware Managment Specialist";
        job1._company = "JD Machine";
        job1._startYear = 2015;
        job1._endYear = 2020;

        Job job2 = new Job();
        job2._jobTitle = "Survey Technician";
        job2._company = "Wall Consultant Group";
        job2._startYear = 2020;
        job2._endYear = 2023;

        Resume myResume = new Resume();
        myResume._name = "Jordan Postak";

        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);

        myResume.Display();
    }
}