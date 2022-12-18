using CQRSandMediatR.Models;
using MediatR;

namespace CQRSandMediatR.Queries
{
    public class GetStudentByIdQuery : IRequest<StudentDetails>
    {
        public int Id { get; set; }
    }
}
