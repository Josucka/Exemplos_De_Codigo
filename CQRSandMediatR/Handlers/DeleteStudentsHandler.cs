using CQRSandMediatR.Commands;
using CQRSandMediatR.Repositories;
using MediatR;

namespace CQRSandMediatR.Handlers
{
    public class DeleteStudentsHandler : IRequestHandler<DeleteStudentCommand, int>
    {
        private readonly IStudentRepository _studentRepository;

        public DeleteStudentsHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<int> Handle(DeleteStudentCommand command, CancellationToken cancellationToken)
        {
            var studentDetails = await _studentRepository.GetStudentByIdAsync(command.Id);
            if (studentDetails == null)
                return default;

            return await _studentRepository.DeleteStudentAsync(studentDetails.Id);
        }
    }
}
