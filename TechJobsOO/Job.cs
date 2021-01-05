using System;
namespace TechJobsOO
{
    public class Job
    {
        public int Id { get; }
        private static int nextId = 1;

        public string Name { get; set; }
        public Employer EmployerName { get; set; }
        public Location EmployerLocation { get; set; }
        public PositionType JobType { get; set; }
        public CoreCompetency JobCoreCompetency { get; set; }

        // TODO: Add the two necessary constructors.
        public Job()
        {
            Id = nextId;
            nextId++;
        }

        public Job(string name,
            Employer employerName,
            Location employerLocation,
            PositionType jobType,
            CoreCompetency jobCoreCompetency) : this()
        {
            Name = name;
            EmployerName = employerName;
            EmployerLocation = employerLocation;
            JobType = jobType;
            JobCoreCompetency = jobCoreCompetency;
        }

        // TODO: Generate Equals() and GetHashCode() methods.
        public override bool Equals(object obj)
        {
            return obj is Job job &&
                   Id == job.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }

        public override string ToString()
        {
            string name = String.Equals(Name, "") ? "Data not available" : Name;
            string employerName = String.Equals(EmployerName.ToString(), "") ? "Data not available" : EmployerName.ToString();
            string employerLocation = String.Equals(EmployerLocation.ToString(), "") ? "Data not available" : EmployerLocation.ToString();
            string jobType = String.Equals(JobType.ToString(), "") ? "Data not available" : JobType.ToString();
            string jobCoreCompetency = String.Equals(JobCoreCompetency.ToString(), "") ? "Data not available" : JobCoreCompetency.ToString();

            return "\nName: " + name
                + "\nEmployer: " + employerName
                + "\nLocation: " + employerLocation
                + "\nPosition Type: " + jobType
                + "\nCore Competency: " + jobCoreCompetency
                + "\n";
        }
    }
}
