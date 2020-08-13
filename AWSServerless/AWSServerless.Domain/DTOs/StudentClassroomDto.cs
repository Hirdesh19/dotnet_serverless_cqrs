namespace AWSServerless.Domain.DTOs
{
    public class StudentClassroomDto
    {
        #region Public Properties

        public ClassroomDto Classroom { get; set; }
        public int ClassRoomId { get; set; }
        public StudentDto Student { get; set; }
        public int StudentId { get; set; }

        #endregion Public Properties
    }
}