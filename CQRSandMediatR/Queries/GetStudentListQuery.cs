using CQRSandMediatR.Models;
using MediatR;

namespace CQRSandMediatR.Queries
{
    public class GetStudentListQuery : IRequest<List<StudentDetails>>
    {
    }
}
