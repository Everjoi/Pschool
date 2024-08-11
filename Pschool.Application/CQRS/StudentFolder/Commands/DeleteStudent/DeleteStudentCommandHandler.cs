using AutoMapper;
using MediatR;
using Pschool.Application.Interfaces.Repository;
using Pschool.Domain.Entities;
using Pschool.Shared.Interfaces;
using Pschool.Shared.Results;


namespace Pschool.Application.CQRS.StudentFolder.Commands.DeleteStudent
{
    public class DeleteStudentCommandHandler : IRequestHandler<DeleteStudentCommand, IResult<Guid>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteStudentCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IResult<Guid>> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            var student = await _unitOfWork.Repository<Student>().GetByIdAsync(request.StudentId);
            await _unitOfWork.Repository<Student>().DeleteAsync(student);
            student.AddDomainEvent(new DeleteStudentEvent(student));
            await _unitOfWork.Save(cancellationToken);
            return await Result<Guid>.SuccessAsync(student.Id, "Student Deleted.");
        }
    }
}
