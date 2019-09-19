using CQRS_Lite_Union_API.Common.Response;
using MediatR;

namespace CQRS_Lite_Union_API.Application.Workshops.Commands
{
    public class DeleteWorkshopCommand : IRequest<IResponse>
    {
        public DeleteWorkshopCommand(int id)
        {
            Id = id;
        }
        public int Id { get; private set; }
    }
}
