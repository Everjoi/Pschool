using AutoMapper;
using MediatR;
using Pschool.Application.DTOs;
using Pschool.Application.Interfaces.Repository;
using Pschool.Domain.Entities;
using Pschool.Shared.Results;


namespace Pschool.Application.CQRS.StudentFolder.Queries.GetStudentById
{
    public class GetStudentByIdQueryHandler : IRequestHandler<GetStudentByIdQuery, Result<StudentDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetStudentByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<StudentDto>> Handle(GetStudentByIdQuery query, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.Repository<Student>().GetByIdAsync(query.StudentId);
            var stundet = _mapper.Map<StudentDto>(entity);
            return await Result<StudentDto>.SuccessAsync(stundet);
        }

    }
}
