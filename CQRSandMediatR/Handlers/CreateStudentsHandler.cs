using CQRSandMediatR.Commands;
using CQRSandMediatR.Models;
using CQRSandMediatR.Repositories;
using MediatR;

namespace CQRSandMediatR.Handlers
{
    public class CreateStudentsHandler : IRequestHandler<CreateStudentCommand, StudentDetails>
    {
        private readonly IStudentRepository _studentRepository;

        public CreateStudentsHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<StudentDetails> Handle(CreateStudentCommand command, CancellationToken cancellationToken)
        {
            var studentDetails = new StudentDetails()
            {
                StudentName = command.StudentName,
                StudentEmail = command.StudentEmail,
                StudentAddress = command.StudentAddress,
                StudentAge = command.StudentAge
            };

            return await _studentRepository.AddStudentAsync(studentDetails);
        }
    }
}
