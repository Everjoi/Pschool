using AutoMapper;
using MediatR;
using Pschool.Application.Interfaces.Repository;
using Pschool.Domain.Entities;
using Pschool.Shared.Interfaces;
using Pschool.Shared.Results;


namespace Pschool.Application.CQRS.StudentFolder.Commands.UpdateStudent
{
    public class UpdateStudentCommandHandler : IRequestHandler<UpdateStudentCommand, IResult<Guid>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private const int DaysPerYear = 365;

        public UpdateStudentCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IResult<Guid>> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {
            var student = await _unitOfWork.Repository<Student>().GetByIdAsync(request.Id);
            student.Surname = request.Surname;
            student.Age = (DateTime.Now - request.DateOfBirth).Days / DaysPerYear;
            student.DateOfBirth = request.DateOfBirth;
            student.LastName = request.LastName;
            student.ModifiedOn = DateTime.Now;
            student.Gender = request.Gender;
            student.Name = request.Name;
            student.Grade = request.Grade;

            await _unitOfWork.Repository<Student>().UpdateAsync(student);
            student.AddDomainEvent(new UpdateStudentEvent(student));

            await _unitOfWork.Save(cancellationToken);

            return await Result<Guid>.SuccessAsync(student.Id, "Studnet Updated.");
        }
    }
}
