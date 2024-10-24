namespace Default.Core.Domain.Dto
{
    public class StudentDto
    {
        public string Name { get; set; } = string.Empty;

        public DateTime DateOfBirth { get; set; }

        public string Cpf { get; set; } = string.Empty;

        public string Rg { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string PhoneNumber { get; set; } = string.Empty;

        public string CellPhoneNumber { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;

        public string City { get; set; } = string.Empty;

        public string State { get; set; } = string.Empty;

        public string Country { get; set; } = string.Empty;

        public string ZipCode { get; set; } = string.Empty;

        public int CourseId { get; set; }
    }
}
