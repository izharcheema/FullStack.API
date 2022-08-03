namespace FullStack.API.Models
{
    public class InternalUser
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Designation { get; set; }
        public int Grade { get; set; }
        public int EmployeeId { get; set; }
        public string Gender { get; set; }
        public int UserRole_GroupRole { get; set; }
        public int UserGroup { get; set; }
        public string DateOFBirth { get; set; }
        public string CNIC { get; set; }
        public string Mobile { get; set; }

    }
}
