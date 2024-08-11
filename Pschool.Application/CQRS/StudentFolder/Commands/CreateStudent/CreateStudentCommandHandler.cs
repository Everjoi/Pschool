using AutoMapper;
using MediatR;
using Pschool.Application.Interfaces.Repository;
using Pschool.Domain.Entities;
using Pschool.Shared.Results;


namespace Pschool.Application.CQRS.StudentFolder.Commands.CreateStudent
{
    public class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommand, Result<Guid>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private const int DaysPerYear = 365;

        public CreateStudentCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Result<Guid>> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            var student = new Student
            {
                Name = request.Name,
                Age = (DateTime.Now - request.DateOfBirth).Days / DaysPerYear,
                Surname = request.Surname,
                LastName = request.LastName,
                DateOfBirth = request.DateOfBirth,
                Gender = request.Gender,
                EnrollmentDate  = request.EnrollmentDate,
                Grade = request.Grade,
                ParentId = request.ParentId
                //CreatedBy =  TODO: create service and get id from current user session
                //ModifiedBy = TODO: create service and get id from current user session
            };

            await _unitOfWork.Repository<Student>().AddAsync(student);
            student.AddDomainEvent(new CreateStudentEvent(student));
            await _unitOfWork.Save(cancellationToken);
            return await Result<Guid>.SuccessAsync(student.Id, "Student Created.");
        }
    }
}
