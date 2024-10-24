namespace Default.Core.Domain
{
    public class Course
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public DateTime EntranceExamStartDate { get; set; }

        public DateTime EntranceExamEndDate { get; set; }

        public int Vacancies { get; set; }
    }
}
