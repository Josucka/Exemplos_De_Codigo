using MediatR;

namespace CQRSandMediatR.Commands
{
    public class DeleteStudentCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
}
