using AutoMapper;
using MediatR;
using Pschool.Application.DTOs;
using Pschool.Application.Interfaces.Repository;
using Pschool.Domain.Entities;
using Pschool.Shared.Results;


namespace Pschool.Application.CQRS.ParentFolder.Queries.GetParentByStudentId
{
    internal class GetParentByStudentIdQueryHandler : IRequestHandler<GetParentByStudentIdQuery, Result<ParentDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetParentByStudentIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<ParentDto>> Handle(GetParentByStudentIdQuery query, CancellationToken cancellationToken)
        {
            var student = await _unitOfWork.Repository<Student>().GetByIdAsync(query.StudentId);
            var entity = await _unitOfWork.Repository<Parent>().GetByIdAsync(student.ParentId);

            var parent = _mapper.Map<ParentDto>(entity);
            return await Result<ParentDto>.SuccessAsync(parent);
        }

    }
     
}
